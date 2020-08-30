using Microsoft.Extensions.Logging;
using ServerCore.DAL;
using ServerCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCore.Repository
{
    public class CarsRepository
    {
        private readonly DBContext _dbContext;
        private readonly ILogger<CarsRepository> _logger;

        public CarsRepository(DBContext dbContext, ILogger<CarsRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public Task<List<Car>> GetAllCarsAsync()
        {

            try
            {
                return Task.FromResult(_dbContext.Cars.ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get All Cars failed: {ex.Message}");
                return null;
            }

        }

        public Task<bool> AddCarAsync(Car newCar)
        {
            try
            {
                if (newCar != null)
                {
                    _dbContext.Cars.AddAsync(newCar);
                    _dbContext.SaveChangesAsync();
                    _logger.LogInformation($"Add New Car '{newCar.Name}' Succeeded");
                    return Task.FromResult(true);
                }
                else
                {
                    _logger.LogError($"Add New Car 'object' is null");
                    return Task.FromResult(false);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Add New Car failed: {ex.Message}");
                return Task.FromResult(false);
            }
        }


        public Task<bool> DeleteCarByIdAsync(int id)
        {
            try
            {
                var car = _dbContext.Cars.Where(b => b.Id == id).FirstOrDefault();
                if (car != null)
                {
                    _dbContext.Cars.Remove(car);
                    _dbContext.SaveChangesAsync();
                    _logger.LogInformation($"Delete car '{car.Name}' Succeeded");
                    return Task.FromResult(true);
                }
                else
                {
                    _logger.LogError($"car id:'{id}' not exists");
                    return Task.FromResult(false);
                }
            }

            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                return Task.FromResult(false);
            }
        }

        public Task<bool> UpdateCarById(int id,Car oldCar)
        {
            try
            {
                var car = _dbContext.Cars.Where(b => b.Id == id).FirstOrDefault();
                if (car != null)
                {
                    car.Name = oldCar.Name;
                    car.Model = oldCar.Model;
                    car.Manufacturer = oldCar.Manufacturer;
                    car.Price = oldCar.Price;
                    _dbContext.SaveChangesAsync();
                    _logger.LogInformation($"Update car '{oldCar.Name}' Succeeded");
                    return Task.FromResult(true);
                }
                else
                {
                    _logger.LogError($"car id:'{oldCar.Id}' not exists");
                    return Task.FromResult(false);
                }
            }

            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                return Task.FromResult(false);
            }
        }

        public Task<Car> GetCarById(int id)
        {
            try
            {
                var car = _dbContext.Cars.Where(b => b.Id == id).FirstOrDefault();
                if (car != null)
                {
                    _logger.LogInformation($"Get Car '{car.Name}' Succeeded");
                    return Task.FromResult(car);
                }
                else
                {
                    _logger.LogError($"'car id:{id}' not exists");
                    return Task.FromResult(new Car());
                }
            }

            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                return Task.FromResult(new Car());
            }
        }
    }
}
