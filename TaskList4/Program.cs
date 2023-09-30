using Microsoft.EntityFrameworkCore;

var person = new Person
{
    Name = "Nick",
    Password = "qwerty",
    Tasks = new List<Task>
    {
        new()
        {
            Title = "Title",
            Description = "Dsc",
            Archived = false,
            Finished = false
        }
    }
};

using var appContext = new AppContext();
appContext.Persons.Add(person);
appContext.SaveChanges();

Console.WriteLine("Hello, World!");


public class AppContext : DbContext
{
    public DbSet<Person> Persons { get; set; } = null!;
    public DbSet<Task> Tasks { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=testDb;username=postgres;Password=Qwary123");
        base.OnConfiguring(optionsBuilder);
    }
}


public class Person : Entity
{
    public required string Name { get; set; }
    public required string Password { get; set; }
    public required List<Task> Tasks { get; set; }
}

public class Task : Entity
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required bool Archived { get; set; }
    public required bool Finished { get; set; }
}

public abstract class Entity
{
    public int Id { get; set; }
}