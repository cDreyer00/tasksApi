using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

public class AppDbContext : DbContext
{
    public DbSet<Task> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        JToken jAppSettings = JToken.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "appsettings.json")));
        optionsBuilder.UseSqlServer(jAppSettings["ConnectionStrings"]?["DefaultConnection"]?.ToString());
    }
}