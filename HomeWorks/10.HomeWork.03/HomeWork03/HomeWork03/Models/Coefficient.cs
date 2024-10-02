using System.Numerics;

namespace HomeWork03.Models;
public sealed class Coefficient
{
    public CoeficcientOrder Order { get; init; }

    public string Value { get; set; }

    public string UnsignedValue { get; set; }
    
    public string Sign { get; set; }

    public BigInteger? BigNumber { get; set; }

    public int? Number { get; set; }

    public bool IsNumber { get => BigNumber.HasValue; }

    public bool IsValidNumber { get => Number.HasValue; }
}
