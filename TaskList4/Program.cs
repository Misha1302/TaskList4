using TaskList4;
using AppContext = TaskList4.AppContext;
using Task = TaskList4.Task;

var person = new Person
{
    Name = "Nick",
    Password = "qwerty",
    Tasks = new List<Task>()
};

var task = new Task
{
    Title = "Title",
    Description = "Dsc",
    IsActive = true
};

using var appContext = new AppContext();

appContext.Persons.Add(person);
appContext.Persons.Remove(person);
appContext.SaveChanges();

var persons = appContext.Persons;
var p = appContext.Persons.Find(person.Id) ?? throw new InvalidOperationException();

var tasks = p.Tasks;
p.Tasks.Add(task);
appContext.SaveChanges();

var t = appContext.Tasks.Find(p.Tasks[0].Id) ?? throw new InvalidOperationException();
appContext.Update(t);
appContext.Remove(t);
appContext.SaveChanges();