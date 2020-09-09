using System;
using System.Collections.Generic;

namespace QuadraticEquation
{
    public static class Outputer
    {
        public static void Output(List<double> roots)
        {
            switch (roots.Count)
            {
                case 0:
                    Console.WriteLine("There are no real roots");
                    break;
                case 1:
                    Console.WriteLine($"There is a single real root:\nx = {roots[0]}");
                    break;
                case 2:
                    Console.WriteLine($"Real roots are:\nx1 = {roots[0]}\nx2 = {roots[1]}");
                    break;
            }
        }
    }
}