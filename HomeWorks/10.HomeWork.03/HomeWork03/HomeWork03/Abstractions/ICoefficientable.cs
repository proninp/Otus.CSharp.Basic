using HomeWork03.Models;
using HomeWork03.Models.Enums;
using System.Numerics;

namespace HomeWork03.Abstractions;
public interface ICoefficientable
{
    public Coefficient GetCofficient(CoefficientOrder order);

    public Coefficient GetCofficient(CoefficientOrder order, string value);
}
