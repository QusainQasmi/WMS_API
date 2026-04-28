using WMS_API.Mapper;
using WMS_API.Models;

namespace WMS_API.DTO
{
    public class STP_RolesDto : BaseDto, IMapFrom<STP_Roles>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}
