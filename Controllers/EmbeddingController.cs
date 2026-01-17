using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using who_took_it_backend.Models;
using who_took_it_backend.Services;

namespace who_took_it_backend.Controllers;

[ApiController]
[Route("api/embeddings")]
public class EmbeddingController : ControllerBase
{
    // GET /api/embeddings
    [HttpGet]
    public ActionResult<List<Embedding>> GetAll()
    {
        return Ok(EmbeddingService.GetAll());
    }

    // GET /api/embeddings/{id}
    [HttpGet("{id:guid}")]
    public ActionResult<Embedding> GetById(Guid id)
    {
        var embedding = EmbeddingService.Get(id);
        if (embedding is null)
            return NotFound();

        return Ok(embedding);
    }

    // POST /api/embeddings
    [HttpPost]
    public ActionResult<Embedding> Create([FromBody] Embedding embedding)
    {
        // Service will generate Id if empty
        EmbeddingService.Add(embedding);
        return CreatedAtAction(nameof(GetById), new { id = embedding.Id }, embedding);
    }

    // PUT /api/embeddings/{id}
    [HttpPut("{id:guid}")]
    public IActionResult Update(Guid id, [FromBody] Embedding embedding)
    {
        var existing = EmbeddingService.Get(id);
        if (existing is null)
            return NotFound();

        // Ensure path id is the source of truth
        embedding.Id = id;

        EmbeddingService.Update(embedding);
        return NoContent();
    }

    // DELETE /api/embeddings/{id}
    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        var existing = EmbeddingService.Get(id);
        if (existing is null)
            return NotFound();

        EmbeddingService.Delete(id);
        return NoContent();
    }
}