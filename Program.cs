var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
{
    Task task = new(Guid.NewGuid(), "new task", false);
    Task task2 = new(Guid.NewGuid(), "new task 2", true);
    return new Task[] { task, task2 };
});

app.Run();