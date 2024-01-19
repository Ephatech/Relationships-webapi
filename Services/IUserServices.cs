using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Relationships.Services
{
    public interface IUserServices
    {
        Task<List<User>> GetUser(int userId);
        Task<List<User>> GetAllUsers();
        Task<List<User>> CreateUSer(CreateUserDto request);
        Task<List<User>> UpdateUser(int userId, CreateUserDto request);
        // Task<List<User>> DeleteUser(int userId);
    }
}