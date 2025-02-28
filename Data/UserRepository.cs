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
        public async Task<List<User>> GetUsersAsync(int page = 1, int size = 10, string order = "")
        {
            var query = _context.User.AsQueryable();

            if (!string.IsNullOrEmpty(order))
            {
                if (order.Contains("username"))
                    query = order.EndsWith("desc") ? query.OrderByDescending(u => u.Username) : query.OrderBy(u => u.Username);
            }

            return await query.Skip((page - 1) * size).Take(size).ToListAsync();
        }



    }
}
