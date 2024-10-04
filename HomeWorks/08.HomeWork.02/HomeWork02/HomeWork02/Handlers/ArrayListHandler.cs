using System.Collections;

namespace HomeWork02.Handlers;
public class ArrayListHandler
{
    private int _elementsCount;
    private Random _random;
    private ArrayList _unDefinedCapacityList;
    private ArrayList _preDefinedCapacityList;

    public ArrayListHandler(int size)
    {
        _elementsCount = size;
        _random = new Random();
        _unDefinedCapacityList = new ArrayList();
        _preDefinedCapacityList = new ArrayList(_elementsCount);
    }

    public void AddUnDefinedCapacityArrayList()
    {
        for (int i = 0; i < _elementsCount; i++)
        {
            _unDefinedCapacityList.Add(_random.Next(0, _elementsCount));
        }
    }

    public void AddPreDefinedCapacityArrayList()
    {
        for (int i = 0; i < _elementsCount; i++)
        {
            _preDefinedCapacityList.Add(_random.Next(0, _elementsCount));
        }
    }

    public int GetElement(int index) =>
        ElementAt(index);

    public void PrintCleanDivisionElements(int divider)
    {
        foreach (var element in _unDefinedCapacityList)
            if ((int)element % divider == 0)
                Console.Write($"[{element}] ");
        Console.WriteLine();
    }

    private int ElementAt(int index)
    {
        var defaultValue = -1;
        if (index < 0 || index >= _unDefinedCapacityList.Count)
            return defaultValue;
        return (int)(_unDefinedCapacityList[index] ?? defaultValue);
        
    }
        
}
