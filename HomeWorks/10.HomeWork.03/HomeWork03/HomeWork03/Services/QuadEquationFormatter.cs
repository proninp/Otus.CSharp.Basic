using HomeWork03.Abstractions;
using HomeWork03.Models;
using System.Text;

namespace HomeWork03.Services;
public sealed class QuadEquationFormatter : IEquationFormatter
{
    public string Format(Coefficient[] equation)
    {
        var equationSb = new StringBuilder();
        AddFirstArgument(equationSb, equation[0]);
        AddSecondArgument(equationSb, equation[1]);
        AddThirdArgument(equationSb, equation[2]);
        equationSb.Append(" = 0");

        return equationSb.ToString();
    }

    private void AddFirstArgument(StringBuilder sb, Coefficient coefficient)
    {
        if (coefficient.Sign == "-")
            sb.Append(coefficient.Sign);
        if (!string.IsNullOrEmpty(coefficient.Value) && coefficient.UnsignedValue != "1")
            sb.Append(coefficient.UnsignedValue).Append(" * ");
        sb.Append("x^2");
    }

    private void AddSecondArgument(StringBuilder sb, Coefficient coefficient)
    {
        if (coefficient.BigNumber.HasValue && coefficient.BigNumber.Value == 0)
            return;
        AddArgumentsSign(sb, coefficient);
        if (!string.IsNullOrEmpty(coefficient.UnsignedValue) && coefficient.UnsignedValue != "1")
            sb.Append(coefficient.UnsignedValue).Append(" * ");
        sb.Append("x");
    }

    private void AddThirdArgument(StringBuilder sb, Coefficient coefficient)
    {
        if (string.IsNullOrEmpty(coefficient.UnsignedValue) || (coefficient.BigNumber.HasValue && coefficient.BigNumber == 0))
            return;
        AddArgumentsSign(sb, coefficient);
        sb.Append(coefficient.UnsignedValue);
    }

    private void AddArgumentsSign(StringBuilder sb, Coefficient argument)
    {
        var sign = "+";
        if (argument.IsBigNumber)
            sign = argument.Sign;
        sb.Append(" ");
        sb.Append(sign).Append(" ");
    }
}
