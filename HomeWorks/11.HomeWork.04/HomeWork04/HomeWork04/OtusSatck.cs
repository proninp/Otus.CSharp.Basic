namespace HomeWork04;
public class OtusSatck<T> : IStackable<T>
{
    private StackItem<T>? _item;

    public OtusSatck(params T[] items)
    {
        Array.ForEach(items, Add);
    }

    public int Size { get; private set; }

    public T? Top { get => _item is null ? default : _item.Item; }

    public static OtusSatck<T> Concat(params OtusSatck<T>[] stacks)
    {
        var resultStack = new OtusSatck<T>();
        foreach (var st in stacks)
        {
            while (st.Size > 0)
                resultStack.Add(st.Pop());
        }
        return resultStack;
    }

    public void Add(T item)
    {
        _item = new StackItem<T>(_item, item);
        ++Size;
    }

    public T Pop()
    {
        if (Size == 0)
            throw new InvalidOperationException("Стек пустой");
        var item = _item!.Item;
        _item = _item.Previous;
        --Size;
        return item;
    }

    private class StackItem<T>
    {
        internal T Item { get; }

        internal StackItem<T>? Previous { get; }

        internal StackItem(StackItem<T>? previous, T item)
        {
            Item = item;
            Previous = previous;
        }
    }
}
