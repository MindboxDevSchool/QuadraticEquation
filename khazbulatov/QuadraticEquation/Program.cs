using System;
using System.Text.RegularExpressions;

namespace QuadraticEquation
{
    public static class Program
    {
        private const int AGroup = 1, BGroup = 3, CGroup = 5;
        private static readonly Regex EquationRegex = new Regex( // https://regex101.com/r/QLHJf9/2
            @"^\s*([-+]?\s*(\d*\.\d+|\d+))x\^2\s*([-+]\s*(\d*\.\d+|\d+))x\s*([-+]\s*(\d*\.\d+|\d+))\s*=\s*0$"
        );
        
        public static string InputEquation()
        {
            Console.Write("Input a quadratic equation as 'ax^2 + bx + c = 0': ");
            return Console.ReadLine();
        }

        public static (double a, double b, double c) ParseCoefficients(string equation)
        {
            Match equationMatch = EquationRegex.Match(equation);
            GroupCollection equationMatchGroups = equationMatch.Groups;
            if (!equationMatch.Success)
            {
                throw new FormatException();
            }
            double a = double.Parse(equationMatchGroups[AGroup].Value.Replace(" ", ""));
            double b = double.Parse(equationMatchGroups[BGroup].Value.Replace(" ", ""));
            double c = double.Parse(equationMatchGroups[CGroup].Value.Replace(" ", ""));
            return (a, b, c);
        }
        
        public static bool ValidateCoefficients(double a, double b, double c)
        {
            return a != 0;
        }
        
        public static double GetDiscriminant(double a, double b, double c)
        {
            return b * b - 4 * a * c;
        }

        public static int GetRootCount(double discriminant)
        {
            if (discriminant < 0) return 0;
            if (discriminant > 0) return 2;
            return 1;
        }

        public static double[] GetRoots(double a, double b, double discriminant)
        {
            int rootCount = GetRootCount(discriminant);
            switch (rootCount)
            {
                default:
                    return new double[0];
                case 1:
                    return new double[]
                    {
                        (-b + Math.Sqrt(discriminant)) / (2 * a)
                    };
                case 2:
                    return new double[] {
                        (-b + Math.Sqrt(discriminant)) / (2 * a),
                        (-b - Math.Sqrt(discriminant)) / (2 * a)
                    };
            }
        }
        
        public static (double a, double b, double c) Input()
        {
            string equation = InputEquation();
            (double a, double b, double c) = ParseCoefficients(equation);
            if (!ValidateCoefficients(a, b, c))
            {
                throw new ArgumentException();
            }
            return (a, b, c);
        }
        
        public static double[] Solve(double a, double b, double c)
        {
            double discriminant = GetDiscriminant(a, b, c);
            double[] roots = GetRoots(a, b, discriminant);
            return roots;
        }
        
        public static void Output(double[] roots)
        {
            if (roots.Length == 0)
            {
                Console.WriteLine("No roots found");
            }
            foreach (double root in roots)
            {
                Console.WriteLine($"Found root: {root}");
            }
        }
        
        public static void Main(string[] args)
        {
            (double a, double b, double c) = Input();
            double[] roots = Solve(a, b, c);
            Output(roots);
        }
    }
}
