namespace CondoManager.Repositories
{
    public interface ICondoRepository : IBaseRepository<Condo>
    {
        Task Update(Condo condo);
        Task RemoveBlock(int idCondo, Block block);
        Task AddBlock(int idCondo, Block block);
    }
}