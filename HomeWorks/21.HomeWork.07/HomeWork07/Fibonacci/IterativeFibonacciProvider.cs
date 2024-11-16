namespace Fibonacci;
public class IterativeFibonacciProvider
{
    public long GetFibonacci(int n)
    {
        if (n < 2)
            return n;

        long[] fibSeq = { 0, 1 };
        for (var i = 2; i <= n; i++)
        {
            (fibSeq[0], fibSeq[1]) = (fibSeq[1], fibSeq[0] + fibSeq[1]);
        }
        return fibSeq[1];
    }
}