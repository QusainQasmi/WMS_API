using WMS_API.DTOs;
using WMS_API.Models;
using WMS_API.Persistence.Services;

namespace WMS_API.Persistence.IServices
{
    public interface ILocationsService : IBaseService<Location, LocationDto>
    {
    }
}
