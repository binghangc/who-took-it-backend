using System;
using System.Collections.Generic;
namespace who_took_it_backend.Models;

public class Person
{
    public Guid Id { get; set; }

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    public DateTimeOffset? LastSeenAt { get; set; }
}