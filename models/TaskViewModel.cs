public class TaskViewModel
{
    public string Title { get; set; }

    public Task MapTo()
    {
        return new Task(Title, false);
    }
}