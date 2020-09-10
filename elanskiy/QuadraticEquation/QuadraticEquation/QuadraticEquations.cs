using System;

namespace QuadraticEquation
{
    public static class QuadraticEquations
    {
        static object[] GetInputs()
        {
            throw new NotImplementedException();
        }

        public static bool TryParse(string inp1, string inp2, string inp3, out double a, out double b, out double c)
        {
            a = b = c = 0;
            return double.TryParse(inp1, out a) && double.TryParse(inp2, out b) && double.TryParse(inp3, out c);
        }

        public static bool AreValidatedInputes(double a, double b, double c) => a != 0 && (b !=0 || c != 0);

        public static double GetDiscriminant(double a, double b, double c) => b * b - 4 * a * c;

        public static bool DoesExistRealRoots(double discriminant) => discriminant >= 0;

        public static double[] FindRoots(double discriminant, double a, double b)
        {
            double x1 = (-b + Math.Sqrt(discriminant)) / 2 / a; 
            double x2 = (-b - Math.Sqrt(discriminant)) / 2 / a;
            return new double[] {x1, x2};
        }

        static double[] ReturnResult(double[] roots)
        {
            throw new NotImplementedException();
        }
    }
}