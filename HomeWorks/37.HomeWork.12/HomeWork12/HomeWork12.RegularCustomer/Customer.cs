using System.Collections.Specialized;
using Spectre.Console;

namespace Task1;
public sealed class Customer
{
    public string Name { get; init; }

    public Customer(string name)
    {
        Name = name;
    }

    public void Subscribe(Shop shop)
    {
        shop.AddTracking(OnItemChanged);
    }

    void OnItemChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        switch (e.Action)
        {
            case NotifyCollectionChangedAction.Add:
                if (e.NewItems?[0] is Item newItem)
                    AnsiConsole.MarkupLine($"[cyan]{Name}[/]: Добавлен новый товар: {newItem.Name}");
                break;

            case NotifyCollectionChangedAction.Remove:
                if (e.OldItems?[0] is Item oldItem)
                    AnsiConsole.MarkupLine($"[cyan]{Name}[/]: Удален товар: {oldItem.Name}");
                break;
        }
    }
}