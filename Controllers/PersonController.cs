using Microsoft.AspNetCore.Mvc;
using who_took_it_backend.Models;
using who_took_it_backend.Services;

namespace who_took_it_backend.Controllers;

[ApiController]
[Route("api/persons")]
public class PersonController : ControllerBase
{
    // GET /api/persons
    [HttpGet]
    public ActionResult<List<Person>> GetAll()
    {
        return Ok(PersonService.GetAll());
    }

    // GET /api/persons/{id}
    [HttpGet("{id:guid}")]
    public ActionResult<Person> GetById(Guid id)
    {
        var person = PersonService.Get(id);
        if (person is null)
            return NotFound();

        return Ok(person);
    }

    // POST /api/persons
    [HttpPost]
    public ActionResult<Person> Create([FromBody] Person person)
    {
        // Service will generate Id if empty
        PersonService.Add(person);
        return CreatedAtAction(nameof(GetById), new { id = person.Id }, person);
    }

    // PUT /api/persons/{id}
    [HttpPut("{id:guid}")]
    public IActionResult Update(Guid id, [FromBody] Person person)
    {
        var existing = PersonService.Get(id);
        if (existing is null)
            return NotFound();

        // Ensure path id is the source of truth
        person.Id = id;

        PersonService.Update(person);
        return NoContent();
    }

    // DELETE /api/persons/{id}
    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        var existing = PersonService.Get(id);
        if (existing is null)
            return NotFound();

        PersonService.Delete(id);
        return NoContent();
    }
}