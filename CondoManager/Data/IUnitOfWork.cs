namespace CondoManager.Data
{
    public interface IUnitOfWork
    {
         void Commit();
         void RollBack();
    }
}