using System.Numerics;
using HomeWork03.Models.Enums;

namespace HomeWork03.Models;
public sealed class Coefficient
{
    public CoefficientOrder Order { get; set; }
    
    public string Value { get; set; }

    public string UnsignedValue { get; set; }
    
    public string Sign { get; set; }

    public BigInteger? BigNumber { get; set; }

    public int? Number { get; set; }

    public bool IsNumber { get => Number.HasValue || BigNumber.HasValue; }
    
    public bool IsBigNumber { get => BigNumber.HasValue; }

    public bool IsValidNumber { get => Number.HasValue; }

    public bool IsEmpty { get => string.IsNullOrEmpty(Value) || Value == Order.GetDescription(); }
}
