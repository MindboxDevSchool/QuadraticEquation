using System;
using System.Collections.Generic;

namespace QuadraticEquation
{
    public class QuadraticEquation
    {
        private double _a;
        private double _b;
        private double _c;

        private double CalculateDiscriminant()
        {
            return _b * _b - 4 * _a * _c;
        }
        
        public List<double> Solve()
        {
            double discriminant = CalculateDiscriminant();

            List<double> roots = new List<double>();
            
            if (Math.Abs(discriminant) < Double.Epsilon)
            {
                double root = -_b / (2 * _a);
                roots.Add(root);
            }
            else if (discriminant > 0)
            {
                double root1 = (-_b + Math.Sqrt(discriminant)) / (2 * _a);
                double root2 = (-_b - Math.Sqrt(discriminant)) / (2 * _a);
                roots.Add(root1);
                roots.Add(root2);
            }

            return roots;
        }
        
        public QuadraticEquation(double a, double b, double c)
        {
            _a = a;
            _b = b;
            _c = c;
        }
    }
     
    
    static class Program
    {
        public static double InputCoefficient(string coefficientName)
        {
            double coefficient;
            Console.Write("{0} = ", coefficientName);
            while (!Double.TryParse(Console.ReadLine(), out coefficient))
            {
                Console.WriteLine("Неверно введено число. Повторите ввод");
                Console.Write("{0} = ", coefficientName);
            }

            return coefficient;
        }
        
        public static QuadraticEquation InputEquation()
        {
            double a, b = 0, c = 0;
            
            Console.WriteLine("Введите коэффициенты уравнения ax^2 + bx + c = 0: ");
            a = InputCoefficient("a");
            b = InputCoefficient("b");
            c = InputCoefficient("c");

            QuadraticEquation quadraticEquation = new QuadraticEquation(a, b, c);
            return quadraticEquation;
        }
        
        public static void PrintSolution(List<double> roots)
        {
            switch (roots.Count)
            {
                case 0: 
                    Console.WriteLine("Рациональных корней нет");
                    break;
                case 1:
                    Console.WriteLine("Рациональные корни совпадают и равны {0}", roots[0]);
                    break;
                case 2:
                    Console.WriteLine("Рациональные корни: {0}, {1}", roots[0], roots[1]);
                    break;
                default:
                    //exception;
                break;
            }
        }
        
        static void Main(string[] args)
        {
            QuadraticEquation quadraticEquation = InputEquation();
            List<double> roots = quadraticEquation.Solve();
            PrintSolution(roots);
        }
    }
}