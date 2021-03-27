using KristinsKitchen.Models;
using KristinsKitchen.Repositories;
using KristinsKitchen.Utils;
using Microsoft.AspNetCore.Mvc;
using System;

namespace KristinsKitchen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsDBController : ControllerBase
    {
        private readonly IIngredientsDBRepository _ingredientsDBRepository;
        private readonly ICategoryRepository _categoryRepository;

        public IngredientsDBController(IIngredientsDBRepository ingredientsDBRepository,
                                       ICategoryRepository categoryRepository)
        {
            _ingredientsDBRepository = ingredientsDBRepository;
            _categoryRepository = categoryRepository;
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
            var category = _categoryRepository.GetById(ingredient.CategoryId);
            var validationError = Validations.ValidateIngredient(ingredient, category);
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

            var category = _categoryRepository.GetById(ingredient.CategoryId);
            var validationError = Validations.ValidateIngredient(ingredient, category);
            if (!String.IsNullOrEmpty(validationError))
            {
                return BadRequest(validationError);
            }

            try
            {
                _ingredientsDBRepository.Update(ingredient);
            }
            catch
            {
                return StatusCode(500, "There was a problem saving this ingredient.");
            }


            return NoContent();
        }
    }
}
