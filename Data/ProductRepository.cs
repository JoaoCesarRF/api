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
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<string>> GetCategoriesAsync()
        {
            return await _context.Product.Select(p => p.Category).Distinct().ToListAsync();
        }

        public async Task<List<Product>> GetProductAsync(int page = 1, int size = 10, string order = "")
        {
            var query = _context.Product.AsQueryable();

            if (!string.IsNullOrEmpty(order))
            {
                if (order.Contains("price"))
                    query = order.EndsWith("desc") ? query.OrderByDescending(p => p.Price) : query.OrderBy(p => p.Price);
                if (order.Contains("title"))
                    query = order.EndsWith("desc") ? query.OrderByDescending(p => p.Title) : query.OrderBy(p => p.Title);
            }
            return await query.Skip((page - 1) * size).Take(size).ToListAsync();
        }
    }
}