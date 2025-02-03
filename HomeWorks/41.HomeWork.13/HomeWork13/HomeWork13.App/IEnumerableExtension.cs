namespace HomeWork13;
public static class IEnumerableExtension
{

    public static IEnumerable<T> Top<T>(this IEnumerable<T> source, int x)
        where T : IComparable<T>
    {
        return source.Top(x, e => e);
    }

    public static IEnumerable<T> Top<T, K>(this IEnumerable<T> source, int x, Func<T, K> selector)
    {
        if (x is < 1 or > 100)
            throw new ArgumentException($"{nameof(x)} must be greater than zero and less the or equal to 100");
        
        var elemsCount = (int)Math.Ceiling((double)source.Count() / 100 * x);
        
        return source.OrderByDescending(selector).Take(elemsCount);
    }
}