using System;
using System.Collections.Generic;

namespace QuadraticEquation
{
    public class Quadratic
    {
        public void SolveQuadraticEquation()
        {
            string inputType = DefineInput();
            // We put data parse inside input, because in some cases we need to check if the input
            // is correct (by parsing it) iteratively, e.g. in case of inputting the whole equation.
            double[] coefficients = InputEquation(inputType);
            // One of redundant variable here (like double[] solutions), left for more readability.
            bool equationIsLinear = IsLinear(coefficients);
            if (equationIsLinear)
            {
                if (IsLinearAndCoefficientsAreValid(coefficients))
                {
                    double[] solutions = SolveLinearEquationWithCoefficients(coefficients);
                    PrintResults(solutions);
                }
                else
                {
                    ReturnNullSolutions();
                }
            }
            else
            {
                double d = CalculateDiscriminant(coefficients);
                if (d < 0)
                {
                    ReturnNullSolutions();
                }
                else
                {
                    double[] solutions = CalculateSolutions(coefficients, d);
                    PrintResults(solutions);
                }
            }
        }
        
        string DefineInput()
        {
            var inputOptions = new Dictionary<string, string> {{"1", "indices"}};
            Console.WriteLine("How do you want to input equation ('indices')?");
            Console.WriteLine("1 - indices");
            string input;
            do
            {
                input = Console.ReadLine();
            } while (!(inputOptions.ContainsKey(input ?? throw new NullReferenceException())));
            return inputOptions[input];
        }
        

        // input equation depending on input type
        // returns expression string or indices string
        double[] InputEquation(string inputType)
        {
            switch (inputType)
            {
                case "indices":
                    return InputAsIndices();
                //case "expression":
                //    return InputAsExpression();
                default:
                    return new double[]{};
            }
        }

        // reads equation's indices from command line
        // returns indices as string
        double[] InputAsIndices()
        {
            string indices = "";
            indices += InputIndex("a") + " ";
            indices += InputIndex("b") + " ";
            indices += InputIndex("c") + " ";
            return ParseEquation(indices, "indices");
        }

        string InputIndex(string indexNeeded)
        {
            string index;
            do
            {
                Console.WriteLine("Input '" + indexNeeded + "' index:");
                index = Console.ReadLine();
            } while (!double.TryParse(index, out _));
            return index;
        }

        // reads equation from command line
        // returns expression as string
        double[] InputAsExpression()
        {
            do
            {
                Console.WriteLine("Input your equation in format ax^2 + bx + c");
                try
                {
                    return ParseEquation(Console.ReadLine(), "expression");
                }
                catch (Exception)
                {
                    Console.WriteLine("Error in given equation! Please try again");
                }
            } while (true);
        }

        // parses equation as string, returns dictionary
        private double[] ParseEquation(string equation, string inputType)
        {
            switch (inputType)
            {
                case "indices":
                    return ParseAsIndices(equation);
                //case "expression":
                //    return ParseAsExpression(equation);
                default:
                    return new double[]{};
            }
        }

        // parses indices from "a b c" string, returns dictionary
        public double[] ParseAsIndices(string equation)
        {
            string[] arr = equation.Split(' ');
            if (arr.Length < 3)
            {
                throw new ArgumentException("Not enough coefficients!");
            }
            double[] indices = new double[] { ParseOneIndex(arr[0]), ParseOneIndex(arr[1]), ParseOneIndex(arr[2]) };
            return indices;
        }
        
        //additional parsing method
        static double ParseOneIndex(string idx)
        {
            if (!double.TryParse(idx, out var val))
            {
                throw new InvalidCastException("Error while parsing indices");
            }
            else
            {
                return val;
            }
        }

        // check if coefficients are accessible
        void checkCoefficients(double[] coefficients)
        {
            if (coefficients.Length != 3)
            {
                throw new KeyNotFoundException("Coefficients not found!");
            }
        }
        
        //check if equation is linear
        public bool IsLinear(double[] coefficients)
        {
            checkCoefficients(coefficients);
            return coefficients[0] == 0;
        }
        
        //check if equation is linear and solvable
        public bool IsLinearAndCoefficientsAreValid(double[] coefficients)
        {
            checkCoefficients(coefficients);
            return coefficients[0] == 0 && coefficients[1] != 0;
        }

        //solve linear equation, returns double[] {x}
        public double[] SolveLinearEquationWithCoefficients(double[] coefficients)
        {
            checkCoefficients(coefficients);
            if (coefficients[1] == 0)
            {
                throw new DivideByZeroException();
            }
            return new[] { -1 * coefficients[2] / coefficients[1]};
        }
        
        // calculates D as b^2 - 4ac, returns double
        public double CalculateDiscriminant(double[] coefficients)
        {
            checkCoefficients(coefficients);
            return Math.Pow(coefficients[1], 2) - 4 * coefficients[0] * coefficients[2];
        }

        // returns a message that there's no solutions
        static void ReturnNullSolutions()
        {
            Console.WriteLine("No solutions!");
        }

        // calculates x1 and x2, returns double[] = {x1, x2} for 2 solutions or {x} for 1 
        public double[] CalculateSolutions(double[] coefficients, double d)
        {
            checkCoefficients(coefficients);
            if (coefficients[0] == 0)
            {
                throw new DivideByZeroException();
            }
            double x1 = (-coefficients[1] + Math.Sqrt(d)) / (2 * coefficients[0]);
            double x2 = (-coefficients[1] - Math.Sqrt(d)) / (2 * coefficients[0]);
            return Math.Abs(x1 - x2) < Double.Epsilon ? new[] {x1} : new[] {x1, x2};
        }

        // prints solutions
        static void PrintResults(double[] solutions)
        {
            if (solutions.Length == 1)
            {
                Console.WriteLine("x = " + solutions[0]);
            }
            else
            {
                Console.WriteLine("x1 = " + solutions[0]);
                Console.WriteLine("x2 = " + solutions[1]);
            }
        }
    }
}