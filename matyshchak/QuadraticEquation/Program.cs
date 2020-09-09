using System;

namespace QuadraticEquation
{
    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine(
                "Write three coefficients of your quadratic equation separated by spaces.\n" + 
                "Example: 1 -2 3.14\n" + 
                "Type 'quit' to terminate.");
            
            while (true)
            {
                var input = InputProvider.GetInput();
                if (input == "quit")
                    break;
                try
                {
                    var coefficients = CoefficientsParser.Parse(input);
                    var roots = Solver.FindRoots(coefficients);
                    Outputer.Output(roots);
                }
                catch (EquationInputFormatException)
                {
                    Console.WriteLine(
                        "Invalid format. Expecting three real numbers separated by spaces.\n" +
                        "Example: 1 -2 3.14");
                }
                catch (InvalidCoefficientsException)
                {
                    Console.WriteLine(
                        "Coefficients are invalid. Try again.");
                }
            }
        }
    }
}