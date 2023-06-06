using Microsoft.EntityFrameworkCore;
using Tryitter;

class PostRepository : IPostRepository
{
    private readonly TryitterContext _context;
    public PostRepository(TryitterContext context)
    {
        _context = context;
    }
    public async Task<Post> CreateAsync(string message, User user)
    {

        var newPost = new Post
        {
            User = user,
            Message = message,
            Date = DateTime.Now
        };
        await _context.Posts.AddAsync(newPost);
        await _context.SaveChangesAsync();
        return newPost;
    }

    public async Task<List<Post>> GetPostsAsync()
    {
        return await _context.Posts.ToListAsync();
    }

    public async Task<string> UpdateAsync(string message, int postId)
    {
        Post post = await _context.Posts.Where(post => post.PostId == postId).FirstAsync();

        post.Message = message;
        _context.Update(post);
        await _context.SaveChangesAsync();
        return "Post atualizado com sucesso.";
    }

    public async Task<Post> GetPostByIdAsync(int postId)
    {
        return await _context.Posts.Where(post => post.PostId == postId).FirstAsync();
    }

    public void DeletePostAsync(Post post)
    {
        _context.Posts.Remove(post);
        _context.SaveChanges();
    }
}