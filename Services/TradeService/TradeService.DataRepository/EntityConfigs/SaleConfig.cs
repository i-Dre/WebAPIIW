using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System.Collections.Generic;
using TradeService.Model.Entities;

namespace TradeService.DataRepository.EntityConfigs
{
    public class SaleConfig : IEntityTypeConfiguration<Sale>
    {
        public void Configure(
            EntityTypeBuilder<Sale> builder)
        {
            builder.Property(item => item.SalesData)
                .HasConversion(v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<List<SaleData>>(v));
        }
    }
}
