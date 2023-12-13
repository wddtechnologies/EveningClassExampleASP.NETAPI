using EveningWebAPIExample.Models;
using EveningWebAPIExample.Models.Respositories;
using Microsoft.AspNetCore.Mvc;

namespace EveningWebAPIExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsControllercs : ControllerBase
    {

        [HttpGet]
        public string GetShirts()
        {
            return " Reading all the shirts";
        }
        [HttpGet("{id}")]
        public IActionResult GetShirtsById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var shirt = ShirtRepository.GetShirtById(id);
            if (shirt != null)
            {
                return NotFound();
            }
            return Ok(shirt);
        }
    
        [HttpPost]
        public string CreateShirt([FromForm] Shirt shirt)
        {
            return $"Creating a shirt";
        }
        [HttpPut("{id}")]
        public string UpdateShirt(int id)
        {
            return $"Updating shirt: , {id}";
        }
        [HttpDelete("{id}")]
        public string DeleteShirt(int id)
        {
            return $"Deleting shirt: , {id}";
        }

    }
}

