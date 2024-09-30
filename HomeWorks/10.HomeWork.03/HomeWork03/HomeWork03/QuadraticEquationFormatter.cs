using HomeWork03.Infrastructure;
using HomeWork03.Models;
using HomeWork03.Services;
using System.Text;

namespace HomeWork03;
public class QuadraticEquationFormatter
{
    public Coefficient A { get; set; }
    public Coefficient B { get; set; }
    public Coefficient C { get; set; }

    public QuadraticEquationFormatter(Coefficient a, Coefficient b, Coefficient c)
    {
        A = a;
        B = b;
        C = c;
    }

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
        if (A.UnsignedValue == "1")
            sb.Append(A.Sign == "-" ? "-" : "");
        else
            sb.Append(A.Value).Append(" * ");
        sb.Append("x^2");
    }

    private void AddSecondArgument(StringBuilder sb)
    {
        if (B.BigNumber.HasValue && B.BigNumber.Value == 0)
            return;
        AddArgumentsSign(sb, B);
        if (B.UnsignedValue != "1")
            sb.Append(B.UnsignedValue).Append(" * ");
        sb.Append("x");
    }

    private void AddThirdArgument(StringBuilder sb)
    {
        if (C.BigNumber.HasValue && C.BigNumber == 0)
            return;
        AddArgumentsSign(sb, C);
        sb.Append(C.UnsignedValue);
    }

    private void AddArgumentsSign(StringBuilder sb, Coefficient argument)
    {
        var sign = "+";
        if (argument.IsNumber)
            sign = argument.Sign;
        sb.Append(" ");
        sb.Append(sign).Append(" ");
    }
}
