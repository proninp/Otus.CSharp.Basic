using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace HomeWork11.App;
public class OtusDictionary : IOtusDictionary, IEnumerable<HashEntry>
{
    private HashEntry[] _table;

    public OtusDictionary() : this(32) { }

    public OtusDictionary(int capacity)
    {
        if (capacity <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(capacity));
        }
        _table = new HashEntry[capacity];
    }

    public string this[int i]
    {
        get => Get(i);
        set => AddOrUpdate(i, value, true);
    }

    public void Add(int key, string? value) =>
        AddOrUpdate(key, value, false);

    public string Get(int key)
    {
        TryGetHashEntry(key, out var hashEntry);
        if (hashEntry is null || hashEntry.Value is null)
            throw new KeyNotFoundException($"The given key '{key}' was not present in the dictionary");

        return hashEntry.Value;
    }

    public bool TryGetValue(int key, [NotNullWhen(true)] out string? value)
    {
        value = null;
        if (TryGetHashEntry(key, out var hashEntry))
            value = hashEntry.Value;
        return value is not null;
    }

    public bool Contains(int key) =>
        TryGetHashEntry(key, out var entry);

    private void AddOrUpdate(int key, string? value, bool isUpdate)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));

        if (!IsEmptySlot())
            Resize();

        var index = GetSlot(key, _table);

        if (!isUpdate && _table[index] is not null)
            throw new ArgumentException($"An item with the same key has already been added. Key: '{key}'");

        _table[index] = new HashEntry(key, value);
    }

    private bool TryGetHashEntry(int key, [NotNullWhen(true)] out HashEntry? entry)
    {
        entry = null;
        var index = GetSlot(key, _table);
        if (_table[index] is not null && _table[index].Key == key)
            entry = _table[index];

        return entry is not null;
    }

    private bool IsEmptySlot() =>
        _table.Any(e => e is null);

    private int GetSlot(int key, HashEntry[] table)
    {
        var index = Math.Abs(key % table.Length);
        while (table[index] is not null && table[index].Key != key)
            index = (index + 1) % table.Length;
        return index;
    }

    private void Resize()
    {
        var newTable = new HashEntry[_table.Length << 1];
        foreach (var kvp in _table)
        {
            var newSlot = GetSlot(kvp.Key, newTable);
            newTable[newSlot] = kvp;
        }
        _table = newTable;
    }

    public IEnumerator<HashEntry> GetEnumerator()
    {
        foreach (var e in _table)
            if (e is not null)
                yield return e;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}