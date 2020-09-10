using System;
using System.Collections.Generic;

namespace QuadraticEquationSolver
{
    public class Program
    {
        static void Main(string[] args)
        {
            double[] coefs = ReadCoefficients();
            double a = coefs[0];
            double b = coefs[1];
            double discriminant = GetDiscriminant(coefs);
            List<double> roots = GetRoots(discriminant, a, b);
            ShowRoots(roots);
        }
        public static double[] ReadCoefficients()
        {
            Console.WriteLine("Quadratic equation conventionally looks like this: \"ax^2 + bx - c = 0\"");
            Console.WriteLine("Enter a: ");
            double a = ParseCoefficient();
            Console.WriteLine("Enter b: ");
            double b = ParseCoefficient();
            Console.WriteLine("Enter c: ");
            double c = ParseCoefficient();
            
            double[] coefs = new[] {a, b, c};
            return coefs;
        }
        private static double ParseCoefficient()
        {
            double coef;
            try
            {
                coef = Double.Parse(Console.ReadLine() ?? throw new Exception("Value cannot be null!"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return coef;
        }
        public static double GetDiscriminant(double[] coefs)
        {
            double a = coefs[0];
            double b = coefs[1];
            double c = coefs[2];
            double discriminant = Math.Pow(b, 2) - (4 * a * c);
            return discriminant;
        }
        public static List<double> GetRoots(double discriminant, double a, double b)
        {
            List<double> roots = new List<double>();

            if (discriminant == 0)
            {
                double x1 = (-b) / (2 * a);
                roots.Add(x1);
                return roots;
            }
            else if (discriminant > 0)
            {
                double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                roots.Add(x1);
                double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                roots.Add(x2);
                return roots;
            }
            else
            {
                return roots;
            }
        }
        public static void ShowRoots(List<double> roots)
        {
            Console.WriteLine($"The number of roots in this equation: {roots.Count}");
            if (roots.Count == 0)
            {
                Console.WriteLine("The equation doesn't have roots.");
            }
            else
            {
                Console.WriteLine("The equation's roots:");
                foreach (double root in roots)
                {
                    Console.WriteLine(root.ToString());
                }
            }
        }
    }
}