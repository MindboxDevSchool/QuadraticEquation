using System;
using System.Collections.Generic;

namespace QuadraticEquation
{
    public static class Solver
    {
        public static List<double> FindRoots((double a, double b, double c) coefficients)
        {
            var (a, b, c) = coefficients;
            var roots = new List<double>();
            if (a == 0)
            {
                if (b == 0)
                    throw new InvalidCoefficientsException();
                roots.Add(-c / b);
                return roots;
            }
            var discriminant = Math.Pow(b, 2) - 4 * a * c;
            if (discriminant < 0)
            {
                return roots;
            } 
            var x1 = (-b - Math.Sqrt(discriminant)) / (2 * a);
            roots.Add(x1);
            if (!(discriminant > 0))
                return roots;
            var x2 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            roots.Add(x2);
            return roots;
        }
    }
}