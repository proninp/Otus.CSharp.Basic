using HomeWork03.Models;
using System.Text;

namespace HomeWork03.Services;
public sealed class QuadEquationFormatter
{

    public string Format(QuadEquation equation)
    {

        var equationSb = new StringBuilder();
        AddFirstArgument(equationSb, equation);
        AddSecondArgument(equationSb, equation);
        AddThirdArgument(equationSb, equation);
        equationSb.Append(" = 0");

        return equationSb.ToString();
    }

    private void AddFirstArgument(StringBuilder sb, QuadEquation equation)
    {
        if (equation.A.UnsignedValue == "1")
            sb.Append(equation.A.Sign == "-" ? "-" : "");
        else
            sb.Append(equation.A.Value).Append(" * ");
        sb.Append("x^2");
    }

    private void AddSecondArgument(StringBuilder sb, QuadEquation equation)
    {
        if (equation.B.BigNumber.HasValue && equation.B.BigNumber.Value == 0)
            return;
        AddArgumentsSign(sb, equation.B);
        if (equation.B.UnsignedValue != "1")
            sb.Append(equation.B.UnsignedValue).Append(" * ");
        sb.Append("x");
    }

    private void AddThirdArgument(StringBuilder sb, QuadEquation equation)
    {
        if (equation.C.BigNumber.HasValue && equation.C.BigNumber == 0)
            return;
        AddArgumentsSign(sb, equation.C);
        sb.Append(equation.C.UnsignedValue);
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
