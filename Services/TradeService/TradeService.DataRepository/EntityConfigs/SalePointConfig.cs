using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System.Collections.Generic;
using TradeService.Model.Entities;

namespace TradeService.DataRepository.EntityConfigs
{
    class SalePointConfig : IEntityTypeConfiguration<SalesPoint>
    {
        public void Configure(
            EntityTypeBuilder<SalesPoint> builder)
        {
            builder.Property(item => item.ProvidedProducts)
                .HasConversion(v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<List<ProvidedProduct>>(v));
        }
    }
}
