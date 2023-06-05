using Tryitter;

class PostRepository : IPostRepository
{
    private readonly TryitterContext _context;
    public PostRepository(TryitterContext context)
    {
        _context = context;
    }
    public Post Create(string message, User user)
    {

        var newPost = new Post
        {
            User = user,
            Message = message,
            Date = DateTime.Now
        };
        _context.Posts.Add(newPost);
        _context.SaveChanges();
        return newPost;
    }

    public List<Post> GetPosts()
    {
        return _context.Posts.ToList();
    }
}