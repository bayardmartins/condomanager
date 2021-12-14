using CondoManager.Models;

namespace CondoManager.Repositories
{
    public interface IApartmentRepository : IBaseRepository<Apartment>
    {
        Task Update(Apartment condo);
        Task RemoveResident(int idApartment, Resident resident);
        Task AddResident(int idApartment,Resident resident);
    }
}