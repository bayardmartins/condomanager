namespace CondoManager.Repositories
{
    public class BlockRepository : BaseRepository<Block>, IBlockRepository
    {
        public BlockRepository(DataContext dataContext) : base(dataContext) {}

        public override async Task Update(Block block)
        {
            var condoBlockToUpdate = await dbSet.FindAsync(block.Id);
            if (condoBlockToUpdate == null)
            {
                throw new NullReferenceException();
            }

            condoBlockToUpdate.Name = block.Name;
            condoBlockToUpdate.CondoId = block.CondoId;
        }

        public async Task RemoveApartment(int idBlock, Apartment apartment)
        {
            Block block = await dbSet.FindAsync(idBlock);
            if(block == null)
            {
                throw new NullReferenceException();
            }
            block.ApartamentList.Remove(apartment);
        }

        public async Task AddApartment(int idBlock, Apartment apartment)
        {
            Block block = await dbSet.FindAsync(idBlock);
            if(block == null)
            {
                throw new NullReferenceException();
            }
            if(block.ApartamentList == null) { block.ApartamentList = new List<Apartment>(); }
            block.ApartamentList.Add(apartment);
        }

        public IEnumerable<Block> GetByCondoId(int condoId)
        {
            return dbSet.Where(block => block.CondoId == condoId);
        }
    }
}