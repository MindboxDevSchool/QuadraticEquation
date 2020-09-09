using System;

namespace QuadraticEquation
{
    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine(
                "Write three coefficients of your quadratic equation separated by spaces.\nExample: 1 -2 3.14\nType 'quit' to terminate.");
            
            while (true)
            {
                var input = InputProvider.GetInput();
                if (input == "quit")
                    break;
                try
                {
                    var coefficients = CoefficientsParser.Parse(input);
                    if (CoefficientsValidator.CoefficientsAreInvalid(coefficients))
                    {
                        Console.WriteLine("Coefficients are invalid. Try again.");
                        continue;
                    }                    
                    var roots = Solver.FindRoots(coefficients);
                    Outputer.Output(roots);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}