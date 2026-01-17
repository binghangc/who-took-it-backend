using who_took_it_backend.Models;

namespace who_took_it_backend.Services;

public static class EmbeddingService
{
    static List<Embedding> Embeddings { get; }

    static EmbeddingService()
    {
        Embeddings = new List<Embedding>();
    }

    public static List<Embedding> GetAll() => Embeddings;

    public static List<Embedding> GetByPersonId(Guid personId)
    {
        return Embeddings
            .Where(e => e.PersonId == personId)
            .OrderByDescending(e => e.CreatedAt)
            .ToList();
    }

    public static Embedding? Get(Guid id)
    {
        return Embeddings.FirstOrDefault(e => e.Id == id);
    }

    public static void Add(Embedding embedding)
    {
        if (embedding.Id == Guid.Empty)
        {
            embedding.Id = Guid.NewGuid();
        }

        if (embedding.CreatedAt == default)
        {
            embedding.CreatedAt = DateTimeOffset.UtcNow;
        }

        Embeddings.Add(embedding);
    }

    public static void Delete(Guid id)
    {
        var embedding = Get(id);
        if (embedding is null)
            return;

        Embeddings.Remove(embedding);
    }

    public static void Update(Embedding embedding)
    {
        var index = Embeddings.FindIndex(e => e.Id == embedding.Id);
        if (index == -1)
            return;

        Embeddings[index] = embedding;
    }
}