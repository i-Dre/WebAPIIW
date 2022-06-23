using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TradeService.DataRepository;
using TradeService.DataRepository.Repositories;
using TradeService.Model.Interfaces;

namespace TradeService.Service
{
    public static class ServiceFactory
    {
        public static IServiceCollection AddTradeService(
            this IServiceCollection services,
            IConfiguration config)
        {

            var dbConnectionString = config.GetConnectionString("DBConnectionString");
            services.AddDbContext<TradeDbContext>(options =>
            {
                options.UseSqlServer(dbConnectionString);
            });

            services.AddScoped<ITradeRepository, TradeRepository>();
            services.AddScoped<IBuyerService, BuyerService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISaleService, SaleService>();
            services.AddScoped<ISalesPointService, SalesPointService>();
            services.AddScoped<ITradeService, TradeService>();

            return services;
        }
    }
}
