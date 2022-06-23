using Main.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace TradeService.Model.Entities
{
    [Table("Sale")]
    public class Sale : MainModel
    {
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public Guid? BuyerId { get; set; }
        public Guid SalesPointId { get; set; }
        public List<SaleData> SalesData { get; set; }
        public float TotalAmount { get; set; }
    }
}
