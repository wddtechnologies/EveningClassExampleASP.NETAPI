using EveningWebAPIExample.Filters;
using EveningWebAPIExample.Filters.ActionFilters;
using EveningWebAPIExample.Filters.ExceptionFilters;
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
        public IActionResult CreateShirt([FromForm] Shirt shirt)
        {
            //if (shirt == null) return BadRequest();
            //var existingShirt = ShirtRepository.GetShirtByProperties(shirt.Brand, shirt.Gender, shirt.Color, shirt.Size);
            //if (existingShirt != null) return BadRequest();
            ShirtRepository.AddShirt(shirt);
            return CreatedAtAction(nameof(GetShirtById),
                new { id = shirt.Id },
                shirt);

           // return Ok("this is to create a shirt");
        }
        [HttpPut("{id}")]
        [Shirt_ValidateShirtIdFilter]
        [Shirt_ValidateUpdateShirtFilter]
        [Shirt_HandleUpdateExceptionsFilter]
        public IActionResult UpdateShirt(int id, Shirt shirt)
        {
            
            ShirtRepository.UpdateShirt(shirt);
            return NoContent();
        }
        [HttpDelete("{id}")]
        [Shirt_ValidateShirtIdFilter]
        public IActionResult DeleteShirt(int id)
        {
            var shirt = ShirtRepository.GetShirtById(id);
            ShirtRepository.Deleteshirt(id);
            return Ok(shirt);
        }

    }
}

