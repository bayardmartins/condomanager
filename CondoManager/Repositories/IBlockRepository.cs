namespace CondoManager.Repositories
{
    public interface IBlockRepository : IBaseRepository<Block>
    {
        Task Update(Block block);
        Task RemoveApartment(int idBlock, Apartment apartment);
        Task AddApartment(int idBlock, Apartment apartment);
        IEnumerable<Block> GetByCondoId(int condoId);
    }
}