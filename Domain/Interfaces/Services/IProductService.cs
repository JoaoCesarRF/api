using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IProductService
    {
        Task UpdateProductAsync(Product user);
        Task DeleteProductAsync(Guid id);
        Task<Product> AddProductAsync(Product user);
        Task<Product> GetProductById(Guid id);
        Task<List<string>> GetCategoriesAsync();
        Task<(List<Product> Products, int TotalItems)> GetProductsWithTotalCountAsync(int page = 1, int size = 10, string order = "");
    }
}
