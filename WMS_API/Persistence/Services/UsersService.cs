using AutoMapper;
using WMS_API.DTO;
using WMS_API.DTOs;
using WMS_API.Models;
using WMS_API.Persistence.IRepositories;
using WMS_API.Persistence.IServices;

namespace WMS_API.Persistence.Services
{
    public class UsersService : BaseService<Sys_Users, Sys_UsersDto>, IUsersService
    {
        private readonly IUsersRepository _repo;
        public UsersService(IUsersRepository repo, IMapper mapper)
            : base(repo, mapper)
        {
            _repo = repo;
        }
    }
}
