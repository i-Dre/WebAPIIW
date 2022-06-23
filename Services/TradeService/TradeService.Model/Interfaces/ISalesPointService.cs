using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradeService.Model.Entities;

namespace TradeService.Model.Interfaces
{
    public interface ISalesPointService
    {
        public Task CreateSalesPoint(SalesPoint salesPoint);
        public Task<SalesPoint> GetSalesPoint(Guid id);
        public Task<IEnumerable<SalesPoint>> GetSalesPoints();
        public Task DeleteSalesPoint(Guid id);
        public Task UpdateSalesPoint(SalesPoint salesPoint);
    }
}
