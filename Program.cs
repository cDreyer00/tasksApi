// using System.Data.Common;
// using Microsoft.EntityFrameworkCore;

// var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddDbContext<AppDbContext>();

// var app = builder.Build();

// app.MapGet("/", (AppDbContext db) =>
// {
//     return "Hello World";
// });

// app.MapGet("/api/tasks", (AppDbContext db) =>
// {
//     return db.Tasks;
// });

// app.MapPost("/api/tasks", (TaskViewModel model, AppDbContext db) =>
// {
//     Task task = model.MapTo();
//     db.Add(task);
//     db.SaveChanges();
//     return $"new task {task} created\n" + task;
// });

// app.Run();