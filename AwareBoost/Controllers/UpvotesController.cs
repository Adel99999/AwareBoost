using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using AwareBoost.UnitOfWork;
using AwareBoost.Models;
using System.Security.Claims;

namespace AwareBoost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpvoteController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpvoteController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Toggle upvote for an answer
        [HttpPost("{answerId:guid}")]
        public async Task<IActionResult> ToggleUpvote(Guid answerId)
        {
            // Get the currently logged-in user ID
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
                return Unauthorized("User is not authenticated.");

            // Check if the answer exists
            var answer = await _unitOfWork.AnswerRepo.GetAsync(a => a.Id == answerId);
            if (answer == null)
                return NotFound("Answer not found.");

            // Check if the upvote already exists for the user and answer
            var existingUpvote = await _unitOfWork.UpvoteRepo.GetAsync(
                u => u.AnswerId == answerId && u.AppUserId == userId);

            if (existingUpvote != null)
            {
                // Remove the upvote if it exists (toggle off)
                await _unitOfWork.UpvoteRepo.RemoveAsync(existingUpvote);


                return Ok(new { Message = "Upvote removed." });
            }

            // Create a new upvote (toggle on)
            var upvote = new Upvote
            {
                Id = Guid.NewGuid(),
                AppUserId = userId,
                AnswerId = answerId
            };

            await _unitOfWork.UpvoteRepo.AddAsync(upvote);


            return Ok(new { Message = "Upvote added." });
        }
    }
}
