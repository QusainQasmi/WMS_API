using WMS_API.DTO;

namespace WMS_API.Persistence.IServices
{
    public interface IAuthService
    {
        Task<LoginRespDto?> Login(LoginDto model);
    }
}
