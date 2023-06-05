namespace Tryitter;

public class User
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int Module { get; set; }
    public string Password { get; set; }
    public string? Status { get; set; }
    public virtual List<Post>? Posts { get; set; }
}