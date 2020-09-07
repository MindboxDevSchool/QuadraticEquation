using System;

namespace QuadraticEquation
{
    public class QuadraticEquationSolver
    {
        public static void Input()
        {
            Console.WriteLine("Insert quadratic equation in format a*x2+b*x+c:");
            GetCoefficients(Console.ReadLine());
        }

        public static string[] GetCoefficients(string rawString)
        {
            string[] coeffs = {"0.0", "0.0", "0.0"};
            try
            {
                var splittedString = rawString.Split('*');
                coeffs = new string[] {splittedString[0], splittedString[1][2..], splittedString[2][1..]};
            }
            catch
            {
                Console.WriteLine("Equation inserted in wrong format!");
            }
            finally
            {
                CheckCoefficients(coeffs);
            }
            return coeffs;
        }
        
        public static void CheckCoefficients(string[] rawCoeffs)
        {
            if (rawCoeffs == new string[] {"0.0", "0.0", "0.0"})
            {
                Console.WriteLine("Equation inserted in wrong format!");
                return;
            }

            double a, b, c;
            try
            {
                a = Convert.ToDouble(rawCoeffs[0]);
                b = Convert.ToDouble(rawCoeffs[1]);
                c = Convert.ToDouble(rawCoeffs[2]);
            }
            catch
            {
                Console.WriteLine("Equation inserted in wrong format!");
            }
            finally
            {
                a = Convert.ToDouble(rawCoeffs[0]);
                b = Convert.ToDouble(rawCoeffs[1]);
                c = Convert.ToDouble(rawCoeffs[2]);
                double[] coeffs = {a, b, c};
                if (a != 0.0)
                {
                    FindDeterminator(coeffs);
                }
                else
                    Console.WriteLine("First coefficient is zero - this is not a quadratic equation!");
            }
        }

        public static double FindDeterminator(double[] coeffs)
        {
            var a = coeffs[0];
            var b = coeffs[1];
            var c = coeffs[2];

            var d = b * b - 4 * a * c;
            SolveEquationAndPrintResults(d, coeffs);
            return d;
        }

        public static void SolveEquationAndPrintResults(double determinator, double[] coeffs)
        {
            if (determinator < 0)
                Console.WriteLine("Equation has not roots!");
            else if (determinator == 0)
                Console.WriteLine("Root is: {0}", FindRootsWhenDeterminatorIsZero(determinator, coeffs));
            else
            {
                int i = 1;
                foreach (var root in FindRootsWhenDeterminatorIsPositive(determinator, coeffs))
                {
                    Console.WriteLine("Root {0} is: {1}", i, root);
                    i++;
                }
            }
        }

        public static double FindRootsWhenDeterminatorIsZero(double d, double[] coeffs)
        {
            var a = coeffs[0];
            var b = coeffs[1];
            var c = coeffs[2];
            double root = -b/ (2 * a);
            return root;
        }
        
        public static double[] FindRootsWhenDeterminatorIsPositive(double d, double[] coeffs)
        {
            var a = coeffs[0];
            var b = coeffs[1];
            var c = coeffs[2];
            double[] roots = {(-b + Math.Sqrt(d)) / (2 * a), (-b - Math.Sqrt(d)) / (2 * a)};
            return roots;
        }

        static void Main(string[] args)
        {
            Input();
        }
    }
}