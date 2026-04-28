using AutoMapper;
using WMS_API.DTOs;
using WMS_API.Models;
using WMS_API.Persistence.IRepositories;
using WMS_API.Persistence.IServices;

namespace WMS_API.Persistence.Services
{
    public class LocationsService : BaseService<Location, LocationDto>, ILocationsService
    {
        private readonly ILocationsRepository _repo;
        public LocationsService(ILocationsRepository repo, IMapper mapper)
            : base(repo, mapper)
        {
            _repo = repo;
        }
    }
}
