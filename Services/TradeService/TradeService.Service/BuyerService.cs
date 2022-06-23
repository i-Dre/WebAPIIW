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
    public class BuyerService : IBuyerService
    {
        private readonly ITradeRepository _repository;

        public BuyerService(ITradeRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateBuyer(Buyer buyer)
        {
            await _repository.Create(buyer);
            await _repository.Complete();
        }

        public async Task DeleteBuyer(Guid id)
        {
            var buyer = await GetBuyer(id);
            _repository.Delete(buyer);
            await _repository.Complete();

        }

        public Task<Buyer> GetBuyer(Guid id)
        {
            return _repository.Get<Buyer>(id);
        }

        public Task<IEnumerable<Buyer>> GetBuyers()
        {
            return _repository.GetAll<Buyer>();
        }

        public async Task UpdateBuyer(Buyer buyer)
        {
            _repository.Update(buyer);
            await _repository.Complete();
        }
    }
}
