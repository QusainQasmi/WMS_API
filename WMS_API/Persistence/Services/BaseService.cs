using AutoMapper;
using WMS_API.Models;
using WMS_API.Persistence.IRepositories;
using WMS_API.Persistence.IServices;

namespace WMS_API.Persistence.Services
{
    public class BaseService<TEntity, TDto> : IBaseService<TEntity, TDto>
    where TEntity : BaseModel, new()
    {
        protected readonly IBaseRepository<TEntity> _repo;
        protected readonly IMapper _mapper;

        public BaseService(IBaseRepository<TEntity> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<TDto>> GetAll()
        {
            var data = await _repo.GetAll();
            return _mapper.Map<List<TDto>>(data);
        }

        public async Task<TDto> GetDataById(int id)
        {
            var entity = await _repo.GetDataById(id);
            return _mapper.Map<TDto>(entity);
        }

        public async Task<TDto> Create(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            var result = await _repo.Create(entity);
            return _mapper.Map<TDto>(result);
        }

        public async Task Update(int id, TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            entity.Id = id;
            await _repo.Update(entity);
        }

        public async Task Delete(int id)
        {
            await _repo.Delete(id);
        }
    }

}
