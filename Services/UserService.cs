using Domain.Entities;
using Domain.Interfaces.Data;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async  Task<User> AddUserAsync(User user)
        {
            return await _userRepository.Create(user);
            
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await _userRepository.GetById(id);
            if (user == null) throw new Exception("User not Found");
            await _userRepository.Delete(user);
            
        }

        public async Task<List<User>> GetUsersAsync(int page = 1, int size = 10, string order = "")
        {
            return await _userRepository.GetUsersAsync(page, size, order);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.Update(user);
        }
    }
}
