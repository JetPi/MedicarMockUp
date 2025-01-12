using Microsoft.EntityFrameworkCore;
using Types;

public class ClientContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public string DbPath { get; }

    public ClientContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "client.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"Data Source={DbPath}");
};

public class Client : User
{
    public IVehicle[] Preference { get; set; } = [];
    public int TotalSpent { get; set; }
}
