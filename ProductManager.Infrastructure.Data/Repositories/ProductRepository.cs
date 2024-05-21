using Microsoft.EntityFrameworkCore;
using ProductManager.Core.Services.Entities;
using ProductManager.Core.Services.Interfaces.Repositories;
using ProductManager.Infrastructure.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Infrastructure.Data.Repositories
{
    public class ProductRepository :BaseRepository<Product>, IProductRepository
    {

        public BaseContext Context { get; }
        protected readonly DbSet<Product> productParameters;

        public ProductRepository(BaseContext dbContext) : base(dbContext)
        {
            Context = dbContext;
            productParameters = dbContext.Set<Product>();
        }

        public async Task<IEnumerable<Product>> SearchProductByNameAsync(string name)
        {
            var products = await Context.Products.Include(x => x.Category).Where(x => x.Name == name).ToListAsync();
            return products;
        }

        public async Task<IEnumerable<Product>> SearchByRangeAsync(decimal? minPrice, decimal? maxPrice)
        {
            var products = await Context.Products.Include(x => x.Category).Where(x => x.Price >= minPrice && x.Price <= maxPrice).ToListAsync();
            return products;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var products = await Context.Products.Include(x => x.Category).ToListAsync();
            return products;
        }
    }
}
