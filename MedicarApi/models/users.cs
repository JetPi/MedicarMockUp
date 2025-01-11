using Microsoft.EntityFrameworkCore;

public class UserContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public string DbPath { get; }

    public UserContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "user.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"Data Source={DbPath}");
};

public class User
{
    public readonly string Id;
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public readonly DateTime CreatedAt;
    public DateTime UpdatedAt { get; set; }

    public User()
    {
        CreatedAt = DateTime.UtcNow;
    }
}
