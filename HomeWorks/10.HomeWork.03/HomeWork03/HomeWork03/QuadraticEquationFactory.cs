using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork03.Abstractions;

namespace HomeWork03;
public class QuadraticEquationFactory : IQuadraticEquationFactory
{
    public QuadraticEquationSolver GetSolver(double a, double b, double c)
    {
        return new QuadraticEquationSolver(a, b, c);
    }
}
