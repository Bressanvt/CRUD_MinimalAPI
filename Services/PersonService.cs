using Person.Models;

namespace Person.Services;

public class PersonService
{
    private readonly List<PersonModel> _persons = [];

    public List<PersonModel> GetAll() => _persons;

    public PersonModel? GetById(Guid id) =>
        _persons.FirstOrDefault(p => p.Id == id);

    public PersonModel Create(string name)
    {
        var person = new PersonModel(name);
        _persons.Add(person);
        return person;
    }

    public bool Update(Guid id, string name)
    {
        var person = GetById(id);
        if (person is null)
            return false;

        person.Name = name;
        return true;
    }

    public bool Delete(Guid id)
    {
        var person = GetById(id);
        if (person is null)
            return false;

        _persons.Remove(person);
        return true;
    }
}
