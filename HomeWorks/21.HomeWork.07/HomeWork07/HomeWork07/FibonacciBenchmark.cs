using BenchmarkDotNet.Attributes;
using Fibonacci;

namespace HomeWork07;

[HideColumns("Error", "StdDev", "Median", "Gen0", "Gen1")]
[MemoryDiagnoser]
public class FibonacciBenchmark
{
    private IterativeFibonacciProvider _iterativeProvider;
    private RecoursiveFibonacciProvider _recoursiveProvider;

    [GlobalSetup]
    public void Setup()
    {
        _iterativeProvider = new IterativeFibonacciProvider();
        _recoursiveProvider = new RecoursiveFibonacciProvider();
    }

    [Params(5, 10, 20)]
    public int N { get; set; }

    [Benchmark]
    public void IterativeBenchmark() =>
        _iterativeProvider.GetFibonacci(N);

    [Benchmark]
    public void RecoursiveBenchmark() =>
        _recoursiveProvider.GetFibonacci(N);

    [Benchmark]
    public void RecoursiveCachedBenchmark() =>
        _recoursiveProvider.GetFibonacciCached(N);
}
