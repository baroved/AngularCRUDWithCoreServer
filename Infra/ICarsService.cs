using ServerCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCore.Infra
{
    public interface ICarsService
    {
        Task<IEnumerable<Car>> GetAllCarsAsync();
        Task<bool> AddCarAsync(Car newCar);
        Task<bool> DeleteCarById(int id);
        Task<bool> UpdateCarById(int id,Car oldCar);
        Task<Car> GetCarById(int id);
    }
}
