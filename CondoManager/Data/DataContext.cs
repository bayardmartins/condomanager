namespace CondoManager.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) {}

        public DbSet<Condo> Condos { get; set; }
        public DbSet<CondoBlock> CondoBlocks { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Resident> Residents { get; set; }
        public DbSet<User> Users { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(user => new { user.UserName });
        }
    }
}