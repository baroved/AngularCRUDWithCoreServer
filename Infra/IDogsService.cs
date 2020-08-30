using ServerCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCore.Infra
{
    public interface IDogsService
    {
        Task<IEnumerable<Dog>> GetAllDogsAsync();
        Task<bool> AddDogAsync(Dog newDog);
        Task<bool> DeleteDogById(int id);
        Task<bool> UpdateDogById(int id,Dog oldDog);
        Task<Dog> GetDogById(int id);
    }
}
