using ServerCore.Infra;
using ServerCore.Models;
using ServerCore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCore.Services
{
    public class BeersService : IBeersService
    {
        private readonly BeersRepository _beersRepo;
        public BeersService(BeersRepository beersRepo)
        {
            _beersRepo = beersRepo;
        }
        public async Task<bool> AddBeerAsync(Beer newBeer)
        {
            return await _beersRepo.AddBeerAsync(newBeer);
        }

        public async Task<bool> DeleteBeerById(int id)
        {
            return await _beersRepo.DeleteBeerByIdAsync(id);
        }

        public async Task<IEnumerable<Beer>> GetAllBeersAsync()
        {
            return await _beersRepo.GetAllBeersAsync();
        }

        public async Task<Beer> GetBeerById(int id)
        {
            return await _beersRepo.GetBeerById(id);
        }

        public async Task<bool> UpdateBeerById(int id,Beer oldBeer)
        {
            return await _beersRepo.UpdateBeerById(id,oldBeer);
        }
    }
}
