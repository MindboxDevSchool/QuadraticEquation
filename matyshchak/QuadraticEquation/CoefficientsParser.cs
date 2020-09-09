using System;
using System.Linq;

namespace QuadraticEquation
{
    public static class CoefficientsParser
    {
        public static (double a, double b, double c) Parse(string input)
        {
            var splitInput = input.Split(" ");
            if (splitInput.Length != 3)
                throw new EquationInputFormatException();

            try
            {
                var coefficients = splitInput
                    .Select(double.Parse)
                    .ToList();
                return (coefficients[0], coefficients[1], coefficients[2]);
            }
            catch (FormatException)
            {
                throw new EquationInputFormatException();
            }
        }
    }
}