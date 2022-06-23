using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TradeService.Model.Dto;
using TradeService.Model.Entities;
using TradeService.Model.Interfaces;

namespace WebAPIIW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;
        public SaleController(
           ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpPost("сreate-sale")]
        public async Task<IActionResult> CreateSale([FromBody] Sale entity)
        {
            try
            {
                await _saleService.CreateSale(entity);
                return Ok(await _saleService.GetSales());
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("get-sales")]
        public async Task<IActionResult> GetSales()
        {
            try
            {
                return Ok(await _saleService.GetSales());
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost("get-sale")]
        public async Task<IActionResult> GetSale([FromBody] DtoRequestGet dtoRequestGet)
        {
            try
            {
                return Ok(await _saleService.GetSale(dtoRequestGet.Id));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost("update-sale")]
        public async Task<IActionResult> UpdateSale([FromBody] Sale sale)
        {
            try
            {
                await _saleService.UpdateSale(sale);
                return Ok(await _saleService.GetSale(sale.Id));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost("delete-sale")]
        public async Task<IActionResult> Delete([FromBody] DtoRequestGet dtoRequestGet)
        {
            try
            {
                await _saleService.DeleteSale(dtoRequestGet.Id);
                return Ok(await _saleService.GetSales());
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
