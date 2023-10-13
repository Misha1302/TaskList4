namespace TaskList4;

public class Task : Entity
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public bool IsActive { get; set; } = true;
    public bool Finished => !IsActive;
}