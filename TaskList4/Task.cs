namespace TaskList4;

public class Task : Entity
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required bool IsActive { get; set; }
    public bool Finished => !IsActive;
}