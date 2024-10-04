namespace HomeWork03.Abstractions;
public interface IEquationSolver
{
    public (double? x1, double? x2) Solve(int a, int b, int c);
}
