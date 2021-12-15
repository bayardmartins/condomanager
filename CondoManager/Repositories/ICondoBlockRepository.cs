namespace CondoManager.Repositories
{
    public interface ICondoBlockRepository : IBaseRepository<CondoBlock>
    {
        Task Update(CondoBlock condoBlock);
        Task RemoveApartment(int idCondoBlock, Apartment apartment);
        Task AddApartment(int idCondoBlock, Apartment apartment);
        IEnumerable<CondoBlock> GetByCondoId(int condoId);
    }
}