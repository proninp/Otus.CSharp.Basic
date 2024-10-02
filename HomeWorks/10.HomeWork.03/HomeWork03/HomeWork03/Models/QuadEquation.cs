namespace HomeWork03.Models;
public class QuadEquation
{
    public Coefficient A { get; init; }

    public Coefficient B { get; init; }

    public Coefficient C { get; init; }

    public QuadEquation(Coefficient a, Coefficient b, Coefficient c)
    {
        A = a;
        B = b;
        C = c;
    }
}
