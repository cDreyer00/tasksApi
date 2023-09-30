using System.ComponentModel.DataAnnotations;

public class Task
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public bool Done { get; set; }

    public Task(Guid Id, string Title, bool Done)
    {
        this.Id = Id;
        this.Title = Title;
        this.Done = Done;
    }
}