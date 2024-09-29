namespace HomeWork03.Abstractions;
interface IQuadraticEquationFactory
{
    QuadraticEquationSolver GetSolver(double a, double b, double c);
}
