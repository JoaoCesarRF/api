using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task UpdateUserAsync(User user);
        Task  DeleteUserAsync(Guid id);
        Task<User> AddUserAsync(User user);
        Task<User> GetUserById(Guid id);
        Task<(List<User> Users, int TotalItems)> GetUsersWithTotalCountAsync(int page = 1, int size = 10, string order = "");
    }
}
