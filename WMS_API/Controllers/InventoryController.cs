using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
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

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand("sp_GetInventoryLst", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        inventoryList.Add(new Inventory
                        {
                            InventoryId = reader.GetInt32(reader.GetOrdinal("InventoryId")),
                            ProductId = reader.GetInt32(reader.GetOrdinal("ProductId")),
                            ProductName = reader.GetString(reader.GetOrdinal("ProductName")),
                            LocationId = reader.GetInt32(reader.GetOrdinal("LocationId")),
                            LocationCode = reader.GetString(reader.GetOrdinal("LocationCode")),
                            Quantity = reader.GetInt32(reader.GetOrdinal("Quantity"))
                        });
                    }
                }
            }

            return Ok(inventoryList);
        }

    }
}
