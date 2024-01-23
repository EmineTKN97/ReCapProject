using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }
            [HttpGet("GetById")]
            public IActionResult GetById(int id)
            {
                var result = _rentalService.GetById(id);
                if (result.Success)
                {
                    return Ok(result.Data);
                }
                return BadRequest(result);
            }

            [HttpGet("GetAll")]
            public IActionResult GetAll()
            {
                var result = _rentalService.GetAll();
                if (result.Success)
                {
                    return Ok(result.Data);
                }
                return BadRequest(result);
            }
            [HttpPost("AddRental")]
            public IActionResult AddRental(Rental rental)
            {
                var result = _rentalService.AddRental(rental);
                if (result.Success)
                {
                    return Ok(result.Message);
                }
                return BadRequest(result);
            }
            [HttpPut("UpdateRental")]
            public IActionResult UpdateRental(Rental rental)
            {
                var result = _rentalService.UpdateRental(rental);
                if (result.Success)
                {
                    return Ok(result.Message);
                }
                return BadRequest(result);
            }
            [HttpDelete("DeleteRental")]
            public IActionResult DeleteRental(int id)
            {
                var result = _rentalService.DeleteRental(id);
                if (result.Success)
                {
                    return Ok(result.Message);
                }
                return BadRequest(result);
            }

        }
}
