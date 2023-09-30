using System.ComponentModel.DataAnnotations;

public record Task(Guid id,string title, bool done);