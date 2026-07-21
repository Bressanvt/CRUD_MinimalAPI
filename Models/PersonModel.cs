namespace Person.Models;

public class PersonModel
{
    public PersonModel() { }

    public PersonModel(string name)
    {
        Name = name;
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
