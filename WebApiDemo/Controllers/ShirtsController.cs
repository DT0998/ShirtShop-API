using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController : ControllerBase
    {
        [HttpGet]
        public string GetShirts()
        {
            return "Reading all the shirts";
        }
        [HttpGet("{id}")]
        public string GetShirtById(int id, [FromQuery] string color)
        {
            return $"Reading shirt: {id},color: {color}";
        }
        [HttpPost]
        public string CreateShirt([FromBody] Shirt shirt)
        {
            return $"Creating a shirt";
        }
        [HttpPut("{id}")]
        public string UpdateShirt(int id)
        {
            return $"Updating shirt: {id}";
        }
        [HttpDelete("{id}")]
        public string DeleteShirt(int id)
        {
            return $"Delete Shirt: {id}";
        }
    }
}
