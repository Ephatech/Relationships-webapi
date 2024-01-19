using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Relationships.Data;

namespace Relationships.Controllers
{
    [Route("api[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
     private readonly IUserServices  _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet("users/{userId}")]
        public async Task<ActionResult> GetUser(int userId){
            try{
                return Ok(await _userServices.GetUser(userId));
            }
            catch(Exception ex){
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("getAll")]
        public async Task<ActionResult> GetAllUsers(){
            try
            {
                return Ok(await _userServices.GetAllUsers());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("addUser")]
        public async Task<ActionResult> CreateUSer(CreateUserDto request){

            try
            {
                return Ok(await _userServices.CreateUSer(request));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut("updateUser/{userId}")]
        public async Task<ActionResult> UpdateUser(int userId, CreateUserDto request)
        {
            try
            {
                return Ok(await _userServices.UpdateUser(userId, request));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        // [HttpDelete("deleteUsern/{userId}")]
        // public async Task<ActionResult<List<User>>> DeleteUser(int userId)
        // {
        //     var user = await _context.Users.FindAsync(userId);
        //     if (user == null)
        //     {
        //         return NotFound();
        //     }

        //     // Delete associated questions first
        //     var questionsToDelete = _context.Questions
        //     .Where(q => q.UserId == userId);
        //     _context.Questions.RemoveRange(questionsToDelete);

        //     // Delete associated answers first
        //     var answersToDelete = _context.Answers
        //     .Where(a => a.UserId == userId);
        //     _context.Answers.RemoveRange(answersToDelete);

        //     _context.Users.Remove(user);
        //     await _context.SaveChangesAsync();

        //     return await GetUser(user.Id);
        // }
   
    }
}