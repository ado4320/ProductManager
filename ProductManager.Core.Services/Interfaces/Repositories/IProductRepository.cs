using ProductManager.Core.Services.Dtos;
using ProductManager.Core.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Core.Services.Interfaces.Repositories
{
    public interface IProductRepository: IRepository<Product>
    {
        

        Task<IEnumerable<Product>> SearchProductByNameAsync(string name);

        Task<IEnumerable<Product>> SearchByRangeAsync(decimal? minimunPrice, decimal? maximunPrice);

        Task<IEnumerable<Product>> GetAllProductsAsync();
    }
}
