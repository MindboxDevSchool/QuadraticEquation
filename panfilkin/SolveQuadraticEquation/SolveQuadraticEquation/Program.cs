using System;
using System.Globalization;

namespace SolveQuadraticEquation
{
    public static class Program
    {
        static void Main()
        {
            Console.WriteLine("SolveQuadraticEquation");
            var coefficients = ParseEquation(InputEquation());
            var discriminant = EqualDiscriminant(coefficients);
            var roots = EqualRoots(coefficients, discriminant);
            WriteRoots(roots);
        }

        private static string InputEquation()
        {
            Console.WriteLine("Input equation (12x^2-30.6x+9)");
            Console.WriteLine("(You must write 0x, if one of part is absence!)");
            Console.Write("Equation: ");
            return(Console.ReadLine());
        }
        
        public static double[] ParseEquation(string equation)
        {
            double a;
            double b;
            double c;
            try // And validation
            {
                equation = equation.Replace(" ", "");
                var indexOfX2 = equation.IndexOf("x^2", StringComparison.Ordinal);
                var indexOfX = equation.IndexOf("x", indexOfX2+3, StringComparison.Ordinal);
                var aString = equation.Substring(0, indexOfX2).Replace("+", "");
                var bString = equation.Substring(indexOfX2 + 3, 
                    indexOfX - indexOfX2 - 3).Replace("+", "");
                var cString = equation.Substring(indexOfX + 1, 
                    equation.Length - indexOfX - 1).Replace("+", "");
                a = double.Parse(aString, 
                    CultureInfo.InvariantCulture);
                b = double.Parse(bString,
                    CultureInfo.InvariantCulture);
                c = double.Parse(cString,
                    CultureInfo.InvariantCulture);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return(new[] {a, b, c});
        }
        
        public static double EqualDiscriminant(double[] coefficients)
        {
            double a = coefficients[0];
            double b = coefficients[1];
            double c = coefficients[2];
            return(b*b-4*a*c);
        }
        
        public static double[] EqualRoots(double[] coefficients, double discriminant)
        {
            double a = coefficients[0];
            double b = coefficients[1];
            double c = coefficients[2];
            double[] roots;
            if (a == 0) // Cases of linear equals
            {
                if (b != 0 && c != 0)
                {
                    roots = new double[1];
                    roots[0] = -c / b;
                    return (roots);
                }
                if (b == 0 && c != 0) // No roots
                {
                    roots = new double[0];
                    return (roots);
                }
                if (b == 0 && c == 0) // Any roots
                {
                    roots = new double[3];
                    return (roots);
                }
            }
            if (discriminant > 0) // Two roots
            {
                roots = new double[2];
                roots[0] = (-b - Math.Sqrt(discriminant)) / (2 * a);
                roots[1] = (-b + Math.Sqrt(discriminant)) / (2 * a);
                return(roots);
            }
            if (discriminant == 0.0) // One root
            {
                roots = new double[1];
                roots[0] = (-b - Math.Sqrt(discriminant)) / (2 * a);
                return(roots);
            }
            if (discriminant < 0.0) // No roots
            {
                roots = new double[0];
                return(roots);
            }

            roots = new double[0];
            return(roots);
        }

        private static void WriteRoots(double[] roots)
        {
            switch (roots.Length)
            {
                case 0:
                    Console.WriteLine("Roots not found");
                    break;
                case 1:
                    Console.WriteLine("x = " + roots[0]);
                    break;
                case 2:
                    Console.WriteLine("x1 = " + roots[0] + "; x2 = " + roots[1]);
                    break;
                case 3:
                    Console.WriteLine("Infinitely many roots");
                    break;
            }
        }
        
        
        
    }
}
