using ServerCore.Infra;
using ServerCore.Models;
using ServerCore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCore.Services
{
    public class CarsService : ICarsService
    {
        private readonly CarsRepository _carsRepo;

        public CarsService(CarsRepository carsRepo)
        {
            _carsRepo = carsRepo;
        }
        public async Task<bool> AddCarAsync(Car newCar)
        {
            return await _carsRepo.AddCarAsync(newCar);
        }

        public async Task<bool> DeleteCarById(int id)
        {
            return await _carsRepo.DeleteCarByIdAsync(id);
        }

        public async Task<IEnumerable<Car>> GetAllCarsAsync()
        {
            return await _carsRepo.GetAllCarsAsync();
        }

        public async Task<Car> GetCarById(int id)
        {
            return await _carsRepo.GetCarById(id);
        }

        public async Task<bool> UpdateCarById(int id,Car oldCar)
        {
            return await _carsRepo.UpdateCarById(id,oldCar);
        }
    }
}
