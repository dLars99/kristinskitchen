using KristinsKitchen.Models;
using KristinsKitchen.Repositories;
using KristinsKitchen.Utils;
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
            var validationError = Validations.ValidateIngredient(ingredient);
            if (!String.IsNullOrEmpty(validationError))
            {
                return BadRequest(validationError);
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

        [HttpPut("{id}")]
        public IActionResult Put(int id, IngredientsDB ingredient)
        {
            if (id != ingredient.Id)
            {
                return BadRequest("Invalid ingredient id");
            }

            var validationError = Validations.ValidateIngredient(ingredient);
            if (!String.IsNullOrEmpty(validationError))
            {
                return BadRequest(validationError);
            }

            _ingredientsDBRepository.Update(ingredient);

            return NoContent();
        }
    }
}
