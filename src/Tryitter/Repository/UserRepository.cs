using Tryitter;

class UserRepository : IUserRepository
{
    private readonly TryitterContext _context;
    public UserRepository(TryitterContext context)
    {
        _context = context;
    }
    public User Create(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }

    public User GetById(int userId)
    {
        return _context.Users.Where(user => user.UserId == userId).First();
    }
}