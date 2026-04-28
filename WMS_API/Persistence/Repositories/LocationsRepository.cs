using WMS_API.Data;
using WMS_API.Models;
using WMS_API.Persistence.IRepositories;

namespace WMS_API.Persistence.Repositories
{
    public class LocationsRepository : BaseRepository<Location>, ILocationsRepository
    {
        public LocationsRepository(CmsDbContext context) : base(context)
        {
        }
    }
}
