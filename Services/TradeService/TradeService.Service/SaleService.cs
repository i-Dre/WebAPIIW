using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeService.DataRepository.Repositories;
using TradeService.Model.Entities;
using TradeService.Model.Interfaces;

namespace TradeService.Service
{
    public class SaleService : ISaleService
    {
        private readonly ITradeRepository _repository;

        public SaleService(ITradeRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateSale(Sale sale)
        {
            await _repository.Create(sale);
            await _repository.Complete();
        }

        public async Task DeleteSale(Guid id)
        {
            var sale = await GetSale(id);
            _repository.Delete(sale);
            await _repository.Complete();
        }

        public Task<Sale> GetSale(Guid id)
        {
            return _repository.Get<Sale>(id);
        }

        public Task<IEnumerable<Sale>> GetSales()
        {
            return _repository.GetAll<Sale>();
        }

        public async Task UpdateSale(Sale sale)
        {
            _repository.Update(sale);
            await _repository.Complete();
        }
    }
}
