var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();

app.MapGet("/", (AppDbContext db) =>
{
    return db.Tasks;
});

app.Run();