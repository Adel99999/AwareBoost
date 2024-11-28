using AwareBoost.Dtos;
using AwareBoost.Models;
using AwareBoost.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AwareBoost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public AnswersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("add-answer")]
        [HttpPost]
        [Authorize(Roles = "SpecialUser")]  // Ensure the user is a SpecialUser
        public async Task<IActionResult> AddAnswer([FromBody] AddAnswerRequestDto answerDto)
        {
            // Get the currently logged-in user (assuming they're authenticated)
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);  // Get user ID from claims

            if (userId == null)
            {
                return Unauthorized("User is not authenticated.");
            }

            var answer = new Answers
            {
                Id = Guid.NewGuid(),
                Answer= answerDto.Answer,
                QuestionId = answerDto.QuestionId,
                AppUserId = userId,  // Assuming UserId is a GUID
                Created_At = DateTime.UtcNow
            };

            // Add the answer to the repository
            await _unitOfWork.AnswerRepo.AddAsync(answer);

            return Ok(new { Message = "Answer added successfully!" });
        }


        [Route("update-answer/{id}")]
        [HttpPut]
        [Authorize(Roles = "SpecialUser")]  // Ensure the user is a SpecialUser
        public async Task<IActionResult> UpdateAnswer(Guid id, [FromBody] AddAnswerRequestDto answerDto)
        {
            // Get the currently logged-in user (assuming they're authenticated)
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);  // Get user ID from claims

            if (userId == null)
            {
                return Unauthorized("User is not authenticated.");
            }

            // Retrieve the answer to be updated using the provided ID and the logged-in user's ID
            var answer = await _unitOfWork.AnswerRepo.GetAsync(
                a => a.Id == id && a.AppUserId == userId, // Ensure the answer exists and belongs to the logged-in user
                include: null // We don't need any related entities for this operation
            );

            if (answer == null)
            {
                return NotFound("Answer not found or you're not authorized to update this answer.");
            }

            // Update the answer content
            answer.Answer = answerDto.Answer;

            // Update the answer in the repository
            await _unitOfWork.AnswerRepo.UpdateAsync(answer);

            return Ok(new { Message = "Answer updated successfully!" });
        }

        [Route("delete-answer/{id}")]
        [HttpDelete]
        [Authorize(Roles = "SpecialUser")]  // Ensure the user is a SpecialUser
        public async Task<IActionResult> DeleteAnswer(Guid id)
        {
            // Get the currently logged-in user (assuming they're authenticated)
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);  // Get user ID from claims

            if (userId == null)
            {
                return Unauthorized("User is not authenticated.");
            }

            // Retrieve the answer to be deleted using the provided ID and the logged-in user's ID
            var answer = await _unitOfWork.AnswerRepo.GetAsync(
                a => a.Id == id && a.AppUserId == userId, // Ensure the answer exists and belongs to the logged-in user
                include: null // We don't need any related entities for this operation
            );

            if (answer == null)
            {
                return NotFound("Answer not found or you're not authorized to delete this answer.");
            }

            // Delete the answer from the repository
            await _unitOfWork.AnswerRepo.RemoveAsync(answer);

            return Ok(new { Message = "Answer deleted successfully!" });
        }


    }
}

