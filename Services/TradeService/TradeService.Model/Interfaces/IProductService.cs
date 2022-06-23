using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradeService.Model.Entities;

namespace TradeService.Model.Interfaces
{
    public interface IProductService
    {
        public Task CreateProduct(Product product);
        public Task<Product> GetProduct(Guid id);
        public Task<IEnumerable<Product>> GetProducts();
        public Task DeleteProduct(Guid id);
        public Task UpdateProduct(Product product);
    }
}
