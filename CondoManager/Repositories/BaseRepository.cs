using CondoManager.Data;
using CondoManager.Models;

namespace CondoManager.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Entity
    {
        private readonly DataContext _context;
        private DbSet<T> dbSet;
        public BaseRepository(DataContext context)
        {
            _context = context;
            dbSet = context.Set<T>();
        }
        public async Task<T> Get(int id)
        {
            return await dbSet.FindAsync(id);
        }
        public async Task<IEnumerable<T>> GetAll()
        { 
            return await dbSet.ToListAsync<T>();
        }
        public async Task Add(T item)
        {
            dbSet.Add(item);
        }
        public async Task Delete(int id)
        {
            var itemToDelete = await dbSet.FindAsync(id);
            if (itemToDelete == null)
                throw new NullReferenceException();
            {}
            dbSet.Remove(itemToDelete);
        }
        public virtual async Task Update(T item)
        {
            throw new NotImplementedException();
        }
    }
} 