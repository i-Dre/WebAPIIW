using System;
using System.Text.Json.Serialization;

namespace TradeService.Model.Entities
{
    public class SaleData
    {
        public Guid ProductId { get; set; }
        public int ProductQuantity { get; set; }
        [JsonIgnore]
        public float ProductIdAmount { get; set; }
    }
}
