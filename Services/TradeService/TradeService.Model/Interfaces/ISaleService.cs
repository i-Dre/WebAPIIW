using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradeService.Model.Entities;

namespace TradeService.Model.Interfaces
{
    public interface ISaleService
    {
        public Task CreateSale(Sale sale);
        public Task<Sale> GetSale(Guid id);
        public Task<IEnumerable<Sale>> GetSales();
        public Task DeleteSale(Guid id);
        public Task UpdateSale(Sale sale);
    }
}
