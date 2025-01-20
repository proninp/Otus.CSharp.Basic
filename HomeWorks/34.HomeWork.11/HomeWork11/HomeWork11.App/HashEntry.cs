namespace HomeWork11.App;
public class HashEntry
{
    public int Key { get; private set; }

    public string? Value { get; set; }

    public HashEntry(int key, string? value)
    {
        Key = key;
        Value = value;
    }
}
