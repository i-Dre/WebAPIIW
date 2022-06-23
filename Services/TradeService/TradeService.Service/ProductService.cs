using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradeService.DataRepository.Repositories;
using TradeService.Model.Entities;
using TradeService.Model.Interfaces;

namespace TradeService.Service
{
    public class ProductService : IProductService
    {
        private readonly ITradeRepository _repository;

        public ProductService(ITradeRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateProduct(Product product)
        {
            await _repository.Create(product);
            await _repository.Complete();
        }

        public async Task DeleteProduct(Guid id)
        {
            var product = await GetProduct(id);
            _repository.Delete(product);
            await _repository.Complete();
        }

        public Task<Product> GetProduct(Guid id)
        {
            return _repository.Get<Product>(id);
        }

        public Task<IEnumerable<Product>> GetProducts()
        {
            return _repository.GetAll<Product>();
        }

        public async Task UpdateProduct(Product product)
        {
            _repository.Update(product);
            await _repository.Complete();
        }
    }
}
