using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using PM3Other;

#region other methods
{

// using var stream = File.CreateText("test.txt");
// stream.WriteLine("test");

    using (var person = new Person())
    {
        // какие-то действия с объектом

        // В конце области видимости выполнится Dispose()
    }

    void DoSomething()
    {
        using var person2 = new Person();
        var str = person2.ToString();
    }

    var str = "Жил-был у бабушки серенький козлик";
    var enumerator = str.GetLimitedEnumerator(3, 12);
    while (enumerator.MoveNext())
    {
        var symbol = enumerator.Current;
        Console.WriteLine(symbol);
    }

    foreach (var i in 10)
        Console.WriteLine(i);
}
#endregion

Team[] teams =
{
    new() { Name = "Barcelona", Country = "Spain", City = "Barcelona" },
    new() { Name = "Bayern", Country = "Germany", City = "Bayern"},
    new() { Name = "Real", Country = "Spain", City = "Madrid" },
    new() { Name = "Atletico", Country = "Spain", City = "Madrid"},
    new() { Name = "Borussia", Country = "Germany", City = "Dortmund" },
    new() { Name = "Baltika", Country = "Russia", City = "Kaliningrad"},
};

Console.WriteLine("");
Console.WriteLine("======================================");
Console.WriteLine("Сортировка LINQ");
Console.WriteLine("======================================");
foreach(var team in teams)
    Console.WriteLine(team);
    
var selectedTeams = 
    from team in teams
    orderby team.Country, team.Name descending 
    select team;
    
Console.WriteLine("========================================================");
foreach(var team in selectedTeams)
    Console.WriteLine(team);
  
Console.WriteLine("");
Console.WriteLine("======================================");
Console.WriteLine("Сортировка методы расширения LINQ");
Console.WriteLine("======================================");
var selectedTeams2 = teams
        .OrderBy(x => x.Country)
        .ThenByDescending(x => x.Name)
        //.Select(x => x)                                                              
    ;

foreach(var team in selectedTeams2)
    Console.WriteLine(team);
   
Console.WriteLine("");
Console.WriteLine("======================================");
Console.WriteLine("Фильтрация LINQ");
Console.WriteLine("======================================");
var selectedTeams3 = 
    from team in teams
    where team.Country is "Germany"
    orderby team.Name
    select team;
foreach(var team in selectedTeams3)
    Console.WriteLine(team);


Console.WriteLine("");
Console.WriteLine("======================================");
Console.WriteLine("Проекция LINQ");
Console.WriteLine("======================================");
var selectedTeams4 =
    from team in teams
    where team.Country is "Spain"
    orderby team.Name
    select team.Name;
foreach(var name in selectedTeams4)
    Console.WriteLine(name);

Console.WriteLine("");
Console.WriteLine("======================================");
Console.WriteLine("Проекция методы расширения LINQ");
Console.WriteLine("======================================");
var selectedTeams5 = teams
    .Where(x => x.Country is "Spain")
    .OrderBy(X => X.Name)
    .Select(x => x.Name);
foreach(var name in selectedTeams5)
    Console.WriteLine(name);

Console.WriteLine("");
Console.WriteLine("======================================");
Console.WriteLine("Проекция LINQ с анонимным типом");
Console.WriteLine("======================================");
var selectedTeams6 = (
    from team in teams
    where team.Country is "Spain"
    orderby team.Name
    select new
    {
        TeamName = team.Name, 
        Place = $"{team.City}, {team.Country}",
    }).OrderBy(x => x.Place);
foreach(var item in selectedTeams6)
    Console.WriteLine($"{item.TeamName} from {item.Place}");

Console.WriteLine("");
Console.WriteLine("======================================");
Console.WriteLine("Проекция методы расширения LINQ с анонимным типом");
Console.WriteLine("======================================");
var selectedTeams7 = teams
    .Where(x => x.Country is "Spain")
    .OrderBy(X => X.Name)
    .Select(team => new
    {
        TeamName = team.Name, 
        Place = $"{team.City}, {team.Country}",
    });

foreach(var item in selectedTeams7)
    Console.WriteLine($"{item.TeamName} from {item.Place}");

Console.WriteLine("");
Console.WriteLine("======================================");
Console.WriteLine("Проекция LINQ с анонимным типом и введением вспомогательной переменной");
Console.WriteLine("======================================");
var selectedTeams8 = (
    from team in teams
    let place = $"{team.City}, {team.Country}"
    let fullName = team.ToString()
    where team.Country is "Spain"
    orderby team.Name
    select new
    {
        TeamName = team.Name, 
        Place = place,
        FullName = fullName,
    }).OrderBy(x => x.Place);
foreach(var item in selectedTeams8)
    Console.WriteLine($"team: {item.FullName}");

string[] names1 = { "Ян", "Дарья", "Анастасия", "Никита", "Сыч", "Никита" };
string[] names2 = { "Дарья", "Акакий", "Никита", "Венцеслав" };

var names3 = names1.Intersect(names2);
Console.WriteLine("");
Console.WriteLine("======================================");
Console.WriteLine("LINQ Intersect");
Console.WriteLine("======================================");
foreach(var name in names3)
    Console.WriteLine(name);

var names4 = names1.Except(names2);
Console.WriteLine("");
Console.WriteLine("======================================");
Console.WriteLine("LINQ Except");
Console.WriteLine("======================================");
foreach(var name in names4)
    Console.WriteLine(name);

var names5 = names1.Union(names2);
Console.WriteLine("");
Console.WriteLine("======================================");
Console.WriteLine("LINQ Union");
Console.WriteLine("======================================");
foreach(var name in names5)
    Console.WriteLine(name);


var names6 = names1.Distinct();
Console.WriteLine("");
Console.WriteLine("======================================");
Console.WriteLine("LINQ Distinct");
Console.WriteLine("======================================");
foreach(var name in names6)
    Console.WriteLine(name);

var names7 = (
        from name in names1
        where name.Length > 10
        orderby name
        select name)
    .Skip(20)
    .Take(20);

string? FindByName(string[] names, string name)
{
    return (
            from item in names
            where String.Equals(item, name, StringComparison.InvariantCultureIgnoreCase)
            select item
        )
        //.First(); // первый эелемент, исключение, если пусто
        //.FirstOrDefault(); // первый элемент или null, если пусто
        //.Single(); // возращает единственный элемент коллекции, иначе исключение
        .SingleOrDefault(); // возврщает единственный элемент коллекйии: null, если коллекция пуста; иначе исключение
}
