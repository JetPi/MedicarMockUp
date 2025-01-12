using Microsoft.EntityFrameworkCore;
using Types;

public class EmployeeContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public string DbPath { get; }

    public EmployeeContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "employee.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"Data Source={DbPath}");
};

public class Employee : User
{
    public required IVehicle[] ProvidedVehicle { get; set; }
    public float AverageRating { get; set; }
    public float Earnings { get; set; }
}
