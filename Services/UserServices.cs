using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Relationships.Services
{
    public class UserServices : IUserServices
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserServices(DataContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<User>> GetUser(int userId){
            var users = await _context.Users
            .Where(u => u.Id == userId)
            .ToListAsync();

            if(users == null) {
                throw new KeyNotFoundException("User Not Found!");
            }
               
            return users;
        }

        public async Task<List<User>> GetAllUsers(){
            var users = await _context.Users
            .ToListAsync();
            return users;
        }

        public async Task<List<User>> CreateUSer(CreateUserDto request){

            var newUser = _mapper.Map<User>(request);

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return await GetUser(newUser.Id);
        }

        public async Task<List<User>> UpdateUser(int userId, CreateUserDto request)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                throw new KeyNotFoundException("User not Found");
            }
            user = _mapper.Map(request, user);
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return await GetUser(user.Id);
        }

    }
}