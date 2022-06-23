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
    public class SalesPointService : ISalesPointService
    {
        private readonly ITradeRepository _repository;

        public SalesPointService(ITradeRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateSalesPoint(SalesPoint salesPoint)
        {
            await _repository.Create(salesPoint);
            await _repository.Complete();
        }

        public async Task DeleteSalesPoint(Guid id)
        {
            var salePoint = await GetSalesPoint(id);
            _repository.Delete(salePoint);
            await _repository.Complete();
        }

        public Task<SalesPoint> GetSalesPoint(Guid id)
        {
            return _repository.Get<SalesPoint>(id);
        }

        public Task<IEnumerable<SalesPoint>> GetSalesPoints()
        {
            return _repository.GetAll<SalesPoint>();
        }

        public async Task UpdateSalesPoint(SalesPoint salesPoint)
        {
            _repository.Update(salesPoint);
            await _repository.Complete();
        }
    }
}
