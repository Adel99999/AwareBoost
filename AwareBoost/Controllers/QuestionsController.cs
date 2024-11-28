using AwareBoost.Dtos;
using AwareBoost.Models;
using AwareBoost.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using newzelandWalks.CustomActionFilter;
using System.Security.Claims;

namespace AwareBoost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public QuestionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("all")]
        [HttpGet]
        public async Task<IActionResult> GetAllQuestions()
        {
            var questions = await _unitOfWork.QuestionsRepo.GetAllAsync();

            var questionsDto = questions.Select(async q => new QuestionDto
            {
                Id = q.Id,
                Title = q.Title,
                Content = q.Content,
                Created_At = q.Created_At,
                UserName = q.User.UserName,
                CategoryName = q.Category.Name,
                Tags = q.Tags.Select(t => t.TagName).ToList(),
                AnswerCount = await _unitOfWork.AnswerRepo.CountAnswersByQuestionIdAsync(q.Id),
                ViewCount = await _unitOfWork.ViewsRepo.CountViewsByQuestionIdAsync(q.Id)
            });

            return Ok(questionsDto);
        }
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetQuestion(Guid id)
        {
            var question = await _unitOfWork.QuestionsRepo.GetAsync(
                q => q.Id == id,
                include: q => q.Include(q => q.User)
                               .Include(q => q.Category)
            );

            if (question == null)
            {
                return NotFound(new { Message = "Question not found" });
            }

            var answers = await _unitOfWork.AnswerRepo.GetAnswersByQuestionIdAsync(id);

            // Use Task.WhenAll to handle async calls in the Select
            var answersDto = await Task.WhenAll(
                answers.Select(async a => new AnswerDto
                {
                    Id = a.Id,
                    Answer = a.Answer,
                    Created_At = a.Created_At,
                    UserName = a.User.UserName,
                    UpvotesCount = await _unitOfWork.UpvoteRepo.CountUpvotesByAnswerIdAsync(a.Id),
                })
            );

            var questionDto = new DetailedQuestionDto
            {
                Id = question.Id,
                Title = question.Title,
                Content = question.Content,
                Created_At = question.Created_At,
                UserName = question.User.UserName,
                CategoryName = question.Category.Name,
                Answers = answersDto.ToList()
            };

            return Ok(questionDto);
        }


        [Route("add")]
        [HttpPost]
        [ValidateMode]
        [Authorize(Roles="User")]
        public async Task<IActionResult> AddQuestion([FromBody] AddQuestionRequestDto requestDto)
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

 
            var question = new Questions
            {
                Id=Guid.NewGuid(),
                Title = requestDto.Title,
                Content = requestDto.Content,
                Created_At = DateTime.UtcNow,
                AppUserId = userId, 
                CategoryId = requestDto.CategoryId
            };


            await _unitOfWork.QuestionsRepo.AddAsync(question);

            if (requestDto.Tags != null && requestDto.Tags.Any())
            {
                var tags = await _unitOfWork.TagsRepo.GetTagsByNamesAsync(requestDto.Tags);

                var questionTags = tags.Select(tag => new QuestionsTags
                {
                    QuestionId = question.Id,
                    TagId = tag.Id
                }).ToList();

                await _unitOfWork.QuestionsTagsRepo.AddRangeAsync(questionTags);
            }

            return Ok(new { Message = "Question created successfully." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(Guid id)
        {
            var question = await _unitOfWork.QuestionsRepo.GetAsync(q => q.Id == id);
            if (question == null)
            {
                return NotFound(new { Message = "Question not found" });
            }

            await _unitOfWork.QuestionsRepo.RemoveAsync(question);
            

            return Ok(new { Message = "Question deleted successfully" });
        }

        [HttpPut("{id}")]
        [ValidateMode]
        [Authorize(Roles="Admin,User")]
        public async Task<IActionResult> UpdateQuestion(Guid id, [FromBody] AddQuestionRequestDto requestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingQuestion = await _unitOfWork.QuestionsRepo.GetAsync(q => q.Id == id, include: q => q.Include(q => q.Tags));
            if (existingQuestion == null)
            {
                return NotFound(new { Message = "Question not found" });
            }

            
            existingQuestion.Title = requestDto.Title;
            existingQuestion.Content = requestDto.Content;
            existingQuestion.CategoryId = requestDto.CategoryId;

            
            if (requestDto.Tags != null && requestDto.Tags.Any())
            {
                var tags = await _unitOfWork.TagsRepo.GetAllAsync(t => requestDto.Tags.Contains(t.TagName));
                existingQuestion.Tags = tags.ToList();
            }
            else
            {
                existingQuestion.Tags = new List<Tags>(); // Clear tags if no tags provided
            }

            await _unitOfWork.QuestionsRepo.UpdateAsync(existingQuestion);

            return Ok(new { Message = "Question updated successfully" });
        }

    }
}
