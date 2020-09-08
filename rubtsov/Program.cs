using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace QuadraticEquations
{
    public class Program
    {
        public enum CoefValidation
        {
            NoRoots,
            MayHaveOneOrTwoRoots,
            InfiniteNumberOfRoots,
            NotQuadratic
        }

        public enum DiscriminantValue
        {
            Negative = -1,
            Zero,
            Positive
        }
        public static void Func(int[] arr)
        {

        }
        static void Main(string[] args)
        {
            var userInput = UserInput();
            var parsedRoots = Parser(userInput);
            double a = parsedRoots[0];
            double b = parsedRoots[1];
            double c = parsedRoots[2];
            var coefValidationResult = ValidateCoefs(a, b, c);
            if (coefValidationResult == CoefValidation.MayHaveOneOrTwoRoots)
            {
                double discriminant = GetDiscriminant(a, b, c);
                var discrValidation = ValidateDiscr(discriminant);
                if (discrValidation != DiscriminantValue.Negative)
                {
                    var roots = FindRoots(discrValidation, discriminant, a, b);
                    Output(roots);
                }
            }
        }

        public static object[] UserInput()
        {
            Console.WriteLine("Введите коэффициенты уравнения");
            object[] input = new Object[3];
            Console.Write("a:");
            input[0] = Console.ReadLine();
            Console.Write("b:");
            input[1] = Console.ReadLine();
            Console.Write("c:");
            input[2] = Console.ReadLine();
            return input;
        }

        public static double[] Parser(object[] input)
        {
            return input.Select(Convert.ToDouble).ToArray();
        }

        public static CoefValidation ValidateCoefs(double a, double b, double c)
        {
            if (a == 0 && b == 0 && c == 0 || (b==0 && c==0))
            {
                return CoefValidation.InfiniteNumberOfRoots;
            }
            else if (a == 0 && b == 0 && c != 0)
            {
                return CoefValidation.NoRoots;
            }
            else if (a == 0 && b != 0 && c != 0)
            {
                return CoefValidation.NotQuadratic;
            }
            return CoefValidation.MayHaveOneOrTwoRoots;
        }

        public static double GetDiscriminant(double a, double b, double c)
        {
            return b * b - 4 * a * c;
        }

        public static DiscriminantValue ValidateDiscr(double d)
        {
            if (d < 0)
            {
                Console.WriteLine("Парабола не перескает ось OX. Уравнение не имеет корней.");
                return DiscriminantValue.Negative;
            }
            else if (d == 0)
            {
                Console.WriteLine("Уравнение имеет один корень:");
                return DiscriminantValue.Zero;
            }
            Console.WriteLine("Уравнение имеет два корня:");
            return DiscriminantValue.Positive;
        }
        
        public static double[] FindRoots(DiscriminantValue discriminantValue, double discriminant, double a, double b)
        {
            if (discriminantValue == DiscriminantValue.Zero)
            {
                return new double[1] {-b /2 / a};
            }
            return new double[2]
            {
                (-b + Math.Sqrt(discriminant)) / 2 / a,
                (-b - Math.Sqrt(discriminant)) / 2 / a
            };
        }
        
        static void Output(double[] roots)
        {
            if (roots.Length == 1)
            {
                Console.WriteLine(roots[0]);
            }
            Console.WriteLine("{0} и {1}", roots[0], roots[1]);
        }
    }
} 