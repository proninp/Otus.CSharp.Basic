using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Task1;
public sealed class Shop : IEnumerable<Item>
{
    private int _lastId = 0;

    private readonly ObservableCollection<Item> _items = [];

    public void AddTracking(NotifyCollectionChangedEventHandler eventHandler)
    {
        _items.CollectionChanged += eventHandler;
    }

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

    public int GetNewItemId() =>
        ++_lastId;

    public IEnumerator<Item> GetEnumerator()
    {
        foreach (var item in _items)
            yield return item;
    }

    IEnumerator IEnumerable.GetEnumerator() =>
        GetEnumerator();
}