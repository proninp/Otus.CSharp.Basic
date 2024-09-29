using Xunit;

namespace HomeWork03.Test;
public class QuadraticEquationFormatterTests
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
        var formatter = new QuadraticEquationFormatter()
        {
            A = a,
            B = b,
            C = c
        };

        // Act
        var actual = formatter.Format();


        // Assert
        Assert.Equal(expected, actual);
    }
}
