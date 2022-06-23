using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TradeService.Model.Dto;
using TradeService.Model.Entities;
using TradeService.Model.Interfaces;

namespace WebAPIIW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesPointController : ControllerBase
    {
        private readonly ISalesPointService _salesPointService;
        public SalesPointController(
           ISalesPointService salesPointService)
        {
            _salesPointService = salesPointService;
        }


        [HttpPost("create-sales-point")]
        public async Task<IActionResult> CreateSalesPoint([FromBody] SalesPoint entity)
        {
            try
            {
                await _salesPointService.CreateSalesPoint(entity);
                return Ok(await _salesPointService.GetSalesPoints());
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("get-sales-points")]
        public async Task<IActionResult> GetSalesPoints()
        {
            try
            {
                return Ok(await _salesPointService.GetSalesPoints());
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost("get-sales-point")]
        public async Task<IActionResult> GetSalesPoint([FromBody] DtoRequestGet dtoRequestGet)
        {
            try
            {
                return Ok(await _salesPointService.GetSalesPoint(dtoRequestGet.Id));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost("update-sales-point")]
        public async Task<IActionResult> UpdateSalesPoint([FromBody] SalesPoint salesPoint)
        {
            try
            {
                await _salesPointService.UpdateSalesPoint(salesPoint);
                return Ok(await _salesPointService.GetSalesPoint(salesPoint.Id));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost("delete-sales-point")]
        public async Task<IActionResult> Delete([FromBody] DtoRequestGet dtoRequestGet)
        {
            try
            {
                await _salesPointService.DeleteSalesPoint(dtoRequestGet.Id);
                return Ok(await _salesPointService.GetSalesPoints());
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
