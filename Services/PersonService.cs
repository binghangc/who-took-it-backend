using System;
using System.Collections.Generic;
using who_took_it_backend.Models;

namespace who_took_it_backend.Services;

public static class PersonService
{
    static List<Person> People { get; }

    static PersonService()
    {
        People = new List<Person>();
    }

    public static List<Person> GetAll() => People;

    public static Person? Get(Guid id) => People.FirstOrDefault(p => p.Id == id);

    public static void Add(Person person)
    {
        if (person.Id == Guid.Empty)
        {
            person.Id = Guid.NewGuid();
        }

        People.Add(person);
    }

    public static void Delete(Guid id)
    {
        var person = Get(id);
        if (person is null)
            return;

        People.Remove(person);
    }

    public static void Update(Person person)
    {
        var index = People.FindIndex(p => p.Id == person.Id);
        if (index == -1)
            return;

        People[index] = person;
    }
}