namespace DbLibrary.Data;

public class Group
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public ICollection<Person> Persons { get; set; } = [];
}