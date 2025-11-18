using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using WMS_API.Data;
using WMS_API.Models;

namespace WMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly WmsDbContext _context;

        private readonly string _connectionString;
        public LocationsController(WmsDbContext context, IConfiguration configuration)
        {
            _context = context;
            //if (configuration != null)
            //{
                _connectionString = configuration.GetConnectionString("WMSConnection");
            //}
        }


        //public async Task<ActionResult<IEnumerable<Locations>>> GetAllLocations()
        //{
        //    var locationList = new List<Locations>();

        //    var query = @"
        //        SELECT 
        //            l.LocationId,
        //            l.WarehouseId,
        //            w.Name,
        //            l.LocationCode,
        //            l.Description
        //        FROM Locations l
        //        INNER JOIN Warehouses w ON l.WarehouseId = w.WarehouseId;
        //    ";

        //    using (var conn = new SqlConnection(_connectionString))
        //    using (var cmd = new SqlCommand(query, conn))
        //    {
        //        await conn.OpenAsync();
        //        using (var reader = await cmd.ExecuteReaderAsync())
        //        {
        //            while (await reader.ReadAsync())
        //            {
        //                locationList.Add(new Locations
        //                {
        //                    LocationId = reader.GetInt32(0),
        //                    WarehouseId = reader.GetInt32(1),
        //                    WarehouseName = reader.GetString(2),
        //                    LocationCode = reader.GetString(3),
        //                    Description = reader.GetString(4)
        //                });
        //            }
        //        }
        //    }

        //    return locationList;
        //}

        [HttpGet("GetAllData")]
        public async Task<ActionResult<IEnumerable<Locations>>> GetAllLocations()
        {
            var locationList = new List<Locations>();

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand("sp_GetLocationsWithWarehouse", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        locationList.Add(new Locations
                        {
                            LocationId = reader.GetInt32(reader.GetOrdinal("LocationId")),
                            WarehouseId = reader.GetInt32(reader.GetOrdinal("WarehouseId")),
                            WarehouseName = reader.GetString(reader.GetOrdinal("WarehouseName")),
                            LocationCode = reader.GetString(reader.GetOrdinal("LocationCode")),
                            Description = reader.GetString(reader.GetOrdinal("Description"))
                        });
                    }
                }
            }

            return Ok(locationList);
        }


    }
}
