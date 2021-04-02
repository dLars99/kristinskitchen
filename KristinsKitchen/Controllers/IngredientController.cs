using KristinsKitchen.Models;
using KristinsKitchen.Repositories;
using KristinsKitchen.Utils;
using Microsoft.AspNetCore.Mvc;
using System;

namespace KristinsKitchen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IIngredientsDBRepository _ingredientsDBRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IUserProfileRepository _userProfileRepository;

        public IngredientController(IIngredientRepository ingredientRepository,
                                    IIngredientsDBRepository ingredientsDBRepository,
                                    ILocationRepository locationRepository,
                                    IUserProfileRepository userProfileRepository)
        {
            _ingredientRepository = ingredientRepository;
            _ingredientsDBRepository = ingredientsDBRepository;
            _locationRepository = locationRepository;
            _userProfileRepository = userProfileRepository;
        }

        [HttpGet]
        public IActionResult GetByUser(int userId)
        {
            var userProfile = _userProfileRepository.GetById(userId);
            if (userProfile == null || !userProfile.IsActive)
            {
                return BadRequest("Invalid user Id");
            }
            return Ok(_ingredientRepository.GetAllByUser(userId));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var ingredient = _ingredientRepository.GetById(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            return Ok(ingredient);
        }

        [HttpPost]
        public IActionResult Post(Ingredient ingredient)
        {
            var ingredientsDB = _ingredientsDBRepository.GetById(ingredient.IngredientsDBId);
            var location = _locationRepository.GetById(ingredient.LocationId);
            var userProfile = _userProfileRepository.GetById(ingredient.UserProfileId);
            var validationError = Validations.ValidateUserIngredient(ingredient, ingredientsDB, location, userProfile);
            if (!String.IsNullOrEmpty(validationError))
            {
                return BadRequest(validationError);
            }

            try
            {
                _ingredientRepository.Add(ingredient);
                return CreatedAtAction("Get", new { id = ingredient.Id }, ingredient);
            }
            catch
            {
                return StatusCode(500, "There was a problem saving this ingredient.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Ingredient ingredient)
        {
            if (id != ingredient.Id)
            {
                return BadRequest("Invalid ingredient id");
            }

            var ingredientsDB = _ingredientsDBRepository.GetById(ingredient.IngredientsDBId);
            var location = _locationRepository.GetById(ingredient.LocationId);
            var userProfile = _userProfileRepository.GetById(ingredient.UserProfileId);
            var validationError = Validations.ValidateUserIngredient(ingredient, ingredientsDB, location, userProfile);
            if (!String.IsNullOrEmpty(validationError))
            {
                return BadRequest(validationError);
            }

            // Reset negative quantities to zero
            // CONSIDER: delete ingredients with an OwnQuantity <= 0
            ingredient.OwnQuantity = ingredient.OwnQuantity < 0 ? 0 : ingredient.OwnQuantity;

            try
            {
                _ingredientRepository.Update(ingredient);
            }
            catch
            {
                return StatusCode(500, "There was a problem saving this ingredient.");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ingredient = _ingredientRepository.GetById(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            try
            {
                _ingredientRepository.Delete(id);
            }
            catch
            {
                return StatusCode(500, "There was a problem deleting this ingredient.");
            }

            return NoContent();
        }
    }
}
