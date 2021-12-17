namespace CondoManager.Data
{
    public interface IDataContext
    {
        DbSet<Condo> Condos { get; set; }
        DbSet<Block> Blocks { get; set; }
        DbSet<Apartment> Apartments { get; set; }
        DbSet<Resident> Residents { get; set; }
        DbSet<User> Users { get; set; }        
    }
}