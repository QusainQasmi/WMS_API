using WMS_API.DTO;
using WMS_API.DTOs;
using WMS_API.Models;
using WMS_API.Persistence.IServices;

namespace WMS_API.Controllers
{
    public class UsersController : BaseController<Sys_Users, Sys_UsersDto>
    {
        public UsersController(IBaseService<Sys_Users, Sys_UsersDto> service) : base(service)
        {

        }
    }
}
