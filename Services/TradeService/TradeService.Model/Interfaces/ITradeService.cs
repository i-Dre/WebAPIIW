using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeService.Model.Dto;
using TradeService.Model.Entities;

namespace TradeService.Model.Interfaces
{
    public interface ITradeService
    {
        public Task Transaction(Sale sale);
    }
}
