using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using AwareBoost.UnitOfWork;
using AwareBoost.Models;
using AwareBoost.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace AwareBoost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Get all categories
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _unitOfWork.CategoryRepo.GetAllAsync();
            return Ok(categories);
        }

        // Get a specific category by ID
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            var category = await _unitOfWork.CategoryRepo.GetAsync(c => c.Id == id);

            if (category == null)
                return NotFound("Category not found.");

            return Ok(category);
        }

        // Add a new category
        [HttpPost]
        [Authorize(Roles = "Admin")] // Ensure only admins can add categories
        public async Task<IActionResult> AddCategory([FromBody] AddCategoryRequestDto categoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = categoryDto.Name,
            };

            await _unitOfWork.CategoryRepo.AddAsync(category);


            return Ok(new { Message = "Category added successfully!", Category = category });
        }

     

        // Delete a category
        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Admin")] // Ensure only admins can delete categories
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var category = await _unitOfWork.CategoryRepo.GetAsync(c => c.Id == id);

            if (category == null)
                return NotFound("Category not found.");

            await _unitOfWork.CategoryRepo.RemoveAsync(category);
            

            return Ok(new { Message = "Category deleted successfully!" });
        }
    }
}
