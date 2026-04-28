using WMS_API.Models;

namespace WMS_API.Persistence.IRepositories
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        public Task<List<T>> GetAll();
        public Task<T> GetDataById(int id);
        public Task<T> Create(T entity);
        public Task Update(T entity);
        public Task Delete(int id);
    }
}
