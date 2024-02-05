using API.DTOs;
using API.Filters.ActionFilters;
using API.Filters.ExceptionFilters;
using API.Models.Shirt.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetShirts()
        {
            return Ok(ShirtRepository.GetShirts());
        }
        [HttpGet("{id}")]
        [Shirt_ValidateShirtIdFilter]
        public IActionResult GetShirtById(int id)
        {
            return Ok(ShirtRepository.GetShirtById(id));
        }
        [HttpPost]
        [Shirt_ValidateCreateShirtFilter]
        public IActionResult CreateShirt([FromBody] ShirtDto shirt)
        {
            ShirtRepository.AddShirt(shirt);

            return CreatedAtAction(nameof(GetShirtById), new { id = shirt.Id }, shirt);
        }
        [HttpPut("{id}")]
        [Shirt_ValidateShirtIdFilter]
        [Shirt_ValidateUpdateShirtFilter]
        [Shirt_HandleUpdateExceptionsFilter]
        public IActionResult UpdateShirt(int id, ShirtDto shirt)
        {
            ShirtRepository.UpdateShirt(shirt);
            return NoContent();
        }
        [HttpDelete("{id}")]
        [Shirt_ValidateShirtIdFilter]
        public IActionResult DeleteShirt(int id)
        {
            var shirt = ShirtRepository.GetShirtById(id);
            ShirtRepository.DeleteShirt(id);
            return Ok(shirt);
        }
    }
}
