namespace TaskList4;

public class Person : Entity
{
    public required string Name { get; set; }
    public required string Password { get; set; }
    public required List<Task> Tasks { get; set; }
}