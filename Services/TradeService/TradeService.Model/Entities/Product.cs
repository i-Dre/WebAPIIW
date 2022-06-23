using Main.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradeService.Model.Entities
{
    [Table("Product")]
    public class Product : MainModel
    {
        public string Name { get; set; }
        public float Price { get; set; }
    }
}
