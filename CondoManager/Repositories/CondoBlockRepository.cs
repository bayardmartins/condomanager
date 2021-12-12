using CondoManager.Models;

namespace CondoManager.Repositories
{
    public class CondoBlockRepository : BaseRepository<CondoBlock>, ICondoBlockRepository
    {
        private readonly DataContext _context;
        public CondoBlockRepository(DataContext dataContext) : base(dataContext) {}

        public override async Task Update(CondoBlock condoBlock)
        {
            var condoBlockToUpdate = await _context.CondoBlocks.FindAsync(condoBlock.Id);
            if (condoBlockToUpdate == null)
            {
                throw new NullReferenceException();
            }

            condoBlockToUpdate.Name = condoBlock.Name;
            condoBlockToUpdate.CondoId = condoBlock.CondoId;
        }

        public async Task RemoveApartament(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task AddApartament(Apartment apartment)
        {
            throw new NotImplementedException();
        }
    }
}