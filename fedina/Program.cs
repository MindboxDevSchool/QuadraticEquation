using System;
using System.Security.Cryptography;

namespace ConsoleApp1
{
    public class Program1
    {
        static void Main(string[] args)
        {
            var input = GetInputs();
            var parsed_input = ParseInput(input);
            double a = parsed_input[0];
            double b = parsed_input[1];
            double c = parsed_input[2];
            EquationTypes type = CheckEquationType(a, b, c);
            double D = GetDiscriminant(a, b, c);
            
            if (type == EquationTypes.NoRoots)
                Console.WriteLine("Equation is linear and has no roots.\n");
            
            if (type == EquationTypes.InfiniteNumberOfRoots)
                Console.WriteLine("Equation has infinite number of roots.\n");
            if (type == EquationTypes.DegenerateEquation)
            {
                ReturnResult(type, FindRoots(type, D, a, b, c));
            }

            if (type == EquationTypes.MayHaveOneOrTwoRoots)
            {
                if (ValidateDiscriminant(D))
                {
                    ReturnResult(type, FindRoots(type, D, a, b, c));
                }
                else
                {
                    Console.WriteLine("D < 0. Equation has no real roots.\n");
                }
            }
            
        }
        
        public static object[] GetInputs()
        // считываем коэффициенты уравнения без их проверки
        {
            object[] input = new object[3];
            Console.WriteLine("Equation has form ax^2+bx+c=0 (a>0). \n Reading coefficients...\n");
            Console.WriteLine("Input a: \n");
            input[0] = Console.ReadLine();
            
            Console.WriteLine("Input b: \n");
            input[1] = Console.ReadLine();
            
            Console.WriteLine("Input c: \n");
            input[2] = Console.ReadLine();

            return input;
            // throw new NotImplementedException();
        }

        public static double[] ParseInput(object[] input)
        {
            double[] ParsedInput = new double[3];
            if (input.Length == 3)
            {
                for(int i = 0; i < 3; i++)
                {
                    if (input[i] != null)
                    {
                        ParsedInput[i] = Convert.ToDouble(input[i]);
                    }
                    else
                    {
                        Console.WriteLine("Inputs cannot be null! \n");
                        throw new NotImplementedException();
                    }
                }
            }
            else
            {
                Console.WriteLine("There must be 3 input values! \n");
                throw new NotImplementedException();
            }

            return ParsedInput;
        }
        
        public enum EquationTypes
        {
            DegenerateEquation,
            NoRoots,
            MayHaveOneOrTwoRoots,
            InfiniteNumberOfRoots
        }
        
        public static EquationTypes CheckEquationType(double a, double b, double c)
        {
            if (a == 0 && b != 0 && c != 0)
            {
                return EquationTypes.DegenerateEquation;
            }
            else if (a == 0 && b == 0 && c != 0)
            {
                return EquationTypes.NoRoots;
            }
            else if (a == 0 && b == 0 && c == 0)
            {
                return EquationTypes.InfiniteNumberOfRoots;
            }
            return EquationTypes.MayHaveOneOrTwoRoots;
        }

        public static double GetDiscriminant(double a, double b, double c)
        {
            double d = b * b - 4 * a * c;
            return d;
            // throw new NotImplementedException();
        }

        public static bool ValidateDiscriminant(double discriminant)
        {
            if (discriminant < 0)   
            {
                Console.WriteLine("Discriminant is negative. No real roots. \n");
                return false;
                // throw new NotImplementedException();
            }

            return true;
        }

        public static double[] FindRoots(EquationTypes type, double discriminant, double a, double b, double c)
        {
            if (type == EquationTypes.MayHaveOneOrTwoRoots)
            {
                double x2 = (-b + Math.Sqrt(discriminant)) / 2.0 / a; 
                double x1 = (-b - Math.Sqrt(discriminant)) / 2.0 / a;
                return new double[] {x1, x2};
            }

            if (type == EquationTypes.DegenerateEquation)
            {
                double x1 = -c / b;
                return new double[] {x1};
            }
            else return new double[] { };

        }

        static void ReturnResult(EquationTypes type, double[] roots)
        {
            if (type == EquationTypes.MayHaveOneOrTwoRoots)
            {
                Console.WriteLine("Solved successfully! Equation is quadratic has two roots: \n");
                Console.WriteLine("{0} and {1}\n", roots[0], roots[1]);
            }
            else if (type == EquationTypes.DegenerateEquation)
            {
                Console.WriteLine("Solved successfully! Equation is linear and has one root: \n");
                Console.WriteLine("{0}\n", roots[0]);
            }
        }
    }
}