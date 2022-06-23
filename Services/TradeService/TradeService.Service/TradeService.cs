using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeService.DataRepository.Repositories;
using TradeService.Model.Dto;
using TradeService.Model.Entities;
using TradeService.Model.Interfaces;

namespace TradeService.Service
{
    public class TradeService : ITradeService
    {
        private readonly ITradeRepository _repository;

        public TradeService(ITradeRepository repository)
        {
            _repository = repository;
        }

        public async Task Transaction(Sale sale)
        {
            sale.Date = DateTime.Now;
            sale.Time = DateTime.Now.TimeOfDay;
            
            var salePoint = await _repository.Get<SalesPoint>(sale.SalesPointId);
            float totalAmount = 0;

            foreach (var soldProducts in sale.SalesData)
            {
                var productOnSalesPoint = salePoint.ProvidedProducts.FirstOrDefault(x => x.ProductId == soldProducts.ProductId);
                var product = await _repository.Get<Product>(soldProducts.ProductId);
                productOnSalesPoint.ProductQuantity -= soldProducts.ProductQuantity;
                soldProducts.ProductIdAmount = soldProducts.ProductQuantity * product.Price;
                totalAmount += soldProducts.ProductIdAmount;
            }
            sale.TotalAmount = totalAmount;

            await _repository.Create<Sale>(sale);
            _repository.Update(salePoint);

            if (sale.BuyerId != null)
            {
                var buyer = await _repository.Get<Buyer>(sale.BuyerId.Value);
                buyer.SalesIds.Add(sale.Id);
                _repository.Update(buyer);
            }
            await _repository.Complete();
        }
    }
}