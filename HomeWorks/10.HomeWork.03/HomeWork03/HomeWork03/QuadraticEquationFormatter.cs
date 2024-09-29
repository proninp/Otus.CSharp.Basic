using System.Text;

namespace HomeWork03;
public class QuadraticEquationFormatter
{
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }

    public string Format()
    {
        var equation = new StringBuilder();

        AddFirstArgument(equation);
        AddSecondArgument(equation);
        AddThirdArgument(equation);
        equation.Append(" = 0");

        return equation.ToString();
    }

    private void AddFirstArgument(StringBuilder sb)
    {
        if (A == 0)
            throw new ArgumentException("Параметр 'a' не может быть равен нулю в квадратном уравнении");
        
        if (Math.Abs(A) == 1)
            sb.Append(A == -1 ? "-" : "");
        else
            sb.Append(A).Append(" * ");
        sb.Append("x^2");
    }

    private void AddSecondArgument(StringBuilder sb)
    {
        if (B == 0)
            return;
        AddArgumentsSign(sb, B);
        if (B != 1 && B != -1)
            sb.Append(Math.Abs(B)).Append(" * ");
        sb.Append("x");
    }

    private void AddThirdArgument(StringBuilder sb)
    {
        if (C == 0)
            return;
        AddArgumentsSign(sb, C);
        sb.Append(Math.Abs(C));
    }

    private void AddArgumentsSign(StringBuilder sb, double argument)
    {
        var sign = (argument < 0) ? '-' : '+';
        sb.Append(" ");
        sb.Append(sign.ToString()).Append(" ");
    }
}
