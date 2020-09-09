using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace QuadraticEquation
{
    public class EquationSolver
    {
        private double[] Coefficients { get; set; }

        public EquationSolver()
        {
            
        }

        public EquationSolver(string equation)
        {
            Coefficients = Parse(equation);
        }

        public bool IsEquationQuadratic(string equation)
        {
            Regex regex = new Regex(@"^-?((0|[1-9][0-9]*)(,[1-9][0-9]*)?)?x\^2([+|-]?((0|[1-9][0-9]*)(,[1-9][0-9]*)?)?x)?([+|-]?(0|[1-9][0-9]*)(,[1-9][0-9]*)?)?$");

            return regex.Match(equation).Value == equation;
        }
        
        public double[] Parse(string equation)
        {
            equation = equation.Replace(" ", "").Replace(".", ",");

            if (!IsEquationQuadratic(equation))
            {
                throw new Exception("Некорректный ввод. Уравнение не квадратное.");
            }
            
            Regex regex = new Regex(@"-?((0|[1-9][0-9]*)(,[1-9][0-9]*)?)?(x|$)+");
            
            List<string> matches = new List<string>();

            foreach (Match m in regex.Matches(equation))
            {
                if (m.Value != "") 
                    matches.Add(m.Value.Replace("x", ""));
            }

            double[] coefficients = new double[3];
            
            // первый коэффициент
            string match = (matches[0] == "") ? "1": matches[0];
            coefficients[0] = double.Parse(match);

            // неполное квадратное уравнение
            if (matches.Count < 3)
            {
                if (equation.EndsWith("x^2"))
                {
                    coefficients[1] = 0;
                    coefficients[2] = 0;
                }
                else if (equation.EndsWith("x"))
                {
                    match = (matches[1] == "") ? "1" : matches[1];
                    coefficients[1] = double.Parse(match);
                    coefficients[2] = 0;
                }
                else
                {
                    coefficients[1] = 0;
                    coefficients[2] = double.Parse(matches[1]);
                }
            }
            // полное квадратное уравнение
            else
            {
                for (int i = 1; i < 3; i++)
                {
                    match = (matches[i] == "") ? "1": matches[i];
                    coefficients[i] = double.Parse(match);
                }
            }
            
            return coefficients;
        }

        public double GetDeterminant()
        {
            if (Coefficients != null)
                return GetDeterminant(Coefficients);
            
            throw new Exception("Некорректный ввод. Коэффициенты не заданы.");
        }

        public double GetDeterminant(double[] coefficients)
        {
            if (coefficients.Length == 3)
                return Math.Pow(coefficients[1], 2) - 4 * coefficients[0] * coefficients[2];
            
            throw new Exception($"Некорректный ввод. Неполный набор коэффициентов: {coefficients.Length}.");
        }
        
        public double[] GetRoots()
        {
            double determinant = GetDeterminant();
            return GetRoots(determinant, Coefficients);
        }

        public double[] GetRoots(double determinant, double[] coefficients)
        {
            if (determinant < 0)
            {
                throw new Exception($"Определитель меньше 0: {determinant}. Решений нет.");
            }

            if (coefficients[0] == 0)
            {
                throw new Exception($"Некорректный ввод. Уравнение не квадратное.");
            }
            
            double[] roots = new double[2];
            
            roots[0] = (-coefficients[1] + Math.Sqrt(determinant)) / (2 * coefficients[0]);
            roots[1] = (-coefficients[1] - Math.Sqrt(determinant)) / (2 * coefficients[0]);

            return roots;
        }
    }
}