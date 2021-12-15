namespace CondoManager.Repositories
{
    public class CondoRepository : BaseRepository<Condo>, ICondoRepository
    {
        public CondoRepository(DataContext dataContext) : base(dataContext) {}

        public override async Task Update(Condo condo)
        {
            var condoToUpdate = await dbSet.FindAsync(condo.Id);
            if (condoToUpdate == null)
            {
                throw new NullReferenceException();
            }

            condoToUpdate.Name = condo.Name;
            condoToUpdate.Phone = condo.Phone;
            condoToUpdate.ManagerEmail = condo.ManagerEmail;
        }

        public async Task AddBlock(int idCondo, CondoBlock condoBlock)
        {
            Condo condo = await dbSet.FindAsync(idCondo);
            if(condo == null)
            {
                throw new NullReferenceException();
            }
            if(condo.BlockList == null) { condo.BlockList = new List<CondoBlock>(); }
            condo.BlockList.Add(condoBlock);
        }

        public async Task RemoveBlock(int idCondo, CondoBlock condoBlock)
        {
            Condo condo = await dbSet.FindAsync(idCondo);
            if(condo == null)
            {
                throw new NullReferenceException();
            }
            condo.BlockList.Remove(condoBlock);
        }
    }
}