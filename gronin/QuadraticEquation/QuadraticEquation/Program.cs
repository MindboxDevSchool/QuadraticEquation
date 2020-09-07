using System;

namespace QuadraticEquationSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            QuadraticEquation d=new QuadraticEquation(5, -5, 31);
            d.Solve();
            Console.WriteLine(d.ToString());
        }
    }
}