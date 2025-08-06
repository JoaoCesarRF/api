using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Data
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetUserByUsernameAsync(string username);
        Task<bool> AddUser(User user);
        Task<bool> ValidateCredentials(string username, string password);
        Task<List<User>> GetUsersAsync(int page = 1, int size = 10, string order = "");

    }
}
