using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Relationships.Data;

namespace Relationships.Controllers
{
    [Route("api[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {

        private readonly DataContext _context;

        public QuestionController(DataContext context)
        {
            _context = context;
        }

        // Question related functions

        [HttpGet("questions/{userId}")]
        public async Task<ActionResult<List<Question>>> GetQuestion(int userId){
            var questions = await _context.Questions
            .Where(q => q.UserId == userId)
            .ToListAsync();

            return questions;
        }

        [HttpPost("questions")]
        public async Task<ActionResult<List<Question>>> CreateQuestion(CreateQuestionDto request){
            var user = await _context.Users.FindAsync(request.UserId);
            if(user == null){
                return NotFound();
            }

            var newQuestion = new Question{
                Title = request.Title,
                Content = request.Content,
                UserId = request.UserId
            };

            _context.Questions.Add(newQuestion);
            await _context.SaveChangesAsync();

            return await GetQuestion(newQuestion.UserId);
        }

        // Answer related functions

        [HttpGet("answers/{userId}")]
        public async Task<ActionResult<List<Answer>>> GetAnswer(int userId){
            var answers = await _context.Answers
            .Where(a => a.UserId == userId)
            .ToListAsync();

            return answers;
        }


         [HttpPost("answers")]
        public async Task<ActionResult<List<Answer>>> CreateAnswer(CreateAnswerDto request){
            var user = await _context.Users.FindAsync(request.UserId);
            var question = await _context.Questions.FindAsync(request.QuestionId);
            if(user == null || question == null){
                return NotFound();
            }

            var newAnswer = new Answer{
                Title = request.Title,
                Content = request.Content,
                UserId = request.UserId,
                QuestionId = request.QuestionId
            };

            _context.Answers.Add(newAnswer);
            await _context.SaveChangesAsync();

            return await GetAnswer(newAnswer.UserId);
        }
    }
}