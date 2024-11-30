using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using AwareBoost.UnitOfWork;
using AwareBoost.Models;
using AwareBoost.Dtos;
using Microsoft.AspNetCore.Authorization;
using Azure;

namespace AwareBoost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TagController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")] // Ensure only admins can add tags
        public async Task<IActionResult> AddTag([FromBody] AddTagRequestDto tagDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var tag = new Tags
            {
                Id = Guid.NewGuid(),
                TagName = tagDto.TagName,
            };

            await _unitOfWork.TagsRepo.AddAsync(tag);

            return Ok(new { Message = "Tag added successfully!", Tag = tag });
        }

       

        // Delete a tag
        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Admin")] // Ensure only admins can delete tags
        public async Task<IActionResult> DeleteTag(Guid id)
        {
            var tag = await _unitOfWork.TagsRepo.GetAsync(t => t.Id == id);

            if (tag == null)
                return NotFound("Tag not found.");

            await _unitOfWork.TagsRepo.RemoveAsync(tag);


            return Ok(new { Message = "Tag deleted successfully!" });
        }
    }
}
