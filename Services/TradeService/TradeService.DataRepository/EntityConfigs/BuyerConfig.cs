using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TradeService.Model.Entities;

namespace TradeService.DataRepository.EntityConfigs
{
    public class BuyerConfig : IEntityTypeConfiguration<Buyer>
    {
        public void Configure(
            EntityTypeBuilder<Buyer> builder)
        {
            builder.Property(item => item.SalesIds)
                .HasConversion(v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<List<Guid>>(v));
        }
    }
}
