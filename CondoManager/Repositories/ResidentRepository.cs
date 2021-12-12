using CondoManager.Models;

namespace CondoManager.Repositories
{
    public class ResidentRepository : BaseRepository<Resident>, IResidentRepository
    {
        private readonly DataContext _context;
        public ResidentRepository(DataContext dataContext) : base(dataContext) {}

        public override async Task Update(Resident resident)
        {
            var residentToUpdate = await _context.Residents.FindAsync(resident.Id);
            if (residentToUpdate == null)
            {
                throw new NullReferenceException();
            }

            residentToUpdate.Name = resident.Name;
            residentToUpdate.BirthDay = resident.BirthDay;
            residentToUpdate.Phone = resident.Phone;
            residentToUpdate.Cpf = resident.Cpf;
            residentToUpdate.Email = resident.Email;
            residentToUpdate.ApartamentId = resident.ApartamentId;
        }
    }
}