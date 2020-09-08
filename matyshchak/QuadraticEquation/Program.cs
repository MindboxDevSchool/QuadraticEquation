namespace QuadraticEquation
{
    internal static class Program
    {
        private static void Main()
        {
            var input = InputProvider.GetInput();
            var coefficients = CoefficientsParser.Parse(input);
            var roots = Solver.FindRoots(coefficients);
            Outputer.Output(roots);
        }
    }
}