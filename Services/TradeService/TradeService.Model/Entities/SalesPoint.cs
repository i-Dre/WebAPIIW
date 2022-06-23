using Main.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradeService.Model.Entities
{
    [Table("SalesPoint")]
    public class SalesPoint : MainModel
    {
        public string Name { get; set; }
        public List<ProvidedProduct> ProvidedProducts { get; set; }
    }
}
