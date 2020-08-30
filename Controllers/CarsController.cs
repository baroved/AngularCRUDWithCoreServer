using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerCore.Infra;
using ServerCore.Models;


namespace ServerCore.Controllers
{
    
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarsService _carsService;
        public CarsController(ICarsService carsService)
        {
            _carsService = carsService;
        }
        // GET: api/Cars
        [HttpGet("GetAllCars")]
        public async Task<IEnumerable<Car>> GetAllCars()
        {
            return await _carsService.GetAllCarsAsync();
        }

        // GET: api/Cars/5
        [HttpGet("GetCar/{id}")]
        public async Task<Car> GetCarById(int id)
        {
            return await _carsService.GetCarById(id);
        }

        // POST: api/Cars
        [HttpPost("AddCar")]
        public async Task<bool> AddCar([FromBody] Car newCar)
        {
            return await _carsService.AddCarAsync(newCar);
        }

        // PUT: api/Cars/5
        [HttpPost("UpdateCar/{id}")]
        public async Task<bool> UpdateCarById(int id, [FromBody] Car updateCar)
        {
            return await _carsService.UpdateCarById(id, updateCar);
        }

        // DELETE: api/ApiWithActions/5
        [HttpPost("DeleteCar/{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _carsService.DeleteCarById(id);
        }
    }
}
