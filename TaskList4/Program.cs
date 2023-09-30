using Microsoft.EntityFrameworkCore;

var person = new Person
{
    Id = 123,
    Name = "Nick",
    Password = "qwerty",
    Tasks = new List<Task>(),
};
var task = new Task
{
    Title = "Title",
    Description = "Dsc",
    Archived = false,
    Finished = false
};

new AppContext().AddPerson(person);
new AppContext().AddTask(task, person);

Console.WriteLine("Hello, World!");


public class AppContext : DbContext
{
    private DbSet<Person> Persons { get; set; } = null!;
    private DbSet<Task> Tasks { get; set; } = null!;

    public void AddPerson(Person p)
    {
        Persons.Add(p);
        SaveChanges();
    }

    public void RemovePerson(Person p)
    {
        Persons.Remove(p);
        SaveChanges();
    }

    public void UpdatePerson(Person p)
    {
        Persons.Update(p);
        SaveChanges();
    }

    public void AddTask(Task t, Person p)
    {
        Tasks.Add(t);
        p.Tasks.Add(t);
        UpdatePerson(p);
    }

    public void RemoveTask(Task t, Person p)
    {
        Tasks.Remove(t);
        p.Tasks.Remove(t);
        UpdatePerson(p);
    }

    public void UpdateTask(Task t, Person p)
    {
        Tasks.Update(t);
        SaveChanges();
    }

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