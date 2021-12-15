namespace CondoManager.Repositories
{
    public class ResidentRepository : BaseRepository<Resident>, IResidentRepository
    {
        public ResidentRepository(DataContext dataContext) : base(dataContext) {}

        public override async Task Update(Resident resident)
        {
            var residentToUpdate = await dbSet.FindAsync(resident.Id);
            if (residentToUpdate == null)
            {
                throw new NullReferenceException();
            }

            residentToUpdate.Name = resident.Name;
            residentToUpdate.BirthDay = resident.BirthDay;
            residentToUpdate.Phone = resident.Phone;
            residentToUpdate.Cpf = resident.Cpf;
            residentToUpdate.Email = resident.Email;
            residentToUpdate.ApartmentId = resident.ApartmentId;
        }

        public IEnumerable<Resident> GetByApartmentId(int idApartment)
        {
            return dbSet.Where(resident => resident.ApartmentId == idApartment);
        }
    }
}