using HomeWork03.Models;
using HomeWork03.Services;
using Xunit;

namespace HomeWork03.Test;
public class QuadEquationFormatterTests
{
    [Theory]
    [InlineData(5, -2, 3, "5 * x^2 - 2 * x + 3 = 0")]
    [InlineData(1, 0, -4, "x^2 - 4 = 0")]
    [InlineData(1, 0, 0, "x^2 = 0")]
    [InlineData(1, -1, 0, "x^2 - x = 0")]
    [InlineData(-1, 2, -3, "-x^2 + 2 * x - 3 = 0")]
    [InlineData(3, 0, 2, "3 * x^2 + 2 = 0")]
    [InlineData(2, 0, -5, "2 * x^2 - 5 = 0")]
    [InlineData(4, 7, 0, "4 * x^2 + 7 * x = 0")]
    [InlineData(1, 1, 1, "x^2 + x + 1 = 0")]
    [InlineData(-2, -3, 4, "-2 * x^2 - 3 * x + 4 = 0")]
    [InlineData(2, 1, 0, "2 * x^2 + x = 0")]
    public void FormatQuadraticEquation_ReturnsCorrectString(int a, int b, int c, string expected)
    {
        // Arrange
        var coefficientProvider = new CoefficientProvider();
        var aCoefficient = coefficientProvider.GetCofficient(a.ToString());
        var bCoefficient = coefficientProvider.GetCofficient(b.ToString());
        var cCoefficient = coefficientProvider.GetCofficient(c.ToString());
        var equation = new QuadEquation(aCoefficient, bCoefficient, cCoefficient);
        var formatter = new QuadEquationFormatter();

        // Act
        var actual = formatter.Format(equation);


        // Assert
        Assert.Equal(expected, actual);
    }
}
