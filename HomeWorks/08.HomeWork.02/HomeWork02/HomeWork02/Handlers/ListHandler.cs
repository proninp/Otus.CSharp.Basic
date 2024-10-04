using System.IO.IsolatedStorage;

namespace HomeWork02.Handlers;
public class ListHandler
{
    private int _elementsCount;
    private Random _random;
    private List<int> _unDefinedCapacityList;
    private List<int> _preDefinedCapacityList;

    public ListHandler(int size)
    {
        _elementsCount = size;
        _random = new Random();
        _unDefinedCapacityList = new List<int>();
        _preDefinedCapacityList = new List<int>(_elementsCount);
    }

    public void AddUnDefinedCapacityList()
    {
        for (int i = 0; i < _elementsCount; i++)
        {
            _unDefinedCapacityList.Add(_random.Next(0, _elementsCount));
        }
    }

    public void AddPreDefinedCapacityList()
    {
        for (int i = 0; i < _elementsCount; i++)
        {
            _preDefinedCapacityList.Add(_random.Next(0, _elementsCount));
        }
    }

    public int GetElement(int index)
    {
        if (index < 0 || index >= _unDefinedCapacityList.Count)
            return -1;
        return _unDefinedCapacityList.ElementAt(index);
    }
        

    public void PrintCleanDivisionElements(int divider)
    {
        foreach (var element in _unDefinedCapacityList)
            if (element % divider == 0)
                Console.Write($"[{element}] ");
        Console.WriteLine();
    }
}
