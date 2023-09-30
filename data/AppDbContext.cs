using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

public class AppDbContext : DbContext
{
    public DbSet<Task> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(GetConnString_Option2());
    }

    string GetConnString_Option1()
    {
        Env.Load();
        string dbPass = Env.GetString("DB_PASS");

        JToken jAppSettings = JToken.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "appsettings.json")));
        string connString = jAppSettings["ConnectionStrings"]?["DefaultConnection"]?.ToString();
        connString = connString.Replace("{pass}", dbPass);
        return connString;
    }

    string GetConnString_Option2()
    {
        Env.Load();
        string dbConnString = Env.GetString("SQLCONNSTR_connectionString");
        return dbConnString;
    }
}