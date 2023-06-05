using Tryitter;

public interface IUserRepository
{
    User Create(User user);
    User GetById(int userId);
}