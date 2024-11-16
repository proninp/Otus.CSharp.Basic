namespace Fibonacci;

public class RecoursiveFibonacciProvider
{
    private readonly Dictionary<int, long> cache = new();

    public long GetFibonacci(int n)
    {
        if (n < 2)
            return n;
        return GetFibonacci(n - 1) + GetFibonacci(n - 2);
    }

    public long GetFibonacciCached(int n)
    {
        if (cache.ContainsKey(n))
            return cache[n];
        var fib = n < 2 ? n :
            GetFibonacciCached(n - 1) + GetFibonacciCached(n - 2);

        cache.Add(n, fib);
        return fib;
    }
}