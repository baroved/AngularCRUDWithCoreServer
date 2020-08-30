using ServerCore.Infra;
using ServerCore.Models;
using ServerCore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCore.Services
{
    public class DogsService : IDogsService
    {
        private readonly DogsRepository _dogsRepository;

        public DogsService(DogsRepository dogsRepository)
        {
            _dogsRepository = dogsRepository;
        }
        public async Task<bool> AddDogAsync(Dog newDog)
        {
            return await _dogsRepository.AddDogAsync(newDog);
        }

        public async Task<bool> DeleteDogById(int id)
        {
            return await _dogsRepository.DeleteDogByIdAsync(id);
        }

        public async Task<IEnumerable<Dog>> GetAllDogsAsync()
        {
            return await _dogsRepository.GetAllDogsAsync();
        }

        public async Task<Dog> GetDogById(int id)
        {
            return await _dogsRepository.GetDogById(id);
        }

        public async Task<bool> UpdateDogById(int id,Dog oldDog)
        {
            return await _dogsRepository.UpdateDogById(id,oldDog);
        }
    }
}
