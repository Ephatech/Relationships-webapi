using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Relationships.Services
{
    public class QuestionServices : IQuestionServices
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public QuestionServices(DataContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Question>> CreateQuestion(CreateQuestionDto request){
            var user = await _context.Users.FindAsync(request.UserId);
            if(user == null){
                throw new KeyNotFoundException("User Not Found!");
            }

            var newQuestion = _mapper.Map<Question>(request);

            _context.Questions.Add(newQuestion);
            await _context.SaveChangesAsync();
            return await GetQuestionByUserId(newQuestion.UserId);
        }

        public async Task<List<Question>> GetQuestionByUserId(int userId){
            var questions = await _context.Questions
            .Where(q => q.UserId == userId)
            .ToListAsync();

            if(questions == null) {
                throw new KeyNotFoundException("Question Not Found!");
            }

            return questions;
        }

        public async Task<List<Question>> GetQuestionById(int id){
            var questions = await _context.Questions
            .Where(q => q.Id == id)
            .ToListAsync();

            if(questions == null) {
                throw new KeyNotFoundException("Question Not Found!");
            }

            return questions;
        }

        public async Task<List<Question>> GetQuestionByTitle(string title){
            var questions = await _context.Questions
            .Where(q => q.Title == title)
            .ToListAsync();

            if(questions == null) {
                throw new KeyNotFoundException("Question Not Found!");
            }

            return questions;
        }

        public async Task<List<Question>> GetAllQuestions(){
            var questions = await _context.Questions
            .ToListAsync();

            return questions;
        }

        public async Task<List<Question>> UpdateQuestion(int questionId, UpdateQuestionDto request)
        {
            var question = await _context.Questions.FindAsync(questionId);
            if (question == null)
            {
                throw new KeyNotFoundException("Question not Found");
            }

            // Update the question properties based on the request
            question= _mapper.Map(request, question);

            _context.Questions.Update(question);
            await _context.SaveChangesAsync();
            return await GetQuestionByUserId(question.UserId);
        }

         public async Task<List<Question>> DeleteQuestion(int questionId)
        {
            var question = await _context.Questions.FindAsync(questionId);
            if (question == null)
            {
                throw new KeyNotFoundException("Question not Found");
            }

            // Delete associated answers first
            var answersToDelete = _context.Answers
            .Where(a => a.QuestionId == questionId);
            _context.Answers.RemoveRange(answersToDelete);

            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();

            return await GetQuestionByUserId(question.UserId);
        }
    }
}