namespace CondoManager.Repositories
{
    public class UserRepository : IUserRepository
    {
        internal readonly DataContext _context;
        internal DbSet<User> dbSet;
        public UserRepository(DataContext context)
        {
            _context = context;
            dbSet = context.Set<User>();
        }
        public async Task<User> GetUserByUserName(string userName)
        {
            var user = await dbSet.FindAsync(userName);
            if (user == null)
            {
                return null;
            }
            return user;
        }
        
        public async Task Register(User user)
        {
            var existingUser = await dbSet.FindAsync(user.UserName);
            if (existingUser != null)
            {
                throw new Exception("UserName already exists");
            }
            await dbSet.AddAsync(user);
        }

    }
}