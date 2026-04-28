using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WMS_API.Data;
using WMS_API.DTOs;
using WMS_API.Models;
using WMS_API.Persistence.IServices;

namespace WMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : BaseController<Location, LocationDto>
    {
        public LocationsController(IBaseService<Location, LocationDto> service): base(service)
        {

        }
    }
}