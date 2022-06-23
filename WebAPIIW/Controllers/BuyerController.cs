using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TradeService.Model.Dto;
using TradeService.Model.Entities;
using TradeService.Model.Interfaces;

namespace WebAPIIW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyerController : ControllerBase
    {
        private readonly IBuyerService _buyerService;
        public BuyerController(
           IBuyerService buyerService)
        {
            _buyerService = buyerService;
        }

        [HttpPost("create-buyer")]
        public async Task<IActionResult> CreateBuyer([FromBody] Buyer entity)
        {
            try
            {
                await _buyerService.CreateBuyer(entity);
                return Ok(await _buyerService.GetBuyers());
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("get-buyers")]
        public async Task<IActionResult> GetBuyers()
        {
            try
            {
                return Ok(await _buyerService.GetBuyers());
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost("get-buyer")]
        public async Task<IActionResult> GetBuyer([FromBody] DtoRequestGet dtoRequestGet)
        {
            try
            {
                return Ok(await _buyerService.GetBuyer(dtoRequestGet.Id));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost("update-buyer")]
        public async Task<IActionResult> UpdateBuyer([FromBody] Buyer buyer)
        {
            try
            {
                await _buyerService.UpdateBuyer(buyer);
                return Ok(await _buyerService.GetBuyer(buyer.Id));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost("delete-buyer")]
        public async Task<IActionResult> Delete([FromBody] DtoRequestGet dtoRequestGet)
        {
            try
            {
                await _buyerService.DeleteBuyer(dtoRequestGet.Id);
                return Ok(await _buyerService.GetBuyers());
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
