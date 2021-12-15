namespace CondoManager.Repositories
{
    public interface IResidentRepository : IBaseRepository<Resident>
    {
         Task Update(Resident resident);
         IEnumerable<Resident> GetByApartmentId(int idApartment);
    }
}