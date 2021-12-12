using CondoManager.Models;

namespace CondoManager.Repositories
{
    public class CondoRepository : BaseRepository<Condo>, ICondoRespository
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

        public async Task RemoveBlock(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task AddBlock(Apartment apartment)
        {
            throw new NotImplementedException();
        }
    }
}