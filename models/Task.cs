using System.ComponentModel.DataAnnotations;

public record Task(string title, bool done)
{
    [Key]
    public string Id { get; set; }
}