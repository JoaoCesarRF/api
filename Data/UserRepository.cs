using Domain.Entities;
using Domain.Interfaces.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext _context) : base(_context)
        {

        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<bool> ValidateCredentials(string username, string password)
        {
            var user = await GetUserByUsernameAsync(username);
            return user != null && user.Password == password;
        }
    }
}
