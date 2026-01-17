namespace who_took_it_backend.Models;

public class Image
{
    public int Id { get; set; }
    public string? Url { get; set; }
    public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.UtcNow;
}