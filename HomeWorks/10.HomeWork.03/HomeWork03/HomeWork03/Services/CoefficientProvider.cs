using HomeWork03.Abstractions;
using HomeWork03.Models;
using System.Numerics;

namespace HomeWork03.Services;
public class CoefficientProvider : ICoefficientable
{
    public string Value { get; set; }

    public CoefficientProvider(string value)
    {
        Value = value;
    }

    public Coefficient GetCofficient()
    {
        var bigNumber = AsBigInteger();
        var number = AsInt();
        return new Coefficient
        {
            Value = Value,
            BigNumber = bigNumber,
            Number = number,
            Sign = GetSign(bigNumber is not null),
            UnsignedValue = GetUnsigned(bigNumber is not null)
        };
    }

    private BigInteger? AsBigInteger()
    {
        BigInteger? result = null;
        if (BigInteger.TryParse(Value, out BigInteger bigValue))
            result = bigValue;
        return result;
    }

    private int? AsInt()
    {
        int? result = null;
        if (int.TryParse(Value, out int intValue))
            result = intValue;
        return result;
    }

    private string GetSign(bool isNumber)
    {
        if (string.IsNullOrEmpty(Value) || !isNumber)
            return string.Empty;
        var first = Value.First().ToString();
        if (first == "-")
            return "-";
        return "+";
    }

    private string GetUnsigned(bool isNumber)
    {
        if (string.IsNullOrEmpty(Value))
            return string.Empty;
        if (!isNumber)
            return Value;
        var first = Value.First().ToString();
        if (first == "-" || first == "+")
            return Value.Substring(1);
        return Value;
    }


}
