using HomeWork03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork03.Services;
public class QuadEquationProvider
{
    private readonly CoefficientProvider _coefficientProvider;

    public QuadEquationProvider(CoefficientProvider coefficientProvider)
    {
        _coefficientProvider = coefficientProvider;
    }

    public QuadEquation GetNewEquation()
    {
        var a = _coefficientProvider.GetCofficient(CoeficcientOrder.First.GetDescription());
        var b = _coefficientProvider.GetCofficient(CoeficcientOrder.Second.GetDescription());
        var c = _coefficientProvider.GetCofficient(CoeficcientOrder.Third.GetDescription());

        QuadEquation equation = new QuadEquation(a, b, c);
        return equation;
    }
}
