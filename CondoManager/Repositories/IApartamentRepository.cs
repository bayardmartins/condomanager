using CondoManager.Models;

namespace CondoManager.Repositories
{
    public interface IApartamentRepository
    {
        Task Update(Apartment condo);
        Task RemoveResident(int Id);
        Task AddResident(Resident resident);
    }
}