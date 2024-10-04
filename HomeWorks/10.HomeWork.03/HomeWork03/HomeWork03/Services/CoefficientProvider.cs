using HomeWork03.Abstractions;
using HomeWork03.Models;
using HomeWork03.Models.Enums;
using System.Numerics;

namespace HomeWork03.Services;
public sealed class CoefficientProvider : ICoefficientable
{
    private string _value = string.Empty;

    public Coefficient GetCofficient(CoefficientOrder order) =>
        GetCofficient(order, order.GetDescription());

    public Coefficient GetCofficient(CoefficientOrder order, string value)
    {
        _value = value;
        var bigNumber = AsBigNumber();
        var number = AsNumber();
        return new Coefficient
        {
            Order = order,
            Value = _value,
            BigNumber = bigNumber,
            Number = number,
            Sign = GetSign(bigNumber is not null),
            UnsignedValue = GetUnsigned(bigNumber is not null)
        };
    }

    private BigInteger? AsBigNumber()
    {
        BigInteger? result = null;
        if (BigInteger.TryParse(_value, out BigInteger bigValue))
            result = bigValue;
        return result;
    }

    private int? AsNumber()
    {
        int? result = null;
        if (int.TryParse(_value, out int doubleValue))
            result = doubleValue;
        return result;
    }

    private string GetSign(bool isNumber)
    {
        if (string.IsNullOrEmpty(_value) || !isNumber)
            return string.Empty;
        var first = _value.First().ToString();
        if (first == "-")
            return "-";
        return "+";
    }

    private string GetUnsigned(bool isNumber)
    {
        if (string.IsNullOrEmpty(_value))
            return string.Empty;
        if (!isNumber)
            return _value;
        var first = _value.First().ToString();
        if (first == "-" || first == "+")
            return _value.Substring(1);
        return _value;
    }
}
