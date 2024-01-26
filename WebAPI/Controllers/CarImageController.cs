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
        public async Task<IActionResult> AddCarImage(CarİmageDTO imageDto)
        {
            var result = await _carImageService.AddCarImage(imageDto);

            return Ok(result);

        }  

    }
}
