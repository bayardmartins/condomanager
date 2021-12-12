namespace CondoManager.Repositories
{
    public interface ICondoBlockRepository : IBaseRepository<CondoBlock>
    {
        Task Update(CondoBlock condoBlock);
        Task RemoveApartament(int Id);
        Task AddApartament(Apartment apartment);
    }
}