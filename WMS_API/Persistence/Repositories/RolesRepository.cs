using WMS_API.Data;
using WMS_API.Models;
using WMS_API.Persistence.IRepositories;

namespace WMS_API.Persistence.Repositories
{
    public class RolesRepository : BaseRepository<STP_Roles>, IRolesRepository
    {
        public RolesRepository(CmsDbContext context) : base(context)
        {
        }
    }
}
