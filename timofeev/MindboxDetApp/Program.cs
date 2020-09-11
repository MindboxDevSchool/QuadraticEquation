using System;
using System.Linq;

namespace MindboxDetApp
{
    public class QuadraticEquation
    {
        // find determinator
        public static double Determinator(double a, double b, double c)
        {
            return Math.Pow(b, 2) - 4 * a * c;
        }
        // find x1, x2
        public static double[] Solution(double det, double a, double b)
        {
            double x1 = 0;
            double[] output = {x1};
            if (det == 0)
            {
                x1 = (-b + Math.Sqrt(det)) / 2 * a;
                output[0] = x1;
                Console.WriteLine("X1: " + output);
            }

            if (det < 0)
            {
                Console.WriteLine("No solutions");
            }

            if (det > 0)
            {
                x1 = (-b + Math.Sqrt(det)) / 2 * a;
                double x2 = (-b - Math.Sqrt(det)) / 2 * a;
                output[0] = x1;
                output.Append(x2);
                Console.WriteLine("X1 = " + output[0]);
                Console.WriteLine("X2 = " + output[1]);
            }
            return output;
        }
        public static void Main(string[] args)
        {
            double a, b, c;
            Console.WriteLine("Enter a:");
            // read the first coefficient
            a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter b:");
            // read the second coefficient
            b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter c:");
            // read the third coefficient
            c = Convert.ToDouble(Console.ReadLine());
            // get the determinator
            double det = Determinator(a, b, c);
            // and get the roots
            Solution(det, a, b);
        }
    }
}