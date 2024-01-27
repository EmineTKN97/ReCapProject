using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImageController : ControllerBase
    {
        ICarImageService _carImageService;

        public CarImageController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }
        [HttpPost("AddCarImage")]
        public async Task<IActionResult> AddCarImage(IFormFile file, int carId)
        {
            var result = await _carImageService.AddCarImage(file, carId);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
        [HttpGet("GetCarImageById")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAllCarImage")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }
        [HttpDelete("DeleteCarImage")]
        public IActionResult DeleteCarImage(int İmageId)
        {
            var result = _carImageService.DeleteCarImage(İmageId);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result);
        }
        [HttpPut("UpdateCarImage")]
        public async Task<IActionResult> UpdateCarImage(int ıd, IFormFile file)
        {
            var result = await _carImageService.UpdateCarImage(file, ıd);
            if (result.Success)
            {
            return Ok(result.Message);

            }
            return BadRequest(result.Message);

        }

    }

}

