using Microsoft.EntityFrameworkCore;
using WMS_API.Data;
using WMS_API.Models;
using WMS_API.Persistence.IRepositories;

namespace WMS_API.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        private readonly CmsDbContext _context;
        private readonly DbSet<T> _db;

        public BaseRepository(CmsDbContext context)
        {
            _context = context;
            _db = context.Set<T>();
        }

        //public async Task<List<T>> GetAll()
        //    => await _db.Where(x => x.IsDeleted == null || x.IsDeleted == false).ToListAsync();
        public async Task<List<T>> GetAll()
              => await _db.ToListAsync();

        public async Task<T> GetDataById(int id)
        {
            var body = await _db.FirstOrDefaultAsync(x => x.Id == id);
            return body;
        }

        public async Task<T> Create(T entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            await _db.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(T entity)
        {
            entity.UpdatedDate = DateTime.UtcNow;
            _db.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetDataById(id);
            //entity.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
    }

}
