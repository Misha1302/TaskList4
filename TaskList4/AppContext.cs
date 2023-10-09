using Microsoft.EntityFrameworkCore;

namespace TaskList4;

public class AppContext : DbContext
{
    public DbSet<Person> Persons { get; set; } = null!;
    public DbSet<Task> Tasks { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=testDb;username=postgres;Password=Qwary123;Include Error Detail=True");
        base.OnConfiguring(optionsBuilder);
    }
}