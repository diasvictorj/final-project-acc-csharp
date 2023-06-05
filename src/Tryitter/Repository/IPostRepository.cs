using Tryitter;

public interface IPostRepository
{
    Post Create(string message, User user);
    List<Post> GetPosts();
}