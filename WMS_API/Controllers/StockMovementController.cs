using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WMS_API.Data;
using WMS_API.Models;

namespace WMS_API.Controllers
{
    public class StockMovementController : ControllerBase
    {
        private readonly WmsDbContext _context;
        public StockMovementController(WmsDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllData")]
        public async Task<ActionResult<IEnumerable<StockMovement>>> GetAllStockMovement()
        {
            return Ok(await _context.Stocks.ToListAsync());
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<StockMovement>> GetStockById(int id)
        {
            var _stockMovement = await _context.Stocks.FindAsync(id);

            if (_stockMovement == null)
            {
                return NotFound(new { message = $"Record Not Found!" });
            }

            return Ok(_stockMovement);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<StockMovement>> AddStockMovement([FromBody] StockMovement _stockMovement)
        {
            if (_stockMovement == null)
            {
                return BadRequest("No Stock Found!");
            }

            _context.Stocks.Add(_stockMovement);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStockById), new { MovementId = _stockMovement.MovementId }, _stockMovement);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<StockMovement>> DeleteStock(int id)
        {
            var _stockMovement = await _context.Stocks.FindAsync(id);
            if (_stockMovement == null)
            {
                return NotFound(new { message = "Stock Not Found!" });
            }

            _context.Stocks.Remove(_stockMovement);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Stock Deleted Successfully" });
        }
    }
}
