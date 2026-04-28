namespace WMS_API.Persistence.IServices
{
    public interface IBaseService<TEntity, TDto>
    {
        public Task<List<TDto>> GetAll();
        public Task<TDto> GetDataById(int id);
        public Task<TDto> Create(TDto dto);
        public Task Update(int id, TDto dto);
        public Task Delete(int id);
    }

}
