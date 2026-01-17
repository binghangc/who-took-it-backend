using Microsoft.AspNetCore.Mvc;
using who_took_it_backend.Models;
using who_took_it_backend.Services;

namespace who_took_it_backend.Controllers;

[ApiController]
[Route("api")]
public class EmbeddingController : ControllerBase
{
    // GET /api/embeddings
    [HttpGet("embeddings")]
    public ActionResult<List<Embedding>> GetAll()
    {
        return Ok(EmbeddingService.GetAll());
    }

    // GET /api/embeddings/{id}
    [HttpGet("embeddings/{id:guid}")]
    public ActionResult<Embedding> GetById(Guid id)
    {
        var embedding = EmbeddingService.Get(id);
        if (embedding is null)
            return NotFound();

        return Ok(embedding);
    }

    // GET /api/persons/{personId}/embeddings
    [HttpGet("persons/{personId:guid}/embeddings")]
    public ActionResult<List<Embedding>> GetByPerson(Guid personId)
    {
        return Ok(EmbeddingService.GetByPersonId(personId));
    }

    // POST /api/persons/{personId}/embeddings
    [HttpPost("persons/{personId:guid}/embeddings")]
    public ActionResult<Embedding> CreateForPerson(Guid personId, [FromBody] Embedding embedding)
    {
        // Path param is source of truth
        embedding.PersonId = personId;

        EmbeddingService.Add(embedding);

        return CreatedAtAction(nameof(GetById), new { id = embedding.Id }, embedding);
    }

    // PUT /api/embeddings/{id}
    [HttpPut("embeddings/{id:guid}")]
    public IActionResult Update(Guid id, [FromBody] Embedding embedding)
    {
        var existing = EmbeddingService.Get(id);
        if (existing is null)
            return NotFound();

        // Ensure the route id wins
        embedding.Id = id;

        // Preserve existing person link if caller didn't provide one
        if (embedding.PersonId == Guid.Empty)
            embedding.PersonId = existing.PersonId;

        // Preserve CreatedAt if caller didn't provide one
        if (embedding.CreatedAt == default)
            embedding.CreatedAt = existing.CreatedAt;

        EmbeddingService.Update(embedding);
        return NoContent();
    }

    // DELETE /api/embeddings/{id}
    [HttpDelete("embeddings/{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        var existing = EmbeddingService.Get(id);
        if (existing is null)
            return NotFound();

        EmbeddingService.Delete(id);
        return NoContent();
    }
}