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
    public class AnswerController : ControllerBase
    {
        private readonly DataContext _context;

        public AnswerController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("getByUserId/{userId}")]
        public async Task<ActionResult<List<Answer>>> GetAnswerByUserId(int userId){
            var answers = await _context.Answers
            .Where(a => a.UserId == userId)
            .ToListAsync();

            return answers;
        }

        [HttpGet("getByTitle/{title}")]
        public async Task<ActionResult<List<Answer>>> GetAnswerByTitle(string title){
            var answers = await _context.Answers
            .Where(a => a.Title == title)
            .ToListAsync();

            return answers;
        }


        [HttpGet("getAll")]
        public async Task<ActionResult<List<Answer>>> GetAll(){
            var answers = await _context.Answers
            .ToListAsync();

            return answers;
        }

        [HttpGet("getByQuestionId/{questionId}")]
        public async Task<ActionResult<List<Answer>>> GetAnswerByQuestionId(int questionId){
            var answers = await _context.Answers
            .Where(a => a.QuestionId == questionId)
            .ToListAsync();

            return answers;
        }
        
        [HttpPost("addAnswer")]
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

            return await GetAnswerByUserId(newAnswer.UserId);
        }
    }
}