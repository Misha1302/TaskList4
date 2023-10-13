namespace TaskList4;

public class Person : Entity
{
    public string Name { get; set; } = null!;
    public string Password { get; set; } = null!;
    public List<Task> Tasks { get; set; } = new List<Task>();
}