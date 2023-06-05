namespace Tryitter;

public class Post
{
    public int PostId { get; set; }
    public string Message { get; set; }
    public DateTime Date { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; }
}