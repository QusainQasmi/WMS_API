using WMS_API.Data;
using WMS_API.Models;
using WMS_API.Persistence.IRepositories;

namespace WMS_API.Persistence.Repositories
{
    public class UsersRepository : BaseRepository<Sys_Users>, IUsersRepository
    {
        public UsersRepository(CmsDbContext context) : base(context)
        {
        }
    }
}
