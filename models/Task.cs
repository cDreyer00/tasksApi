public record Task(string title, bool done)
{
    public Guid Id { get; set; }
}