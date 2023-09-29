using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

public class AppDbContext : DbContext
{
    public DbSet<Task> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        Env.Load();
        string dbPass = Env.GetString("DB_PASS");

        JToken jAppSettings = JToken.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "appsettings.json")));
        string connString = jAppSettings["ConnectionStrings"]?["DefaultConnection"]?.ToString();
        connString = connString.Replace("{pass}", dbPass);

        optionsBuilder.UseSqlServer(connString);
    }
}