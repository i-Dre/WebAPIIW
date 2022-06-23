using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TradeService.DataRepository.EntityConfigs;
using TradeService.Model.Entities;

namespace TradeService.DataRepository
{
    public class TradeDbContext : DbContext
    {
        public TradeDbContext(
            DbContextOptions<TradeDbContext> options)
            : base(options)
        {
        }

        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SalesPoint> SalesPoint { get; set; }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Buyer>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<Product>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<Sale>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<SalesPoint>().HasQueryFilter(e => !e.IsDeleted);

            modelBuilder.ApplyConfiguration(new SaleConfig());
            modelBuilder.ApplyConfiguration(new SalePointConfig());
            modelBuilder.ApplyConfiguration(new BuyerConfig());

            modelBuilder.Entity<Product>().HasData(
                new Product[]
                {
                    new Product {
                        Id = new Guid("a0000001-17c3-4fcc-8cbf-03a9cdfcee4c"),
                        Name = "Лампочка",
                        Price = 100,
                        IsDeleted = false
                    },
                    new Product {
                        Id = new Guid("a0000002-188c-4fc9-8311-37e7eff4dbcf"),
                        Name = "Фонарик",
                        Price = 435,
                        IsDeleted = false
                    },
                    new Product {
                        Id = new Guid("a0000003-df02-43a6-8d2a-0106062d5ac9"),
                        Name = "Люстра",
                        Price = 3153,
                        IsDeleted = false
                    },
                    new Product {
                        Id = new Guid("a0000004-9106-413d-b45a-ac98be9bb38d"),
                        Name = "Розетка",
                        Price = 150,
                        IsDeleted = false
                    }
                });

            modelBuilder.Entity<SalesPoint>().HasData(
                new SalesPoint[]
                {
                    new SalesPoint {
                        Id = new Guid("af000001-1644-4188-a3ff-3dd392de686e"),
                        Name = "Электрон",
                        ProvidedProducts = new List<ProvidedProduct> {
                            new ProvidedProduct{
                                ProductId = new Guid("a0000001-17c3-4fcc-8cbf-03a9cdfcee4c"),
                                ProductQuantity = 130
                            },
                            new ProvidedProduct{
                                ProductId = new Guid("a0000002-188c-4fc9-8311-37e7eff4dbcf"),
                                ProductQuantity = 25
                            }
                        },
                        IsDeleted = false
                    },
                    new SalesPoint {
                        Id = new Guid("af000002-ca00-4c80-8581-63ecc5ae86cb"),
                        Name = "Планета 220",
                        ProvidedProducts = new List<ProvidedProduct> {
                            new ProvidedProduct{
                                ProductId = new Guid("a0000001-17c3-4fcc-8cbf-03a9cdfcee4c"),
                                ProductQuantity = 65
                            },
                            new ProvidedProduct{
                                ProductId = new Guid("a0000004-9106-413d-b45a-ac98be9bb38d"),
                                ProductQuantity = 3
                            }
                        },
                        IsDeleted = false
                    },
                    new SalesPoint {
                        Id = new Guid("af000003-41bc-4f79-84f9-db1c6507c95c"),
                        Name = "220v",
                        ProvidedProducts = new List<ProvidedProduct> {
                            new ProvidedProduct{
                                ProductId = new Guid("a0000002-188c-4fc9-8311-37e7eff4dbcf"),
                                ProductQuantity = 34
                            },
                            new ProvidedProduct{
                                ProductId = new Guid("a0000003-df02-43a6-8d2a-0106062d5ac9"),
                                ProductQuantity = 5
                            },
                            new ProvidedProduct{
                                ProductId = new Guid("a0000004-9106-413d-b45a-ac98be9bb38d"),
                                ProductQuantity = 60
                            }
                        },
                        IsDeleted = false
                    }
                });
            modelBuilder.Entity<Buyer>().HasData(
                new Buyer[]
                {
                    new Buyer {
                        Id = new Guid("b0000001-e3ea-4063-9089-48cffd3f56bc"),
                        Name = "Роман Васильев",
                        SalesIds = new List<Guid>()
                    },
                    new Buyer {
                        Id = new Guid("b0000002-479c-4e1f-a55c-2220e913d934"),
                        Name = "Игорь Вернов",
                        SalesIds = new List<Guid>()
                    },
                    new Buyer {
                        Id = new Guid("b0000003-b0c4-4267-96e6-fe74ffe21424"),
                        Name = "Надежда Иванова",
                        SalesIds = new List<Guid>()
                    },
                    new Buyer {
                        Id = new Guid("b0000004-ac13-47dc-b614-fc06ebf47c9b"),
                        Name = "Кирилл Сергеев",
                        SalesIds = new List<Guid>()
                    },
                });
        }
    }
}