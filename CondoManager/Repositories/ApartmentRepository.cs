using CondoManager.Models;

namespace CondoManager.Repositories
{
    public class ApartmentRepository : BaseRepository<Apartment>, IApartamentRepository
    {
        private readonly DataContext _context;
        public ApartmentRepository(DataContext dataContext) : base(dataContext) {}

        public override async Task Update(Apartment condo)
        {
            var ApartmentToUpdate = await _context.Apartments.FindAsync(condo.Id);
            if (ApartmentToUpdate == null)
            {
                throw new NullReferenceException();
            }

            ApartmentToUpdate.Number = condo.Number;
            ApartmentToUpdate.Floor = condo.Floor;
            ApartmentToUpdate.CondoBlockId = condo.CondoBlockId;
        }

        public async Task RemoveResident(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task AddResident(Resident resident)
        {
            throw new NotImplementedException();
        }
    }
}