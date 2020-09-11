using System;
using System.Text.RegularExpressions;

namespace QuadraticEquationSolver
{
    public enum QuadraticEquationMode
    {
        Quadratic,
        Linear,
        NoSolutions,
        InfSolutions
    }

    public struct Сoefficients
    {
        public double a;
        public double b;
        public double c;

        public Сoefficients(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public override string ToString()
        {
            return $"a:{a} b:{b} c:{c}";
        }
    }

    public class QuadraticEquation
    {
        private QuadraticEquationMode mode;
        private Сoefficients coefficients;
        private double[] _roots;
        private double _discriminant;

        public double[] Roots
        {
            get
            {
                if (this.mode != QuadraticEquationMode.NoSolutions)
                {
                    if (this._roots == null)
                    {
                        if (mode == QuadraticEquationMode.Linear)
                        {
                            this._roots = SolveLinearEquation();
                        }
                        else if (mode == QuadraticEquationMode.Quadratic)
                        {
                            this._roots = SolveQuadraticEquation();
                        }
                        else if (mode == QuadraticEquationMode.InfSolutions)
                        {
                            this._roots = new double[] {Double.PositiveInfinity};
                        }
                    }

                    return this._roots;
                }

                return null;
            }
        }

        public QuadraticEquation(Сoefficients coefficients)
        {
            this._roots = null;
            this.coefficients = coefficients;
            this.mode = GetMode();
        }

        public QuadraticEquation(string inputString)
        {
            this._roots = null;
            this.coefficients = GetValuesFromInputString(inputString);
            this.mode = GetMode();
        }

        private Сoefficients GetValuesFromInputString(string inputString)
        {
            //inputString sample: "12x^2 + 10x - 15 + 2x^2 - x^2 - 9 = 0"
            double a = 0;
            double b = 0;
            double c = 0;

            Regex patternForA = new Regex(@"[+|-]?[0-9]*x[\^]2");
            Regex patternForB = new Regex(@"[-|+]?[0-9]*x");
            Regex patternForC = new Regex(@"[-|+]?\d+");

            inputString = Regex.Replace(inputString, @"\s", "");

            MatchCollection matchesForA = patternForA.Matches(inputString);
            if (matchesForA.Count > 0)
                foreach (Match match in matchesForA)
                {
                    if (match == null)
                        continue;

                    string trimmedMatch = Regex.Replace(
                        match.Value.Trim(new char[] {'+'}),
                        @"x[\^]2",
                        "");
                    if (trimmedMatch == "")
                        trimmedMatch = "1";
                    else if (trimmedMatch == "-")
                        trimmedMatch = "-1";
                    a += Convert.ToDouble(trimmedMatch);
                }

            inputString = patternForA.Replace(inputString, "");

            MatchCollection matchesForB = patternForB.Matches(inputString);
            if (matchesForB.Count > 0)
                foreach (Match match in matchesForB)
                {
                    if (match == null)
                        continue;

                    string trimmedMatch = match.Value.Trim(new char[] {'+', 'x'});
                    if (trimmedMatch == "")
                        trimmedMatch = "1";
                    else if (trimmedMatch == "-")
                        trimmedMatch = "-1";
                    b += Convert.ToDouble(trimmedMatch);
                }

            inputString = patternForB.Replace(inputString, "");

            MatchCollection matchesForC = patternForC.Matches(inputString);
            if (matchesForC.Count > 0)
                foreach (Match match in matchesForC)
                {
                    if (match != null)
                        c += Convert.ToDouble(match.Value.Trim(new char[] {'+'}));
                }

            return new Сoefficients(a, b, c);
        }

        private QuadraticEquationMode GetMode()
        {
            QuadraticEquationMode quadraticEquationMode = QuadraticEquationMode.NoSolutions;

            if (this.coefficients.a == 0)
            {
                if (this.coefficients.b == 0)
                {
                    if (this.coefficients.c == 0)
                        quadraticEquationMode = QuadraticEquationMode.InfSolutions;
                    else
                        quadraticEquationMode = QuadraticEquationMode.NoSolutions;
                }
                else
                    quadraticEquationMode = QuadraticEquationMode.Linear;
            }
            else
            {
                this._discriminant = CountDiscriminant();
                if (_discriminant < 0)
                    quadraticEquationMode = QuadraticEquationMode.NoSolutions;
                else
                    quadraticEquationMode = QuadraticEquationMode.Quadratic;
            }

            return quadraticEquationMode;
        }

        private double CountDiscriminant()
        {
            return Math.Pow(this.coefficients.b, 2) - 4 * this.coefficients.a * this.coefficients.c;
        }

        private double[] SolveQuadraticEquation()
        {
            double[] solution = new double[] {0, 0};

            if (this._discriminant > 0)
            {
                solution[0] = (-coefficients.b + Math.Sqrt(this._discriminant)) / (2 * coefficients.a);
                solution[1] = (-coefficients.b - Math.Sqrt(this._discriminant)) / (2 * coefficients.a);
            }
            else if (this._discriminant == 0)
            {
                solution[0] = solution[1] = (-coefficients.b + Math.Sqrt(this._discriminant)) / (2 * coefficients.a);
            }

            return solution;
        }

        private double[] SolveLinearEquation()
        {
            double[] solution = new double[] {0};

            if (this.coefficients.c == 0)
                solution[0] = 0;
            else
                solution[0] = -1 * this.coefficients.c / this.coefficients.b;

            return solution;
        }
    }
}