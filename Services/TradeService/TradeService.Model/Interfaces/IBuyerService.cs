using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradeService.Model.Entities;

namespace TradeService.Model.Interfaces
{
    public interface IBuyerService
    {
        public Task CreateBuyer(Buyer buyer);
        public Task<Buyer> GetBuyer(Guid id);
        public Task<IEnumerable<Buyer>> GetBuyers();
        public Task DeleteBuyer(Guid id);
        public Task UpdateBuyer(Buyer buyer);

    }
}
