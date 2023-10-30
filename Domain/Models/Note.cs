namespace MinimalApiPractise.Domain.Models;

public class Note
{
    public int Id { get; set; }
    public string? Comment { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}