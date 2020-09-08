using System;

namespace QuadraticEquation
{
    internal static class InputProvider
    {
        public static string GetInput()
        {
            Console.WriteLine("Write three coefficients of your quadratic equation separated by spaces");
            var input = Console.ReadLine();
            return input;
        }
    }
}