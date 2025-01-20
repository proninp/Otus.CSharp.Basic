using HomeWork11.App;

namespace HomeWork11.Tests;

public class OtusDictionaryTests
{
    [Fact]
    public void Add_ShouldAddNewEntry_WhenKeyDoesNotExist()
    {
        var dictionary = new OtusDictionary();

        dictionary.Add(1, "Value1");

        Assert.True(dictionary.Contains(1));
        Assert.Equal("Value1", dictionary[1]);
    }

    [Fact]
    public void Add_ShouldThrowException_WhenKeyAlreadyExists()
    {
        var dictionary = new OtusDictionary();
        dictionary.Add(1, "Value1");

        Assert.Throws<ArgumentException>(() => dictionary.Add(1, "AnotherValue"));
    }

    [Fact]
    public void Indexer_Set_ShouldUpdateValue_WhenKeyExists()
    {
        var dictionary = new OtusDictionary();
        dictionary.Add(1, "Value1");

        dictionary[1] = "UpdatedValue";

        Assert.Equal("UpdatedValue", dictionary[1]);
    }

    [Fact]
    public void Indexer_Set_ShouldAddValue_WhenKeyDoesNotExist()
    {
        var dictionary = new OtusDictionary();

        dictionary[1] = "Value1";

        Assert.True(dictionary.Contains(1));
        Assert.Equal("Value1", dictionary[1]);
    }

    [Fact]
    public void Get_ShouldReturnValue_WhenKeyExists()
    {
        var dictionary = new OtusDictionary();
        dictionary.Add(1, "Value1");

        var value = dictionary.Get(1);

        Assert.Equal("Value1", value);
    }

    [Fact]
    public void Get_ShouldThrowKeyNotFoundException_WhenKeyDoesNotExist()
    {
        var dictionary = new OtusDictionary();

        Assert.Throws<KeyNotFoundException>(() => dictionary.Get(1));
    }

    [Fact]
    public void Resize_ShouldHandleCollisionsCorrectly()
    {
        var dictionary = new OtusDictionary(2);

        dictionary.Add(0, "Value1");
        dictionary.Add(32, "Value3"); // Collision

        Assert.Equal("Value1", dictionary[0]);
        Assert.Equal("Value3", dictionary[32]);
    }
}