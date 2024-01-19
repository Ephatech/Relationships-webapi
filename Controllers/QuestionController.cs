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

        private readonly IQuestionServices _questionServices;

        public QuestionController(IQuestionServices questionServices)
        {
            _questionServices = questionServices;
        }

        [HttpPost("createQuestion")]
        public async Task<ActionResult> CreateQuestion(CreateQuestionDto request){
            try
            {
                return Ok(await _questionServices.CreateQuestion(request));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("getByUserId/{userId}")]
        public async Task<ActionResult<List<Question>>> GetQuestionByUserId(int userId){
            try{
                return Ok(await _questionServices.GetQuestionByUserId(userId));
            }
            catch(Exception ex){
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("getById/{id}")]
        public async Task<ActionResult<List<Question>>> GetQuestionById(int id){
            try{
                return Ok(await _questionServices.GetQuestionById(id));
            }
            catch(Exception ex){
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("getByTitle/{title}")]
        public async Task<ActionResult<List<Question>>> GetQuestionByTitle(string title){
            try{
                return Ok(await _questionServices.GetQuestionByTitle(title));
            }
            catch(Exception ex){
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<List<Question>>> GetAllQuestions(){
           try
            {
                return Ok(await _questionServices.GetAllQuestions());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut("updateQuestion/{questionId}")]
        public async Task<ActionResult<List<Question>>> UpdateQuestion(int questionId, UpdateQuestionDto request)
        {
            try
            {
                return Ok(await _questionServices.UpdateQuestion(questionId, request));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("deleteQuestion/{questionId}")]
        public async Task<ActionResult<List<Question>>> DeleteQuestion(int questionId)
        {
            try
            {
                return Ok(await _questionServices.DeleteQuestion(questionId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


    }
}