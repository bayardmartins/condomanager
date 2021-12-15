namespace CondoManager.Repositories
{
    public interface ICondoRepository : IBaseRepository<Condo>
    {
        Task Update(Condo condo);
        Task RemoveBlock(int idCondo, CondoBlock condoBlock);
        Task AddBlock(int idCondo, CondoBlock condoBlock);
    }
}