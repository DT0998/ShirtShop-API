using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Models;
using WebApiDemo.Models.Repositories;

namespace WebApiDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetShirts()
        {
            return Ok("Reading all the shirts");
        }
        [HttpGet("{id}")]
        public IActionResult GetShirtById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var shirt = ShirtRepository.GetShirtById(id);
            if (shirt == null)
            {
                return NotFound();
            }
            return Ok(shirt);
        }
        [HttpPost]
        public IActionResult CreateShirt([FromBody] Shirt shirt)
        {
            return Ok($"Creating a shirt");
        }
        [HttpPut("{id}")]
        public IActionResult UpdateShirt(int id)
        {
            return Ok($"Updating shirt: {id}");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteShirt(int id)
        {
            return Ok($"Delete Shirt: {id}");
        }
    }
}
