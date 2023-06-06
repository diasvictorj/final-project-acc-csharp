using Tryitter;

public interface IPostRepository
{
    Task<Post> CreateAsync(string message, User user);
    Task<List<Post>> GetPostsAsync();
    Task<string> UpdateAsync(string message, int postId);
    Task<Post> GetPostByIdAsync(int postId);
    void DeletePostAsync(Post post);
}