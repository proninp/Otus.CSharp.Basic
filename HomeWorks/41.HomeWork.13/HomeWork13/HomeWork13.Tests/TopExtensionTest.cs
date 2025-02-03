using HomeWork13.App;

namespace HomeWork13.Tests;

public class TopExtensionTest
{
    [Fact]
    public void Top_ShouldReturnTop30PercentOfIntegers()
    {
        var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        var expected = new List<int> { 9, 8, 7 };

        var result = list.Top(30).ToList();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Top_ShouldReturnTop50PercentOfPersonsByAge()
    {
        var persons = new List<Person>()
        {
            new Person("Bjarne", 74),
            new Person("James", 69),
            new Person("Linus", 55),
            new Person("Bill", 68),
            new Person("Guido", 68),
            new Person("Brendan", 63)
        };
        var expected = new List<Person> { persons[0], persons[1], persons[3]};

        var result = persons.Top(50, p => p.Age).ToList();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Top_ShouldThrowException_WhenPercentageIsOutOfRange()
    {
        var list = new List<int> { 1, 2, 3, 4, 5 };

        Assert.Throws<ArgumentException>(() => list.Top(0));
        Assert.Throws<ArgumentException>(() => list.Top(101));
    }
}