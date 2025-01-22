using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Task1.Interfaces;

namespace Task1;
public sealed class Shop : IOtusObservable, IEnumerable<Item>
{
    private int _lastId = 0;
    private readonly ObservableCollection<Item> _items = [];
    private readonly List<IOtusObserver> _observers = [];

    public Item this[int i]
    {
        get => _items[i];
        set => _items[i] = value;
    }

    public Shop()
    {
        _items.CollectionChanged += Items_CollectionChanged;
    }

    public void Notify(string message) =>
        _observers.ForEach(o => o.Update(message));

    public void AddItem() =>
        _items.Add(new Item(GetNewItemId()));

    public bool Remove(int id)
    {
        var item = _items.FirstOrDefault(i => i.Id == id);
        if (item is null)
            return false;
        _items.Remove(item);
        return true;
    }

    public void AddObserver(IOtusObserver observer) =>
        _observers.Add(observer);

    public void RemoveObserver(IOtusObserver observer) =>
        _observers.Remove(observer);

    public int GetNewItemId() =>
        ++_lastId;
    
    private void Items_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        switch (e.Action)
        {
            case NotifyCollectionChangedAction.Add:
                if (e.NewItems?[0] is Item newItem)
                    Notify($"Добавлен новый товар: {newItem.Name}");
                break;

            case NotifyCollectionChangedAction.Remove:
                if (e.OldItems?[0] is Item oldItem)
                    Notify($"Удален товар: {oldItem.Name}");
                break;

            case NotifyCollectionChangedAction.Replace:
                if ((e.NewItems?[0] is Item replacingItem) && (e.OldItems?[0] is Item replacedItem))
                    Notify($"Товар {replacedItem.Name} заменен товаром {replacingItem.Name}");
                break;
        }
    }

    public IEnumerator<Item> GetEnumerator()
    {
        foreach (var item in _items)
            yield return item;
    }

    IEnumerator IEnumerable.GetEnumerator() =>
        GetEnumerator();
}