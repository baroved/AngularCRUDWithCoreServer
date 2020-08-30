using Microsoft.Extensions.Logging;
using ServerCore.DAL;
using ServerCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCore.Repository
{
    public class BeersRepository
    {
        private readonly DBContext _dbContext;
        private readonly ILogger<BeersRepository> _logger;

        public BeersRepository(DBContext dbContext, ILogger<BeersRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public Task<List<Beer>> GetAllBeersAsync()
        {

            try
            {
                return Task.FromResult(_dbContext.Beers.ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get All Beers failed: {ex.Message}");
                return null;
            }

        }

        public Task<bool> AddBeerAsync(Beer newBeer)
        {
            try
            {
                if (newBeer != null)
                {
                    _dbContext.Beers.AddAsync(newBeer);
                    _dbContext.SaveChangesAsync();
                    _logger.LogInformation($"Add New Beer '{newBeer.Name}' Succeeded");
                    return Task.FromResult(true);
                }
                else
                {
                    _logger.LogError($"Add New Beer 'object' is null");
                    return Task.FromResult(false);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Add New Beer failed: {ex.Message}");
                return Task.FromResult(false);
            }
        }


        public Task<bool> DeleteBeerByIdAsync(int id)
        {
            try
            {
                var beer = _dbContext.Beers.Where(b => b.Id == id).FirstOrDefault();
                if(beer != null)
                {
                    _dbContext.Beers.Remove(beer);
                    _dbContext.SaveChangesAsync();
                    _logger.LogInformation($"Delete beer '{beer.Name}' Succeeded");
                    return Task.FromResult(true);
                }
                else
                {
                    _logger.LogError($"beer id:'{id}' not exists");
                    return Task.FromResult(false);
                }
            }

            catch(Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                return Task.FromResult(false);
            }
        }

        public Task<bool> UpdateBeerById(int id,Beer oldBeer)
        {
            try
            {
                var beer = _dbContext.Beers.Where(b => b.Id == id).FirstOrDefault(); 
                if(beer != null)
                {
                    beer.Name = oldBeer.Name;
                    beer.Price = oldBeer.Price;
                    beer.CountOfAlcohol = oldBeer.CountOfAlcohol;
                    _dbContext.SaveChangesAsync();
                    _logger.LogInformation($"Update beer '{oldBeer.Name}' Succeeded");
                    return Task.FromResult(true);
                }
                else
                {
                    _logger.LogError($"beer id:'{oldBeer.Id}' not exists");
                    return Task.FromResult(false);
                }
            }

            catch(Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                return Task.FromResult(false);
            }
        }

        public Task<Beer> GetBeerById(int id)
        {
            try
            {
                var beer = _dbContext.Beers.Where(b => b.Id == id).FirstOrDefault();
                if (beer != null)
                {
                    _logger.LogInformation($"Get Beer '{beer.Name}' Succeeded");
                    return Task.FromResult(beer);
                }
                else
                {
                    _logger.LogError($"'beer id:{id}' not exists");
                    return Task.FromResult(new Beer());
                }
            }

            catch(Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                return Task.FromResult(new Beer());
            }
        }






        
    }
}
