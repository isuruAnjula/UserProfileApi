using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UserProfileApi.Domain.Interfaces;

namespace UserProfileApiCleanArc.Controllers
{
    [ApiController]
    // Set url route
    [Route("api/[controller]")]

    // Inherit from ControllerBase
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileService userProfService;

        public UserProfileController(IUserProfileService service)
        {
            userProfService = service;
        }

        // GET user by userId
        [HttpGet("by-id")]
        [Authorize]
        public IActionResult GetByUserId()
        {

            //Get userId from logged in user info
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (userId == null || userId == "")
            {
                return Unauthorized();
            }

            var user = userProfService.GetByUserId(userId);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // GET user by email
        [HttpGet("by-email")]
        [Authorize]
        public IActionResult GetByEmail()
        {
            var emailCl = User.FindFirst(ClaimTypes.Email);

            if (emailCl == null)
            {
                return Unauthorized();
            }

            string email = emailCl.Value;

            var user = userProfService.GetByEmail(email);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
