using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Quadatic
    {
        public void SolveQuadraticEquation()
        {
            string inputType = DefineInput();
            // We put data parse inside input, because in some cases we need to check if the input
            // is correct (by parsing it) iteratively, e.g. in case of inputting the whole equasion.
            Dictionary<string, double> coefficients = InputEquation(inputType);
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
            var inputOptions = new HashSet<string> {"indices"};
            Console.WriteLine("How do you want to input equation ('indices')?");
            string input;
            do
            {
                input = Console.ReadLine();
            } while (!(inputOptions.Contains(input)));
            return input;
        }

        // input equation depending on input type
        // returns expression string or indices string
        Dictionary<string, double> InputEquation(string inputType)
        {
            switch (inputType)
            {
                case "indices":
                    return InputAsIndices();
                //case "expression":
                //    return InputAsExpression();
                default:
                    return new Dictionary<string, double>();
            }
        }

        // reads equation's indices from command line
        // returns indices as string
        Dictionary<string, double> InputAsIndices()
        {
            string indices = "";
            indices += InputOneIndex("a") + " ";
            indices += InputOneIndex("b") + " ";
            indices += InputOneIndex("c") + " ";
            return ParseEquation(indices, "indices");
        }

        string InputOneIndex(string idxNeeded)
        {
            string idx;
            do
            {
                Console.WriteLine("Input '" + idxNeeded + "' index:");
                idx = Console.ReadLine();
            } while (int.TryParse(idx, out _));
            return idx;
        }

        // reads equation from command line
        // returns expression as string
        Dictionary<string, double> InputAsExpression()
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
        public Dictionary<string, double> ParseEquation(string equation, string inputType)
        {
            switch (inputType)
            {
                case "indices":
                    return ParseAsIndices(equation);
                //case "expression":
                //    return ParseAsExpression(equation);
                default:
                    return new Dictionary<string, double>();
            }
        }

        // parses indices from "a b c" string, returns dictionary
        public Dictionary<string, double> ParseAsIndices(string equation)
        {
            string[] arr = equation.Split(' ');
            if (arr.Length < 3)
            {
                throw new ArgumentException("Not enough coefficients!");
            }
            Dictionary<string, double> indices = new Dictionary<string, double>
            {
                ["a"] = ParseOneIndex(arr[0]), 
                ["b"] = ParseOneIndex(arr[1]), 
                ["c"] = ParseOneIndex(arr[2])
            };
            return indices;
        }
        //additional parsing method
        static double ParseOneIndex(string idx)
        {
            double val = 0;
            if (!double.TryParse(idx, out val))
            {
                throw new InvalidCastException("Error while parsing indices");
            }
            else
            {
                return val;
            }
        } 

        //static Dictionary<string, double> ParseAsExpression(string equation)
        //{
        //    var coefficients = new Dictionary<string, double>
        //    {
        //        ["a"] = 0, ["b"] = 0, ["c"] = 0
        //    };
        //    string[] arr = equation.Split(' ');
        //    bool positive = true;
        //    bool wasSign = false;
        //    
        //    return coefficients;
        //}
        
        // check if coefficients are accessible
        void checkCoefficients(Dictionary<string, double> coefficients)
        {
            if (!coefficients.ContainsKey("a") || !coefficients.ContainsKey("b") || !coefficients.ContainsKey("c"))
            {
                throw new KeyNotFoundException("Coefficients not found!");
            }
        }
        
        //check if equation is linear
        public bool IsLinear(Dictionary<string, double> coefficients)
        {
            checkCoefficients(coefficients);
            return coefficients["a"] == 0;
        }
        
        //check if equation is linear and solvable
        public bool IsLinearAndCoefficientsAreValid(Dictionary<string, double> coefficients)
        {
            checkCoefficients(coefficients);
            return coefficients["a"] == 0 && coefficients["b"] != 0;
        }

        //solve linear equation, returns double[] {x}
        public double[] SolveLinearEquationWithCoefficients(Dictionary<string, double> coefficients)
        {
            checkCoefficients(coefficients);
            if (coefficients["b"] == 0)
            {
                throw new ArgumentException("Division by zero");
            }
            return new[] { -1 * coefficients["c"] / coefficients["b"]};
        }
        
        // calculates D as b^2 - 4ac, returns double
        public double CalculateDiscriminant(Dictionary<string, double> coefficients)
        {
            checkCoefficients(coefficients);
            return Math.Pow(coefficients["b"], 2) - 4 * coefficients["a"] * coefficients["c"];
        }

        // returns a message that there's no solutions
        static void ReturnNullSolutions()
        {
            Console.WriteLine("No solutions!");
        }

        // calculates x1 and x2, returns double[] = {x1, x2} for 2 solutions or {x} for 1 
        public double[] CalculateSolutions(Dictionary<string, double> coefficients, double d)
        {
            checkCoefficients(coefficients);
            if (coefficients["a"] == 0)
            {
                throw new ArgumentException("Division by zero");
            }
            double x1 = (-coefficients["b"] + Math.Sqrt(d)) / (2 * coefficients["a"]);
            double x2 = (-coefficients["b"] - Math.Sqrt(d)) / (2 * coefficients["a"]);
            return Math.Abs(x1 - x2) < 0.0000000000001 ? new[] {x1} : new[] {x1, x2};
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