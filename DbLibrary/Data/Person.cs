namespace DbLibrary.Data;

public class Person
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }

    public string Title { get; set; } = string.Empty;
    
    public int GroupId { get; set; }
    public Group? Group { get; set; }
}