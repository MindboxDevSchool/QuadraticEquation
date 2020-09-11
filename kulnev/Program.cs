using System;

namespace HW2
{
    public class Program
    {
        static void Main(string[] args)
        {
            double a, b, c;
            Console.WriteLine("Введите a: ");
            a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите b: ");
            b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите c: ");
            c = Convert.ToDouble(Console.ReadLine());
            QuadAndLinearEquation myclass = new QuadAndLinearEquation(a, b, c);
        }
    }
    
    public class QuadAndLinearEquation
    {
        private double a;
        private double b;
        private double c;
        private double D;
        private double x1;
        private double x2;
        
        public QuadAndLinearEquation(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public double FindDiscriminant()
        {
            D = Math.Pow(b, 2) - 4 * a * c;
            return D;
        }

        public double[] FindQuadRoots()
        {
            if ((D > 0 || D == 0) && (a!=0))
            {
                x1 = (-b + Math.Sqrt(D)) / (2 * a);
                x2 = (-b - Math.Sqrt(D)) / (2 * a);
            }
            return new double[] {x1,x2};
        }

        public double FindLinearRoots()
        {
            if (a == 0 && b !=0)
            {
                D = 0;
                x1 = (-c / b);
            }

            return x1;
        }
        
        public void OutputRoots()
        {
            if (D == 0)
            {
                Console.WriteLine(x1);
            }
            else if (D > 0)
            {
                Console.WriteLine(x1);
                Console.WriteLine(x2);
            }
            else
            {
                Console.WriteLine("No roots");
            }
        }
    }
}