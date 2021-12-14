namespace CondoManager.Repositories
{
    public interface IUserRepository
    {
         Task<User> GetUserByUserName(string userName);
         Task Register(User user);
    }
}