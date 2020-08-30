using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerCore.Infra;
using ServerCore.Models;

namespace ServerCore.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BeersController : ControllerBase
    {
        private readonly IBeersService _beersService;
        public BeersController(IBeersService beersService)
        {
            _beersService = beersService;
        }
        // GET: api/Beers
        [HttpGet("GetAllBeers")]
        public async Task<IEnumerable<Beer>> GetAllBeers()
        {
            return await _beersService.GetAllBeersAsync();
        }

        // GET: api/Beers/5
        [HttpGet("GetBeer/{id}")]
        public async Task<Beer> GetBeerById(int id)
        {
            return await _beersService.GetBeerById(id);
        }

        // POST: api/Beer
        [HttpPost("AddBeer")]
        public async Task<bool> AddBeer([FromBody] Beer newBeer)
        {
            return await _beersService.AddBeerAsync(newBeer);
        }

        // PUT: api/Beer/5
        [HttpPost("UpdateBeer/{id}")]
        public async Task<bool> UpdateBeerById(int id, [FromBody] Beer updateBeer)
        {
            return await _beersService.UpdateBeerById(id, updateBeer);
        }

        // DELETE: api/ApiWithActions/5
        [HttpPost("DeleteBeer/{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _beersService.DeleteBeerById(id);
        }
    }
}
