using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WMS_API.Data;
using WMS_API.Models;

namespace WMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly WmsDbContext _context;
        public CategoryController(WmsDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllData")]
        public async Task<ActionResult<IEnumerable<Warehouse>>> GetAllCategory()
        {
            return Ok(await _context.Categories.ToListAsync());
        }
    }
}
