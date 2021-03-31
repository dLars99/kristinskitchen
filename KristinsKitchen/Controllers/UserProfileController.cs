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
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public UserProfileController(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var userProfile = _userProfileRepository.GetById(id);
            if (userProfile == null || !userProfile.IsActive)
            {
                return NotFound();
            }
            return Ok(userProfile);
        }

        [HttpPost]
        public IActionResult Post(UserProfile userProfile)
        {
            try
            {
                _userProfileRepository.Add(userProfile);
                return CreatedAtAction("Get", new { id = userProfile.Id }, userProfile);
            }
            catch
            {
                return StatusCode(500, "There was a problem creating this user.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UserProfile userProfile)
        {
            if (id != userProfile.Id)
            {
                return BadRequest("Invalid userProfile id");
            }

            if (!userProfile.IsActive)
            {
                return NotFound();
            }

            try
            {
                _userProfileRepository.Update(userProfile);
            }
            catch
            {
                return StatusCode(500, "There was a problem saving this user.");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var userProfile = _userProfileRepository.GetById(id);
            if (userProfile == null || !userProfile.IsActive)
            {
                return NotFound();
            }
            try
            {
                userProfile.Deactivate();
                _userProfileRepository.Update(userProfile);
            }
            catch
            {
                return StatusCode(500, "There was a problem deleting this user.");
            }

            return NoContent();
        }

    }
}
