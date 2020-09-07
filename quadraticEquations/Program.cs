using System;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace quadraticEquations
{
    public class Program
    {
        static void Main(string[] args)
        {
            // var input = GetInput("x^2-2x+1");
            // var coefficents = Parse(input);
            // var a = coefficents[0];
            // var b = coefficents[1];
            // var determinator = CalculateDiscriminant(coefficents);
            // CheckDeterminator(determinator);
            // FindRoots(determinator, a, b);
        }
        
        public static string GetInput(string input)
        {
            throw new NotImplementedException();
        }
        
        public static double[] Parse(string input)
        {
            
            string firstCoeff = "";
            string secondCoeff = "";
            string thirdCoeff = "";

            bool secondCoeffReached = false;
            bool thirdCoeffReached = false;
            
            bool firstCoeffReady = false;
            bool secondCoeffReady = false;
            bool thirdCoeffReady = false;

            void AssembleFirstCoefficent(Char symbol)
            {
                if (Char.IsDigit(symbol))
                    firstCoeff += String.Concat(symbol);
                else
                    firstCoeffReady = true;
            }

            void AssembleSecondCoefficent(Char symbol)
            {
                if (Char.IsDigit(symbol))
                    secondCoeff += String.Concat(symbol);
                else
                    secondCoeffReady = true;
            }

            void AssembleThirdCoefficent(Char symbol)
            {
                if (Char.IsDigit(symbol))
                    thirdCoeff += String.Concat(symbol);
                else
                    thirdCoeffReady = true;
            }

            int i = 0;
            foreach (var symbol in input)
            {
                if (i == 0 && symbol.Equals('-'))
                {
                    i++;
                    firstCoeff += String.Concat('-');
                    continue;
                }
                if (!firstCoeffReady)
                    AssembleFirstCoefficent(symbol);
                if (firstCoeffReady && !secondCoeffReached)
                {
                    if (symbol.Equals('+') || symbol.Equals('-'))
                    {
                        if (symbol.Equals('-'))
                            secondCoeff += String.Concat('-');
                        secondCoeffReached = true;
                    } 
                    continue;
                }
                if (secondCoeffReached && !secondCoeffReady)
                    AssembleSecondCoefficent(symbol);
                if (secondCoeffReady && !thirdCoeffReached)
                {
                    if (symbol.Equals('+') || symbol.Equals('-'))
                    {
                        if (symbol.Equals('-'))
                            thirdCoeff += String.Concat('-');
                        thirdCoeffReached = true;
                    }
                    continue;
                }
                if (thirdCoeffReached && !thirdCoeffReady)
                    AssembleThirdCoefficent(symbol);
            }
            Double[] coefficents = new Double[3];
            coefficents[0] = Convert.ToDouble(firstCoeff);
            coefficents[1] = Convert.ToDouble(secondCoeff);
            coefficents[2] = Convert.ToDouble(thirdCoeff);
            return coefficents;
        }

        public static double CalculateDiscriminant(double[] coefficents)
        {
            var a = coefficents[0];
            var b = coefficents[1];
            var c = coefficents[2];
            return (Math.Pow(b, 2) - (4 * a * c));
        }
        
        public static bool CheckDeterminator(double determinator)
        {
            if (determinator < 0)
                return false;
            return true;
        }
        
        public static double[] FindRoots(double determinator, double a, double b)
        {
            Double[] roots = new Double[2];
            var sqrt = roots[0] = (-b + Math.Sqrt(determinator)) / (2 * a);
            roots[1] = (-b - Math.Sqrt(determinator)) / (2 * a);
            return roots;
        }

        public static void Output(double[] roots)
        {
            Console.WriteLine(roots[0]);
            Console.WriteLine(roots[1]);
        }
        
    }
}