using WMS_API.DTO;
using WMS_API.Models;
using WMS_API.Persistence.IServices;

namespace WMS_API.Controllers
{
    public class RolesController : BaseController<STP_Roles, STP_RolesDto>
    {
        public RolesController(IBaseService<STP_Roles, STP_RolesDto> service) : base(service)
        {

        }
    }
}
