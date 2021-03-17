using KristinsKitchen.Models;
using KristinsKitchen.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KristinsKitchen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsDBController : ControllerBase
    {
        private readonly IIngredientsDBRepository _ingredientsDBRepository;

        public IngredientsDBController(IIngredientsDBRepository ingredientsDBRepository)
        {
            _ingredientsDBRepository = ingredientsDBRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_ingredientsDBRepository.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var ingredient = _ingredientsDBRepository.GetById(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            return Ok(ingredient);
        }
        [HttpPost]
        public IActionResult Post(IngredientsDB ingredient)
        {
            if (ingredient.PantryShelfLife <= -1 && ingredient.FridgeShelfLife <= -1 && ingredient.FreezerShelfLife <= -1)
            {
                return BadRequest("Cannot add ingredient to database without an expiration date in at least one storage location.");
            }
            if (ingredient.CategoryId < 1 || ingredient.CategoryId > 3)
            {
                return BadRequest("Cannot add ingredient to database without a valid category.");
            }
            if (ingredient.Quantity < 0)
            {
                return BadRequest("Default ingredient quantity cannot be negative.");
            }

            try
            {
                _ingredientsDBRepository.Add(ingredient);
                return CreatedAtAction("Get", new { id = ingredient.Id }, ingredient);
            }
            catch
            {
                return StatusCode(500, "There was a problem saving this ingredient.");
            }
        }
    }
}
