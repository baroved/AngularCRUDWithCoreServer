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
    public class DogsController : ControllerBase
    {
        private readonly IDogsService _dogsService;
        public DogsController(IDogsService dogsService)
        {
            _dogsService = dogsService;
        }
        // GET: api/Dogs
        [HttpGet("GetAllDogs")]
        public async Task<IEnumerable<Dog>> GetAllDogs()
        {
            return await _dogsService.GetAllDogsAsync();
        }

        // GET: api/Dogs/5
        [HttpGet("GetDog/{id}")]
        public async Task<Dog> GetDogById(int id)
        {
            return await _dogsService.GetDogById(id);
        }

        // POST: api/Dogs
        [HttpPost("AddDog")]
        public async Task<bool> AddDog([FromBody] Dog newDog)
        {
            return await _dogsService.AddDogAsync(newDog);
        }

        // PUT: api/Dogs/5
        [HttpPost("UpdateDog/{id}")]
        public async Task<bool> UpdateDogById(int id, [FromBody] Dog updateDog)
        {
            return await _dogsService.UpdateDogById(id, updateDog);
        }

        // DELETE: api/ApiWithActions/5
        [HttpPost("DeleteDog/{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _dogsService.DeleteDogById(id);
        }
    }
}
