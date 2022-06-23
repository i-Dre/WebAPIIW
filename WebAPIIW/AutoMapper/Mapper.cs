using AutoMapper;
using Microsoft.Extensions.Configuration;
using TradeService.Model.Dto;
using TradeService.Model.Entities;

namespace WebAPIIW.AutoMapper
{
    public class Mapper : Profile
    {
        private readonly IConfiguration _configuration;
        public Mapper(IConfiguration configuration)
        {
            _configuration = configuration;
            TradeConfiguration();
        }

        private void TradeConfiguration()
        {
            CreateMap<DtoSaleMethod, Sale>()
                .ForMember(entity => entity.SalesPointId, expression => expression.MapFrom(dto => dto.SalesPointId));
        }
    }
}
