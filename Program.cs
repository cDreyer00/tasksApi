using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();

app.MapGet("", (AppDbContext db) =>
{
    return "running";
});

app.MapGet("/api", (AppDbContext db) =>
{
    return "/api";
});

app.MapGet("/api/test", (AppDbContext db) =>
{
    return "/api/test";
});

app.MapGet("/api/tasks", (AppDbContext db) =>
{
    return new Task[1] { new("Test", false) };
    // return db.Tasks.ToArray();
});

app.MapPost("/api/tasks", (TaskViewModel model, AppDbContext db) =>
{
    Task task = model.MapTo();
    db.Add(task);
    db.SaveChanges();
    return $"new task {task} created\n" + task;
});

app.Run();