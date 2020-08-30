using Microsoft.Extensions.Logging;
using ServerCore.DAL;
using ServerCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCore.Repository
{
    public class DogsRepository
    {
        private readonly DBContext _dbContext;
        private readonly ILogger<DogsRepository> _logger;

        public DogsRepository(DBContext dbContext, ILogger<DogsRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public Task<List<Dog>> GetAllDogsAsync()
        {

            try
            {
                return Task.FromResult(_dbContext.Dogs.ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get All Dogs failed: {ex.Message}");
                return null;
            }

        }

        public Task<bool> AddDogAsync(Dog newDog)
        {
            try
            {
                if (newDog != null)
                {
                    _dbContext.Dogs.AddAsync(newDog);
                    _dbContext.SaveChangesAsync();
                    _logger.LogInformation($"Add New Dog '{newDog.Name}' Succeeded");
                    return Task.FromResult(true);
                }
                else
                {
                    _logger.LogError($"Add New Dog 'object' is null");
                    return Task.FromResult(false);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Add New Dog failed: {ex.Message}");
                return Task.FromResult(false);
            }
        }


        public Task<bool> DeleteDogByIdAsync(int id)
        {
            try
            {
                var dog = _dbContext.Dogs.Where(b => b.Id == id).FirstOrDefault();
                if (dog != null)
                {
                    _dbContext.Dogs.Remove(dog);
                    _dbContext.SaveChangesAsync();
                    _logger.LogInformation($"Delete dog '{dog.Name}' Succeeded");
                    return Task.FromResult(true);
                }
                else
                {
                    _logger.LogError($"dog id:'{id}' not exists");
                    return Task.FromResult(false);
                }
            }

            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                return Task.FromResult(false);
            }
        }

        public Task<bool> UpdateDogById(int id,Dog oldDog)
        {
            try
            {
                var dog = _dbContext.Dogs.Where(b => b.Id == id).FirstOrDefault();
                if (dog != null)
                {
                    dog.Name = oldDog.Name;
                    dog.Age = oldDog.Age;
                    dog.Color = oldDog.Color;
                    _dbContext.SaveChangesAsync();
                    _logger.LogInformation($"Update dog '{oldDog.Name}' Succeeded");
                    return Task.FromResult(true);
                }
                else
                {
                    _logger.LogError($"dog id:'{oldDog.Id}' not exists");
                    return Task.FromResult(false);
                }
            }

            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                return Task.FromResult(false);
            }
        }

        public Task<Dog> GetDogById(int id)
        {
            try
            {
                var dog = _dbContext.Dogs.Where(b => b.Id == id).FirstOrDefault();
                if (dog != null)
                {
                    _logger.LogInformation($"Get Dog '{dog.Name}' Succeeded");
                    return Task.FromResult(dog);
                }
                else
                {
                    _logger.LogError($"'dog id:{id}' not exists");
                    return Task.FromResult(new Dog());
                }
            }

            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                return Task.FromResult(new Dog());
            }
        }
    }
}
