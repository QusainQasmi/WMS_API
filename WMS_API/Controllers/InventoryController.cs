using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WMS_API.Data;
using WMS_API.Models;

namespace WMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly WmsDbContext _context;

        private readonly string _connectionString;
        public InventoryController(WmsDbContext context, IConfiguration configuration)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("WMSConnection");
        }

        [HttpGet("GetAllData")]
        public async Task<ActionResult<IEnumerable<Inventory>>> GetAllInventory()
        {
            var inventoryList = new List<Inventory>();

            var query = @"
                SELECT 
                    i.InventoryId,
                    p.ProductId,
                    p.Name AS ProductName,
                    l.LocationId,
                    l.LocationCode,
                    i.Quantity
                FROM Inventory i
                INNER JOIN Products p ON i.ProductId = p.ProductId
                INNER JOIN Locations l ON i.LocationId = l.LocationId;
            ";

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        inventoryList.Add(new Inventory
                        {
                            InventoryId = reader.GetInt32(0),
                            ProductId = reader.GetInt32(1),
                            ProductName = reader.GetString(2),
                            LocationId = reader.GetInt32(3),
                            LocationCode = reader.GetString(4),
                            Quantity = reader.GetInt32(5)
                        });
                    }
                }
            }

            return inventoryList;
        }
    }
}
