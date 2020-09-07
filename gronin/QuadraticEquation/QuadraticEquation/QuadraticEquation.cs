using System;


namespace QuadraticEquationSolver
{
    public class QuadraticEquation
    {
        private double a, b, c;
        private double x1, x2;
        private bool isRootsReal;

        public double X1
        {
            get { return x1; }
        }

        public double X2
        {
            get { return x2; }
        }


        public QuadraticEquation(double A, double B, double C)
        {
            if (A == 0 && B == 0 && C == 0)
                throw new ArgumentException("All coefficients can't be zero");
            if (A == 0)
                throw new ArgumentException("First coefficient can't be zero");
            this.a = A;
            this.b = B;
            this.c = C;
        }


        private double Descriminant()
        {
            double d;
            d = b * b - 4 * a * c;
            return d;
        }

        public void Solve()
        {
            double D = Descriminant();
            isRootsReal = (D >= 0);
            x1 = (-b + Math.Sqrt(D)) / (2 * a);
            x2 = (-b - Math.Sqrt(D)) / (2 * a);
        }


        public override string ToString()
        {
            return "Roots: " +
                   (isRootsReal
                       ? "X1=" + x1.ToString() +
                         "; X2=" + x2.ToString()
                       : "Real roots doesn't exist");
        }
    }
}