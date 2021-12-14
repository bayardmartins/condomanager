using CondoManager.Models;

namespace CondoManager.Data
{
    public interface IDataContext
    {
        DbSet<Condo> Condos { get; set; }
        DbSet<CondoBlock> CondoBlocks { get; set; }
        DbSet<Apartment> Apartments { get; set; }
        DbSet<Resident> Residents { get; set; }
        DbSet<User> Users { get; set; }        
    }
}