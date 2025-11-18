using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WMS_API.Data;
using WMS_API.Models;

namespace WMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly WmsDbContext _context;
        public WarehouseController(WmsDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllData")]
        public async Task<ActionResult<IEnumerable<Warehouse>>> GetAllWarehouses()
        {
            return Ok(await _context.Warehouses.ToListAsync());
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<Warehouse>> GetWarehouseById(int id)
        {
            var warehouse = await _context.Warehouses.FindAsync(id);

            if (warehouse == null)
            {
                return NotFound(new { message = $"Record Not Found!" });
            }

            return Ok(warehouse);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<Warehouse>> AddWarehouse([FromBody] Warehouse warehouse)
        {
            if (warehouse == null)
            {
                return BadRequest("Invalid warehouse data.");
            }

            _context.Warehouses.Add(warehouse);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetWarehouseById), new { id = warehouse.WarehouseId }, warehouse);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<Warehouse>> DeleteWarehouse(int id)
        {
            var warehouse = await _context.Warehouses.FindAsync(id);
            if (warehouse == null)
            {
                return NotFound(new { message = "Warehouse Not Found" });
            }

            _context.Warehouses.Remove(warehouse);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Warehouse Deleted Successfully" });
        }
    }
}
