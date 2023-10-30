using DotNetEnv;
using tasksApi.models;

Env.Load();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();

app.MapGet("/", (AppDbContext db) =>
{
    return $"Hello World";
});

app.MapGet("/api/tasks", (AppDbContext db) =>
{
    return db.Tasks;
});

app.MapPost("/api/tasks", (TaskViewModel model, AppDbContext db) =>
{
    Task task = model.MapToTask();
    db.Add(task);
    db.SaveChanges();

    return Results.StatusCode(StatusCodes.Status201Created);
});

app.MapDelete("/api/tasks/{id}", (Guid id, AppDbContext db) =>
{
    Task t = db.Tasks.SingleOrDefault(t => t.Id == id);
    if (t == null)
        return Results.StatusCode(StatusCodes.Status404NotFound);

    db.Remove(t);
    db.SaveChanges();

    return Results.StatusCode(StatusCodes.Status200OK);
});

app.MapPut("/api/tasks", (TaskViewModel model, AppDbContext db) =>
{
    Task task = model.CopyValuesToTask(db);
    if (task == null)
        return Results.StatusCode(StatusCodes.Status404NotFound);

    db.SaveChanges();
    return Results.StatusCode(StatusCodes.Status200OK);
});

app.Run();