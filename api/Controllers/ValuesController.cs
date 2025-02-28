using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class SaleController : ControllerBase
    {
        private readonly SaleService _saleService;

        public SaleController(SaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSale([FromBody] Sale sale)
        {
            var createdSale = await _saleService.CreateSaleAsync(sale);
            return Ok(createdSale);
        }

        [HttpGet("GetSale")]
        public async Task<IActionResult> GetSale([FromQuery] Guid id)
        {
            var sale = await _saleService.GetSaleByIdAsync(id);
            return Ok(sale);
        }
    }
}
