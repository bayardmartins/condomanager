namespace CondoManager.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Entity
    {
        internal readonly DataContext _context;
        internal DbSet<T> dbSet;
        public BaseRepository(DataContext context)
        {
            _context = context;
            dbSet = context.Set<T>();
        }
        public async virtual Task<T> Get(int id)
        {
            return await dbSet.FindAsync(id);
        }
        public async virtual Task<IEnumerable<T>> GetAll()
        { 
            return await dbSet.ToListAsync<T>();
        }
        public async virtual Task Add(T item)
        {
            await dbSet.AddAsync(item);
        }
        public async virtual Task Delete(int id)
        {
            var itemToDelete = await dbSet.FindAsync(id);
            if (itemToDelete == null)
            {
                throw new NullReferenceException();
            }
            dbSet.Remove(itemToDelete);
        }
        public virtual async Task Update(T item)
        {
            throw new NotImplementedException();
        }
    }
} 