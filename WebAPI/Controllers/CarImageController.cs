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

            if (result == "Success") // Bu kısmı gerçek sonucunuzun yapısına göre ayarlayın
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }

 }

