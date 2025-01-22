namespace Task1;
public sealed class Item
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public Item(int id) : this(id, $"Товар от {DateTime.Now}") { }

    public Item(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
