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

        [HttpPost("createQuestion")]
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

            return await GetQuestionByUserId(newQuestion.UserId);
        }

        [HttpGet("getByUserId/{userId}")]
        public async Task<ActionResult<List<Question>>> GetQuestionByUserId(int userId){
            var questions = await _context.Questions
            .Where(q => q.UserId == userId)
            .ToListAsync();

            return questions;
        }

        [HttpGet("getByTitle/{title}")]
        public async Task<ActionResult<List<Question>>> GetQuestionByTitle(string title){
            var questions = await _context.Questions
            .Where(q => q.Title == title)
            .ToListAsync();

            return questions;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<List<Question>>> GetAllQuestions(){
            var questions = await _context.Questions
            .ToListAsync();

            return questions;
        }
    }
}