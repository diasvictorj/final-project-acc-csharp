using Microsoft.EntityFrameworkCore;
using Tryitter;

public class TryitterContext : DbContext
{
    public DbSet<Post> Posts { get; set; }
    public DbSet<User> Users { get; set; }

    public TryitterContext() : base() { }
    public TryitterContext(DbContextOptions<TryitterContext> options)
    : base(options) 
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = @"Server=127.0.0.1;Database=tryitter_db;User=SA;Password=Password12!;TrustServerCertificate=true";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PostMap());
        base.OnModelCreating(modelBuilder);
    }
}