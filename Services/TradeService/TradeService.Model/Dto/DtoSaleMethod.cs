using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TradeService.Model.Entities;

namespace TradeService.Model.Dto
{
    public class DtoSaleMethod
    {
        [JsonProperty(PropertyName = "salesPointId")]
        public Guid SalesPointId { get; set; }
        [JsonProperty(PropertyName = "buyerId")]
        public Guid? BuyerId { get; set; }
        [JsonProperty(PropertyName = "salesData")]
        public List<SaleData> SalesData { get; set; }
    }
}