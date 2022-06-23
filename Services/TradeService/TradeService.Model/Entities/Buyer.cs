using Main.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradeService.Model.Entities
{
    [Table("Buyer")]
    public class Buyer : MainModel
    {
        public string Name { get; set; }
        public List<Guid> SalesIds { get; set; }
        
    }
}