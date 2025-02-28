using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Data
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<List<Product>> GetProductAsync(int page = 1, int size = 10, string order = "");
        Task<List<string>> GetCategoriesAsync();
    }
}
