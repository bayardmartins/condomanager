namespace CondoManager.Repositories
{
    public class CondoBlockRepository : BaseRepository<CondoBlock>, ICondoBlockRepository
    {
        public CondoBlockRepository(DataContext dataContext) : base(dataContext) {}

        public override async Task Update(CondoBlock condoBlock)
        {
            var condoBlockToUpdate = await dbSet.FindAsync(condoBlock.Id);
            if (condoBlockToUpdate == null)
            {
                throw new NullReferenceException();
            }

            condoBlockToUpdate.Name = condoBlock.Name;
            condoBlockToUpdate.CondoId = condoBlock.CondoId;
        }

        public async Task RemoveApartment(int idCondoBlock, Apartment apartment)
        {
            CondoBlock condoBlock = await dbSet.FindAsync(idCondoBlock);
            if(condoBlock == null)
            {
                throw new NullReferenceException();
            }
            condoBlock.ApartamentList.Remove(apartment);
        }

        public async Task AddApartment(int idCondoBlock, Apartment apartment)
        {
            CondoBlock condoBlock = await dbSet.FindAsync(idCondoBlock);
            if(condoBlock == null)
            {
                throw new NullReferenceException();
            }
            if(condoBlock.ApartamentList == null) { condoBlock.ApartamentList = new List<Apartment>(); }
            condoBlock.ApartamentList.Add(apartment);
        }

        public IEnumerable<CondoBlock> GetByCondoId(int condoId)
        {
            return dbSet.Where(block => block.CondoId == condoId);
        }
    }
}