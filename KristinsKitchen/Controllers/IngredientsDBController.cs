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
            return Ok(_ingredientsDBRepository.GetAllIngredients());
        }
    }
}
