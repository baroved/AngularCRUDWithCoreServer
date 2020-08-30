using ServerCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCore.Infra
{
    public interface IBeersService
    {
        Task<IEnumerable<Beer>> GetAllBeersAsync();
        Task<bool> AddBeerAsync(Beer newBeer);
        Task<bool> DeleteBeerById(int id);
        Task<bool> UpdateBeerById(int id,Beer oldBeer);
        Task<Beer> GetBeerById(int id);
    }
}
