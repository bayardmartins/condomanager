namespace CondoManager.Repositories
{
    public class ApartmentRepository : BaseRepository<Apartment>, IApartmentRepository
    {
        public ApartmentRepository(DataContext dataContext) : base(dataContext) {}

        public override async Task Add(Apartment apartment)
        {
            await base.Add(apartment);
        }

        public override async Task Update(Apartment condo)
        {
            var ApartmentToUpdate = await dbSet.FindAsync(condo.Id);
            if (ApartmentToUpdate == null)
            {
                throw new NullReferenceException();
            }

            ApartmentToUpdate.Number = condo.Number;
            ApartmentToUpdate.Floor = condo.Floor;
            ApartmentToUpdate.BlockId = condo.BlockId;
        }

        public async Task RemoveResident(int idApartment, Resident resident)
        {
            Apartment apartment = await dbSet.FindAsync(idApartment);
            if(apartment == null)
            {
                throw new NullReferenceException();
            }
            apartment.ResidentList.Remove(resident);
        }

        public async Task AddResident(int idApartment,Resident resident)
        {
            Apartment apartment = await dbSet.FindAsync(idApartment);
            if(apartment == null)
            {
                throw new NullReferenceException();
            }
            if(apartment.ResidentList == null) { apartment.ResidentList = new List<Resident>(); }
            apartment.ResidentList.Add(resident);
        }

        public IEnumerable<Apartment> GetByBlockId(int blockId)
        {
            return dbSet.Where(apartment =>  apartment.BlockId == blockId);
        }
    }
}