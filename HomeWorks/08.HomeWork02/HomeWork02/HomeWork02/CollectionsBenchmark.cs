using BenchmarkDotNet.Attributes;
using HomeWork02.Handlers;

namespace HomeWork02;

[HideColumns("Error", "StdDev", "Median", "Gen0", "Gen1")]
[MemoryDiagnoser]
public class CollectionsBenchmark
{
    private const int ElementsCount = 1_000_000;
    private const int SeekElementIndex = 496_753;
    private const int Divider = 777;
    private ListHandler _listHandler;
    private LinkedListHandler _linkedListHandler;
    private ArrayListHandler _arrayListHandler;

    #region Adding elements

    [GlobalSetup]
    public void Setup()
    {
        _listHandler = new ListHandler(ElementsCount);
        _linkedListHandler = new LinkedListHandler(ElementsCount);
        _arrayListHandler = new ArrayListHandler(ElementsCount);
    }

    [Benchmark]
    public void AddUndefinedCapacityList() =>
        _listHandler.AddUnDefinedCapacityList();

    [Benchmark]
    public void AddPreDefinedCapacityList() =>
        _listHandler.AddPreDefinedCapacityList();

    [Benchmark]
    public void AddLinkedListLast() =>
        _linkedListHandler.AddLinkedListLast();

    [Benchmark]
    public void AddLinkedListFirst() =>
        _linkedListHandler.AddLinkedListFirst();

    [Benchmark]
    public void AddUndefinedCapacityArrayList() =>
        _arrayListHandler.AddUnDefinedCapacityArrayList();

    [Benchmark]
    public void AddPreDefinedCapacityArrayList() =>
        _arrayListHandler.AddPreDefinedCapacityArrayList();

    #endregion

    #region Getting elements

    [Benchmark]
    public void GetListElement() =>
        _listHandler.GetElement(SeekElementIndex);

    [Benchmark]
    public void GetLinkedListElement() =>
        _linkedListHandler.GetElement(SeekElementIndex);

    [Benchmark]
    public void GetArrayListElement() =>
        _arrayListHandler.GetElement(SeekElementIndex);

    #endregion

    #region Printing elements

    [Benchmark]
    public void PrintCleanDivisionListElements() =>
        _listHandler.PrintCleanDivisionElements(Divider);

    [Benchmark]
    public void PrintCleanDivisionLinkedListElements() =>
        _linkedListHandler.PrintCleanDivisionElements(Divider);

    [Benchmark]
    public void PrintCleanDivisionArrayListElements() =>
        _arrayListHandler.PrintCleanDivisionElements(Divider);

    #endregion
}
