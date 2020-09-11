using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Stepenko_Quadratic_Equation_Solver
{
    public class Program
    {
        public static string read_equation()
        {
            Console.WriteLine("Enter the quadratic equation to start.\n" +
                              "You can use any form you like " +
                              "but do not forget about zero coefficients" +
                              " and, please, escape integers: write them with points and one or more zeroes.");
            Console.Write("My quadratic equation: ");
            string equation = Console.ReadLine();
            return equation;
        }

        public static List<String> get_coefficients(String equation)
        {
            equation = equation.ToString().Replace(" ", "");
            var rawParsedCoefficients = Regex.Matches(equation, @"(?<coe>[-+]?[0-9]*\.[0-9]+)").Cast<Match>()
                .Select(m => m.Groups["coe"].Value).ToList();
            var uncheckedCoefficients = new List<string>();

            foreach (var rawParsedCoefficient in rawParsedCoefficients)
            {
                var signParsedCoefficients = rawParsedCoefficient.ToString().Replace("+", "");
                uncheckedCoefficients.Add(signParsedCoefficients);
            }

            if (uncheckedCoefficients.Count() < 3)
            {
                uncheckedCoefficients.Clear();
                uncheckedCoefficients.Add("Error");
                Console.WriteLine("Wrong enter format!");
                Console.WriteLine("To parse equation correctly, put it again.");
                Console.WriteLine("Example of right input: 0.0x^2+1.0x-5.67");
                return uncheckedCoefficients;
            }
            else
            {
                return uncheckedCoefficients;
            }
        }

        public static double[] check_coefficients(List<String> uncheckedCoefficients)
        {
            double number;
            bool check_a_enter_format = double.TryParse(uncheckedCoefficients[0],
                NumberStyles.Any,
                new CultureInfo("en-US"),
                out number);
            bool check_b_enter_format = double.TryParse(uncheckedCoefficients[1],
                NumberStyles.Any,
                new CultureInfo("en-US"),
                out number);
            bool check_c_enter_format = double.TryParse(uncheckedCoefficients[2],
                NumberStyles.Any,
                new CultureInfo("en-US"),
                out number);
            if (!(check_a_enter_format) || (!(check_b_enter_format)) || (!(check_c_enter_format)))
            {
                Console.WriteLine("Something is wrong with the coefficient values!");
                double[] emptyArray = new double[0];
                return emptyArray;
            }
            else
            {
                double a = double.Parse(uncheckedCoefficients[0], CultureInfo.InvariantCulture);
                double b = double.Parse(uncheckedCoefficients[1], CultureInfo.InvariantCulture);
                double c = double.Parse(uncheckedCoefficients[2], CultureInfo.InvariantCulture);

                if ((a == 0) && (b == 0) && (c == 0))
                {
                    Console.WriteLine("All the equation coefficients can not be equal to zero!");
                    double[] emptyArray = new double[0];
                    return emptyArray;
                }
                else
                {
                    double[] equationCoefficients = new double[3] {a, b, c};
                    return equationCoefficients;
                }
            }
        }

        public static int solution_type_chooser(double[] equationCoefficients)
        {
            double a = equationCoefficients[0];
            double b = equationCoefficients[1];
            double c = equationCoefficients[2];
            if ((a == 0) && (b == 0) && (c != 0))
            {
                return 1;
            }
            else if (a == 0)
            {
                return 2;
            }
            else if ((b == 0) && (-c / a > 0))
            {
                return 3;
            }
            else
            {
                return 4;
            }
        }

        public static double calculate_discriminant(double a, double b, double c)
        {
            double discriminant = Math.Pow(b, 2) - 4 * a * c;
            return discriminant;
        }

        public static List<string> solve_quadratic_equation(int solutionType, double[] equationCoefficients)
        {
            double a = equationCoefficients[0];
            double b = equationCoefficients[1];
            double c = equationCoefficients[2];
            var equationRoots = new List<string>();
            switch (solutionType)
            {
                case 1:
                    equationRoots.Add("No solutions ever");
                    break;
                case 2:
                    equationRoots.Add((-c / b).ToString(CultureInfo.InvariantCulture));
                    break;
                case 3:
                    double x1 = Math.Sqrt(-c / a);
                    double x2 = -Math.Sqrt(-c / a);
                    equationRoots.Add(x1.ToString(CultureInfo.InvariantCulture));
                    equationRoots.Add(x2.ToString(CultureInfo.InvariantCulture));
                    break;
                case 4:
                    double discriminant = calculate_discriminant(a, b, c);
                    if (discriminant > 0)
                    {
                        x1 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                        x2 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                        equationRoots.Add(x1.ToString(CultureInfo.InvariantCulture));
                        equationRoots.Add(x2.ToString(CultureInfo.InvariantCulture));
                    }

                    else if (discriminant == 0)
                    {
                        equationRoots.Add((-b / (2 * a)).ToString(CultureInfo.InvariantCulture));
                    }
                    else
                    {
                        {
                            equationRoots.Add("No real solutions");
                        }
                    }

                    break;
            }

            return equationRoots;
        }

        public static void print_equation_solution(List<string> equationRoots)
        {
            double number;
            if ((equationRoots[0].Equals("No solutions ever")) || (equationRoots[0].Equals("No real solutions")))
            {
                Console.WriteLine(equationRoots[0]);
            }

            else if ((equationRoots.Count == 1) && (double.TryParse(equationRoots[0],
                NumberStyles.Any,
                new CultureInfo("en-US"),
                out number)))
            {
                Console.WriteLine("The equation has one real root:");
                Console.WriteLine("x = " + equationRoots[0]);
            }

            else
            {
                Console.WriteLine("The equation has two real roots:");
                Console.WriteLine("x1 = " + equationRoots[0]);
                Console.WriteLine("x2 = " + equationRoots[1]);
            }
        }

        public static void Main(string[] args)
        {
            String myEquation = read_equation();
            List<String> parsedCoefficients = get_coefficients(myEquation);
            double[] parseChecker = check_coefficients(parsedCoefficients);
            if (!(parseChecker == null || parseChecker.Length == 0))
            {
                int equationType = solution_type_chooser(parseChecker);
                List<string> equationRoots = (solve_quadratic_equation(equationType, parseChecker));
                print_equation_solution(equationRoots);
            }
        }
    }
}
