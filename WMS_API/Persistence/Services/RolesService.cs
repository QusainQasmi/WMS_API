using AutoMapper;
using WMS_API.DTO;
using WMS_API.Models;
using WMS_API.Persistence.IRepositories;
using WMS_API.Persistence.IServices;

namespace WMS_API.Persistence.Services
{
    public class RolesService : BaseService<STP_Roles, STP_RolesDto>, IRolesService
    {
        private readonly IRolesRepository _repo;
        public RolesService(IRolesRepository repo, IMapper mapper): base(repo, mapper)
        {
            _repo = repo;
        }
    }
}
