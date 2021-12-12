namespace CondoManager.Repositories
{
    public interface ICondoRespository : IBaseRepository<Condo>
    {
        Task Update(Condo condo);
        Task RemoveBlock(int Id);
        Task AddBlock(Apartment apartment);
    }
}