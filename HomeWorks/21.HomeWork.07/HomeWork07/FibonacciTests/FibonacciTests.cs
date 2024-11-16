using Fibonacci;

namespace FibonacciTests;

public class FibonacciTests
{
    public static IEnumerable<object[]> FibonacciTestData => new List<object[]>
    {
        new object[] { 0, 0L },
        new object[] { 1, 1L },
        new object[] { 2, 1L },
        new object[] { 3, 2L },
        new object[] { 4, 3L },
        new object[] { 5, 5L },
        new object[] { 6, 8L },
        new object[] { 7, 13L },
        new object[] { 8, 21L },
        new object[] { 9, 34L },
        new object[] { 10, 55L },
        new object[] { 15, 610L },
        new object[] { 19, 4181L },
        new object[] { 20, 6765L },
    };

    private readonly IterativeFibonacciProvider _iterativeProvider;
    private readonly RecoursiveFibonacciProvider _recoursiveProvider;

    public FibonacciTests()
    {
        _iterativeProvider = new();
        _recoursiveProvider = new();
    }

    [Theory]
    [MemberData(nameof(FibonacciTestData))]
    public void GetFibonacci_Recoursive_ShouldReturnCorrectValue(int n, long expectedResult)
    {
        // Arrange & Act
        var actualResult = _recoursiveProvider.GetFibonacci(n);

        // Arrange Act & Assert
        Assert.Equal(expectedResult, actualResult);
    }

    [Theory]
    [MemberData(nameof(FibonacciTestData))]
    public void GetFibonacci_RecoursiveCached_ShouldReturnCorrectValue(int n, long expectedResult)
    {
        // Arrange & Act
        var actualResult = _recoursiveProvider.GetFibonacciCached(n);

        // Arrange Act & Assert
        Assert.Equal(expectedResult, actualResult);
    }

    [Theory]
    [MemberData(nameof(FibonacciTestData))]
    public void GetFibonacci_Iterative_ShouldReturnCorrectValue(int n, long expectedResult)
    {
        // Arrange & Act
        var actualResult = _iterativeProvider.GetFibonacci(n);

        // Arrange Act & Assert
        Assert.Equal(expectedResult, actualResult);
    }
}