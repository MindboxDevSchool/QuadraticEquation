using System;

namespace QuadraticEquation
{
    static class Program
    {
        static void Main(string[] args)
        {
            string equation = GetEquation();
            EquationSolver equationSolver = new EquationSolver(equation);

            double[] roots;
            
            try
            {
                roots = equationSolver.GetRoots();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            
            foreach (var root in roots)
            {
                Console.WriteLine(root);
            }
        }

        private static string GetEquation()
        {
            Console.WriteLine("Введите уравнение в формате [-] Ax^2 [+|-] Bx [+|-] C:");
            string equation = Console.ReadLine();
            return equation;
        }
    }
}