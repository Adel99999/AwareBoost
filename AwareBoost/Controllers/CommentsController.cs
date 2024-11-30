using AwareBoost.Dtos;
using AwareBoost.Models;
using AwareBoost.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AwareBoost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Get All Comments for a Specific Answer
        [Route("get-comments/{answerId}")]
        [HttpGet]
        public async Task<IActionResult> GetComments(Guid answerId)
        {
            var comments = await _unitOfWork.CommentsRepo.GetAllAsync(c => c.AnswerId == answerId);

            if (comments == null || !comments.Any())
            {
                return NotFound("No comments found for this answer.");
            }

            return Ok(comments);
        }

        // Add a Comment
        [Route("add-comment")]
        [HttpPost]
        [Authorize(Roles="User,SepcialUser")] // Ensure the user is authenticated
        public async Task<IActionResult> AddComment([FromBody] AddCommentRequestDto commentDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return Unauthorized("User is not authenticated.");
            }

            var comment = new Comments
            {
                Id = Guid.NewGuid(),
                Comment = commentDto.Comment,
                AnswerId = commentDto.AnswerId,
                AppUserId = userId,
                Created_At = DateTime.UtcNow
            };

            await _unitOfWork.CommentsRepo.AddAsync(comment);

            return Ok(new { Message = "Comment added successfully!" });
        }

        // Update a Comment
        [Route("update-comment/{id}")]
        [HttpPut]
        [Authorize(Roles="User,SpecialUser")] // Ensure the user is authenticated
        public async Task<IActionResult> UpdateComment(Guid id, [FromBody] AddCommentRequestDto commentDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return Unauthorized("User is not authenticated.");
            }

            var comment = await _unitOfWork.CommentsRepo.GetAsync(
                c => c.Id == id && c.AppUserId == userId,
                include: null
            );

            if (comment == null)
            {
                return NotFound("Comment not found or you're not authorized to update this comment.");
            }

            comment.Comment = commentDto.Comment;

            await _unitOfWork.CommentsRepo.UpdateAsync(comment);

            return Ok(new { Message = "Comment updated successfully!" });
        }

        // Delete a Comment
        [Route("delete-comment/{id}")]
        [HttpDelete]
        [Authorize(Roles="User,SpecialUser")] // Ensure the user is authenticated
        public async Task<IActionResult> DeleteComment(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return Unauthorized("User is not authenticated.");
            }

            var comment = await _unitOfWork.CommentsRepo.GetAsync(
                c => c.Id == id && c.AppUserId == userId,
                include: null
            );

            if (comment == null)
            {
                return NotFound("Comment not found or you're not authorized to delete this comment.");
            }

            await _unitOfWork.CommentsRepo.RemoveAsync(comment);

            return Ok(new { Message = "Comment deleted successfully!" });
        }
    }
}
