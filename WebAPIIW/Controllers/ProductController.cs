using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TradeService.Model.Dto;
using TradeService.Model.Entities;
using TradeService.Model.Interfaces;

namespace WebAPIIW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(
           IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("сreate-product")]
        public async Task<IActionResult> CreateProduct([FromBody] Product entity)
        {
            try
            {
                await _productService.CreateProduct(entity);
                return Ok(await _productService.GetProducts());
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("get-products")]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                return Ok(await _productService.GetProducts());
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost("get-product")]
        public async Task<IActionResult> GetProduct([FromBody] DtoRequestGet dtoRequestGet)
        {
            try
            {
                return Ok(await _productService.GetProduct(dtoRequestGet.Id));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost("update-product")]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            try
            {
                await _productService.UpdateProduct(product);
                return Ok(await _productService.GetProduct(product.Id));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost("delete-product")]
        public async Task<IActionResult> DeleteProduct([FromBody] DtoRequestGet dtoRequestGet)
        {
            try
            {
                await _productService.DeleteProduct(dtoRequestGet.Id);
                return Ok(await _productService.GetProducts());
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
