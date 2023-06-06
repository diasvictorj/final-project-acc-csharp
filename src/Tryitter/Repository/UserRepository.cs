using Microsoft.EntityFrameworkCore;
using Tryitter;

class UserRepository : IUserRepository
{
    private readonly TryitterContext _context;
    public UserRepository(TryitterContext context)
    {
        _context = context;
    }
    public async Task<User> CreateAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> GetByIdAsync(int userId)
    {
        return await _context.Users.Where(user => user.UserId == userId).FirstAsync();
    }

    public async Task<User> LoginAsync(UserLogin user)
    {
        var userLogin = await _context.Users.
            Where(us => us.Email == user.Email && us.Password == user.Password).FirstAsync();

        return userLogin;
    }
}