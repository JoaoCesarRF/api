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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> AddProductAsync(Product user)
        {
            return await _productRepository.Create(user);
        }

        public async Task DeleteProductAsync(Guid id)
        {
            var product = await _productRepository.GetById(id);
            if (product is null) throw new Exception("Product not found");
            
            await _productRepository.Delete(product);
        }

        public async Task<List<string>> GetCategoriesAsync()
        {
            return await _productRepository.GetCategoriesAsync();
        }

        public async Task<Product> GetProductById(Guid id)
        {
            return await _productRepository.GetById(id);
        }

        public async Task<(List<Product> Products, int TotalItems)> GetProductsWithTotalCountAsync(int page = 1, int size = 10, string order = "")
        {
           var products =  await _productRepository.GetProductAsync(page, size, order);
            var totalItems = await _productRepository.Count();
            return (products, totalItems);
        }

        public async Task UpdateProductAsync(Product user)
        {
            await _productRepository.Update(user);
        }
    }
}
