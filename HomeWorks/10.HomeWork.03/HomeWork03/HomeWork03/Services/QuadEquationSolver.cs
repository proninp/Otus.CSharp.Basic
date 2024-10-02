using HomeWork03.Infrastructure;

namespace HomeWork03.Services;
public sealed class QuadEquationSolver
{
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }

    public QuadEquationSolver(double a, double b, double c)
    {
        A = a;
        B = b;
        C = c;
    }

    public (double? x1, double? x2) Solve()
    {
        if (A == 0)
            throw new ArgumentException(Messages.Exceptions.IncorrectFirstArgument);

        var discriminant = B * B - 4 * A * C;
        double? x1 = null;
        double? x2 = null;
        if (discriminant > 0)
        {
            x1 = (-B + Math.Sqrt(discriminant)) / 2.0 / A;
            x2 = (-B - Math.Sqrt(discriminant)) / 2.0 / A;
        }
        else if (discriminant == 0)
        {
            x1 = -B / 2.0 / A;
        }
        return (x1, x2);
    }
}