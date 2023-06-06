using Tryitter;

public interface IUserRepository
{
    Task<User> CreateAsync(User user);
    Task<User> GetByIdAsync(int userId);

    Task<User> LoginAsync(UserLogin user);
}