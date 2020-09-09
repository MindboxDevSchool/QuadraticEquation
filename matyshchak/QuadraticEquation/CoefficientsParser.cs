using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace QuadraticEquation
{
    public static class CoefficientsParser
    {
        public static (double a, double b, double c) Parse(string input)
        {
            var regex = new Regex("([+-]?(\\d[.])?\\d+\\s*){3}");
            if (!regex.IsMatch(input))
            {
                throw new FormatException(
                    "Invalid format. Expecting three real numbers separated by spaces.\nExample: 1 -2 3.14");
            }

            var coefficients = Regex
                .Split(input, " ")
                .Select(double.Parse)
                .ToList();
            
            return (coefficients[0], coefficients[1], coefficients[2]);
        }
    }
}