using Microsoft.EntityFrameworkCore;
using CondoManager.Models;

namespace CondoManager.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) {}

        public DbSet<Condo> Condos { get; set; }
        public DbSet<CondoBlock> CondoBlocks { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Resident> Residents { get; set; }
    }
}