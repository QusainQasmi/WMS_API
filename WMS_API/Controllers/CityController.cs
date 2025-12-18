using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WMS_API.Data;
using WMS_API.Models;

namespace WMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly WmsDbContext _context;
        public CityController(WmsDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllData")]
        public async Task<ActionResult<IEnumerable<City>>> GetAllCity()
        {
            return Ok(await _context.City.ToListAsync());
        }
    }
}
