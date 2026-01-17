using Postgrest.Attributes;
using Postgrest.Models;

namespace who_took_it_backend.Models;

[Table("Embedding")]
public class Embedding : BaseModel
{
    [PrimaryKey("id", false)]
    public Guid Id { get; set; }

    [Column("person_id")]
    public Guid PersonId { get; set; }

    // easiest for jsonb: store as raw JSON string
    [Column("vector")]
    public string VectorJson { get; set; } = "[]";

    [Column("created_at")]
    public DateTimeOffset CreatedAt { get; set; }

    [Column("model")]
    public string? Model { get; set; }

    [Column("source_image_key")]
    public string? SourceImageKey { get; set; }
}