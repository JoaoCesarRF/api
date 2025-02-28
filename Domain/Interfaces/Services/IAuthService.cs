using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IAuthService
    {
        Task<string?> LoginAsync(string username, string password);
    }
}
