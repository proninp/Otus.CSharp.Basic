using System.Numerics;

namespace HomeWork03.Models;
public class Coefficient
{
    public string Value { get; set; }

    public string UnsignedValue { get; set; }
    
    public string Sign { get; set; }

    public BigInteger? BigNumber { get; set; }

    public int? Number { get; set; }

    public bool IsNumber { get => BigNumber != null; }

    public bool IsValidNumber { get => Number != null; }
}
