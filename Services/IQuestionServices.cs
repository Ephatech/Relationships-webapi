using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Relationships.Services
{
    public interface IQuestionServices
    {
        Task<List<Question>> CreateQuestion(CreateQuestionDto request);
        Task<List<Question>> GetQuestionById(int id);
        Task<List<Question>> GetQuestionByUserId(int userId);
        Task<List<Question>> GetQuestionByTitle(string title);
        Task<List<Question>> GetAllQuestions();
        Task<List<Question>> UpdateQuestion(int questionId, UpdateQuestionDto request);
        Task<List<Question>> DeleteQuestion(int questionId);
    }
}