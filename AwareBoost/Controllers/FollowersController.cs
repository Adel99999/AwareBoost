using AwareBoost.Models;
using AwareBoost.Repository;
using AwareBoost.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AwareBoost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public FollowerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("follow/{specialUserId}")]
        [Authorize] // Ensure the user is authenticated
        public async Task<IActionResult> Follow(string specialUserId)
        {
            // Get the currently logged-in user's ID
            var followerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (followerId == null)
            {
                return Unauthorized("User is not authenticated.");
            }

            if (string.IsNullOrEmpty(specialUserId))
            {
                return BadRequest("Special user ID is required.");
            }

            // Check if the follower already follows the special user
            var existingFollow = await _unitOfWork.FollowersRepo.GetAsync(
                f => f.FollowerId == followerId && f.SpecialUserId == specialUserId);

            if (existingFollow != null)
            {
                return BadRequest("You are already following this special user.");
            }

            // Create the new follower relationship
            var follower = new Followers
            {
                Id = Guid.NewGuid(),
                SpecialUserId = specialUserId,
                FollowerId = followerId
            };

            // Add the follower to the database
            await _unitOfWork.FollowersRepo.AddAsync(follower);


            return Ok(new { Message = "You are now following this special user!" });
        }
    }
}
