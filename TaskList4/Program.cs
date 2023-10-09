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

using var crud = new CrudAppContext(new AppContext());
crud.Add(person);

Console.WriteLine("Hello, World!");


public class CrudAppContext : IDisposable
{
    private readonly AppContext _appContext;

    public CrudAppContext(AppContext appContext)
    {
        _appContext = appContext;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        _appContext.Dispose();
    }

    public Person? Get(Person p) => _appContext.Persons.Find(p);

    public void Add(Person p)
    {
        _appContext.Persons.Add(p);
        _appContext.SaveChanges();
    }

    public void Update(Person p)
    {
        _appContext.Persons.Update(p);
        _appContext.SaveChanges();
    }

    public void Remove(Person p)
    {
        _appContext.Persons.Remove(p);
        _appContext.SaveChanges();
    }

    ~CrudAppContext()
    {
        _appContext.Dispose();
    }
}

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