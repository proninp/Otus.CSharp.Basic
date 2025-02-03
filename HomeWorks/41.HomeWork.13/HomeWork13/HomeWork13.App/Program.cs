using HomeWork13;
using HomeWork13.App;

var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

var listPart = list.Top(30);
Console.WriteLine(string.Join(", ", listPart));

var persons = new List<Person>()
{
    new Person("Bjarne", 74),
    new Person("Linus", 55),
    new Person("James", 69),
    new Person("Bill", 69),
    new Person("Guido", 68),
    new Person("Brendan", 63)
};

var personsPart = persons.Top(50, p => p.Age);
Console.WriteLine(string.Join("\n", personsPart));