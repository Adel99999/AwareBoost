using AwareBoost.Dtos;
using AwareBoost.Models;
using AwareBoost.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AwareBoost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BadgesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BadgesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Get all badges
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllBadges()
        {
            var badges = await _unitOfWork.BadgesRepo.GetAllAsync();
            return Ok(badges);
        }

        // Get a specific badge by ID
        [HttpGet("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> GetBadgeById(Guid id)
        {
            var badge = await _unitOfWork.BadgesRepo.GetAsync(b => b.Id == id);
            if (badge == null)
                return NotFound("Badge not found.");

            return Ok(badge);
        }

        // Add a new badge
        [HttpPost]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> AddBadge([FromBody] AddBadgeRequestDto badgeDto)
        {
            if (badgeDto == null)
                return BadRequest("Badge data is required.");

            var badge = new Badges
            {
                Id = Guid.NewGuid(),
                Name = badgeDto.Name,
                Description = badgeDto.Description,
                Icon = badgeDto.Icon
            };

            await _unitOfWork.BadgesRepo.AddAsync(badge);

            return Ok(new { Message = "Badge added successfully.", Badge = badge });
        }

        // Update an existing badge
        [HttpPut("{id:guid}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> UpdateBadge(Guid id, [FromBody] AddBadgeRequestDto badgeDto)
        {
            var existingBadge = await _unitOfWork.BadgesRepo.GetAsync(b => b.Id == id);
            if (existingBadge == null)
                return NotFound("Badge not found.");

            existingBadge.Name = badgeDto.Name;
            existingBadge.Description = badgeDto.Description;
            existingBadge.Icon = badgeDto.Icon;

            await _unitOfWork.BadgesRepo.UpdateAsync(existingBadge);

            return Ok(new { Message = "Badge updated successfully.", Badge = existingBadge });
        }

        // Delete a badge
        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteBadge(Guid id)
        {
            var badge = await _unitOfWork.BadgesRepo.GetAsync(b => b.Id == id);
            if (badge == null)
                return NotFound("Badge not found.");

            await _unitOfWork.BadgesRepo.RemoveAsync(badge);

            return Ok(new { Message = "Badge deleted successfully." });
        }
    }
}
