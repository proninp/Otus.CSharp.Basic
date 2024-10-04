using HomeWork03.Exceptions;
using HomeWork03.Services;
using Xunit;

namespace HomeWork03.Test;
public class QuadEquationSolverTests
{
    [Theory]
    [InlineData(1, -3, 2, 2, 1)]
    [InlineData(1, -5, 6, 3, 2)]
    [InlineData(2, -5, 3, 1.5, 1)]
    [InlineData(1, 0, -4, 2, -2)]
    public void SolveQuadraticEquation_TwoRealRoots(int a, int b, int c, double expectedRoot1, double expectedRoot2)
    {
        // Arrange
        var solver = GetSolver();
        
        // Act
        var actual = solver.Solve(a, b, c);

        // Assert
        Assert.True(actual.x1.HasValue, "Нет корня x1.");
        Assert.Equal(expectedRoot1, actual.x1.Value, precision: 5);
        
        Assert.True(actual.x2.HasValue, "Нет корня x2.");
        Assert.Equal(expectedRoot2, actual.x2.Value, precision: 5);
    }

    [Theory]
    [InlineData(1, -2, 1, 1)]
    [InlineData(4, 4, 1, -0.5)]
    [InlineData(9, -12, 4, 2.0 / 3)]
    [InlineData(1, 6, 9, -3)]
    public void SolveQuadraticEquation_OneRealRoot(int a, int b, int c, double expectedRoot)
    {
        // Arrange
        var solver = GetSolver();

        // Act
        var actual = solver.Solve(a, b, c);

        // Assert
        Assert.True(actual.x1.HasValue, "Нет корня x1.");
        Assert.Equal(expectedRoot, actual.x1.Value, precision: 5);

        Assert.False(actual.x2.HasValue, "Есть корень для x2.");
    }

    [Theory]
    [InlineData(1, 2, 5)]
    [InlineData(3, 4, 2)]
    [InlineData(1, 1, 1)]
    [InlineData(5, 6, 9)]
    public void SolveQuadraticEquation_ComplexRoots(int a, int b, int c)
    {
        // Arrange
        var solver = GetSolver();

        // Assert
        Assert.Throws<NoRealValuesException>(() => solver.Solve(a, b, c));
    }

    [Fact]
    public void Solve_WithZeroCoefficientA_ThrowsArgumentException()
    {
        // Arrange
        int a = 0, b = 2, c = 1;
        var solver = GetSolver();

        // Act, Assert
        Assert.Throws<ArgumentException>(() => solver.Solve(a, b, c));
    }

    private QuadEquationSolver GetSolver()
    {
        var consoleHelper = new ConsoleHelper();
        var exHandler = new ExceptionHandler(consoleHelper);
        return new QuadEquationSolver(exHandler);
    }
}
