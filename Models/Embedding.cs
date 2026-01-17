namespace who_took_it_backend.Models;

public class Embedding
{
    // Primary key (uuid in Supabase)
    public Guid Id { get; set; }

    // Foreign key -> Person.Id (uuid in Supabase)
    public Guid PersonId { get; set; }

    // Store the embedding as a JSON array in Supabase (jsonb).
    // This binds nicely from/into JSON requests too.
    public List<float> Vector { get; set; } = new();

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
}