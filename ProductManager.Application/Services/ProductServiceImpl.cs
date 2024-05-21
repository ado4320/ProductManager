using ProductManager.Core.Services.Dtos;
using ProductManager.Core.Services.Entities;
using ProductManager.Core.Services.Interfaces;
using ProductManager.Core.Services.Interfaces.Repositories;
using ProductManager.Core.Services.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProductManager.Application.Services
{
    public class ProductServiceImpl : IProductService
    {

        private IProductRepository _productRepository { get; }
  


        public ProductServiceImpl(IProductRepository productRepository)
        {
            _productRepository = productRepository;

        }

        public async Task CreateAsync(Product product)
        {
            product.Id = Guid.NewGuid();
            await _productRepository.CreateAsync(product);
        }

        public async Task DeleteAsync(Guid Id)
        {
            await _productRepository.DeleteAsync(Id);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }
        public async Task<Product> GetByIdAsync(Guid Id)
        {
            return await _productRepository.GetByIdAsync(Id);
        }

        public async Task UpdateAsync(Product entity)
        {
            await _productRepository.UpdateAsync(entity);
        }

        public async Task<IEnumerable<Product>> SearchProductByNameAsync(string name)
        {
            return await _productRepository.SearchProductByNameAsync(name);
        }

        public async Task<IEnumerable<Product>> SearchByRangeAsync(decimal? minimunPrice, decimal? maximunPrice)
        {
            return await _productRepository.SearchByRangeAsync(minimunPrice, maximunPrice);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllProductsAsync();
        }
    }
}
