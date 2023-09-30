using DotNetEnv;

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
    Task task = model.MapTo();
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

app.MapPut("/api/complete-task/{id}", (Guid id, AppDbContext db) =>
{
    Task t = db.Tasks.FirstOrDefault(t => t.Id == id);
    if (t == null)
        return Results.StatusCode(StatusCodes.Status404NotFound);

    t.Done = true;
    db.Update(t);
    db.SaveChanges();

    return Results.StatusCode(StatusCodes.Status200OK);
});

app.Run();