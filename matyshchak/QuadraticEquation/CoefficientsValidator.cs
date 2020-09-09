namespace QuadraticEquation
{
    public class CoefficientsValidator
    {
        public static bool CoefficientsAreInvalid((double a, double b, double c) coefficients)
        {
            var (a, b, _) = coefficients;
            return (a == 0 && b == 0);
        }
    }
}