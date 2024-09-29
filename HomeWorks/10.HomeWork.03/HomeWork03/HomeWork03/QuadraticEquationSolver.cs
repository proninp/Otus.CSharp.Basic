namespace HomeWork03;
public class QuadraticEquationSolver
{
    private readonly double _a;
    private readonly double _b;
    private readonly double _c;

    public QuadraticEquationSolver(double a, double b, double c)
    {
        _a = a;
        _b = b;
        _c = c;
    }

    public (double? x1, double? x2) Solve()
    {
        if (_a == 0)
        {
            throw new ArgumentException("Параметр 'a' не может быть равен нулю в квадратном уравнении");
        }

        var discriminant = _b * _b - 4 * _a * _c;
        double? x1 = null;
        double? x2 = null;
        if (discriminant > 0)
        {
            x1 = (-_b + Math.Sqrt(discriminant)) / 2.0 / _a;
            x2 = (-_b - Math.Sqrt(discriminant)) / 2.0 / _a;
        }
        else if (discriminant == 0)
        {
            x1 = -_b / 2.0 / _a;
        }
        return (x1, x2);
    }
}
