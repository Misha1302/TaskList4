using TaskList4;
using AppContext = TaskList4.AppContext;
using Task = TaskList4.Task;

var person = new Person
{
    Name = "Nick",
    Password = "qwerty"
};

var person2 = new Person
{
    Name = "Nick2",
    Password = "qwerty"
};

var task = new Task
{
    Title = "Title",
    Description = "Dsc"
};

using var appContext = new AppContext();

appContext.Persons.Add(person);
appContext.Persons.Add(person2);
appContext.Persons.Remove(person);
appContext.SaveChanges();

var p = appContext.Persons.FirstOrDefault(x => x.Id == person2.Id);
if (p == null)
    Console.WriteLine($"Person with id {person2.Id} wasn't found");

p!.Tasks.Add(task);
p.Tasks.Add(task);
p.Tasks.Remove(task);
appContext.Update(p);
appContext.SaveChanges();


var curTask = p.Tasks.First();
var t = appContext.Tasks.FirstOrDefault(x => x.Id == curTask.Id)!;
// ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
if (t is null)
    Console.WriteLine($"Task with id {person2.Id} wasn't found");