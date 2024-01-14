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
     private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("users/{userId}")]
        public async Task<ActionResult<List<User>>> GetUser(int userId){
            var users = await _context.Users
            .Where(u => u.Id == userId)
            .ToListAsync();

            return users;
        }

        [HttpPost("addUser")]
        public async Task<ActionResult<List<User>>> CreateUSer(CreateUserDto request){

            var newUser = new User{
                Username = request.Username
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return await GetUser(newUser.Id);
        }


   
    }
}