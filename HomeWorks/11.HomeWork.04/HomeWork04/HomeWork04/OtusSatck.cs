namespace HomeWork04;
public class OtusSatck<T> : IStackable<T>
{
    private StackItem<T>? _stackItem;

    public OtusSatck(params T[] items)
    {
        Array.ForEach(items, Add);
    }

    public int Size { get; private set; }

    public T? Top { get => _stackItem is null ? default : _stackItem.Item; }

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
        _stackItem = new StackItem<T>(_stackItem, item);
        ++Size;
    }

    public T Pop()
    {
        if (Size == 0)
            throw new InvalidOperationException("Стек пустой");
        var item = _stackItem!.Item;
        _stackItem = _stackItem.Previous;
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
