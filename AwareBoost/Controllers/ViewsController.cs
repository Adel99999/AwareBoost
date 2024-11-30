using AwareBoost.Models;
using AwareBoost.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AwareBoost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ViewsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Add a view for a question
        [HttpPost("{questionId:guid}")]
        public async Task<IActionResult> AddView(Guid questionId)
        {
            // Check if the question exists
            var question = await _unitOfWork.QuestionsRepo.GetAsync(q => q.Id == questionId);

            if (question == null)
                return NotFound("Question not found.");

            // Create a new view entry
            var view = new Views
            {
                Id = Guid.NewGuid(),
                QuesitonId = questionId
            };

            // Add the view to the repository
            await _unitOfWork.ViewsRepo.AddAsync(view);

            return Ok(new { Message = "View added successfully!" });
        }

    }
}
