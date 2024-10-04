namespace HomeWork02.Handlers;
public class LinkedListHandler
{
    private int _elementsCount;
    private Random _random;
    private LinkedList<int> _linkedList;

    public LinkedListHandler(int size)
    {
        _elementsCount = size;
        _random = new Random();
        _linkedList = new LinkedList<int>();
    }

    public void AddLinkedListLast()
    {
        for (int i = 0; i < _elementsCount; i++)
        {
            _linkedList.AddLast(_random.Next(0, _elementsCount));
        }
    }

    public void AddLinkedListFirst()
    {
        for (int i = 0; i < _elementsCount; i++)
        {
            _linkedList.AddFirst(_random.Next(0, _elementsCount));
        }
    }

    public int GetElement(int index)
    {
        if (index < 0 || index >= _linkedList.Count)
            return -1;
        return _linkedList.ElementAt(index);
    }
        

    public void PrintCleanDivisionElements(int divider)
    {
        foreach (var element in _linkedList)
            if (element % divider == 0)
                Console.Write($"[{element}] ");
        Console.WriteLine();
    }
}
