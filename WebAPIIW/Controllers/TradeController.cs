using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeService.Model.Dto;
using TradeService.Model.Entities;
using TradeService.Model.Interfaces;

namespace WebAPIIW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradeController : ControllerBase
    {
        private readonly ITradeService _tradeService;
        private readonly IMapper _mapper;
        private readonly ISaleService _saleService;
        public TradeController(
           ITradeService tradeService,
           ISaleService saleService,
           IMapper mapper)
        {
            _mapper = mapper;
            _tradeService = tradeService;
            _saleService = saleService;
        }

        [HttpPost("trade")]
        public async Task<IActionResult> Trade([FromBody] DtoSaleMethod dtoSaleMethod)
        {
            try
            {
                var sale = _mapper.Map<Sale>(dtoSaleMethod);
                await _tradeService.Transaction(sale);
                return Ok(await _saleService.GetSales());
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
