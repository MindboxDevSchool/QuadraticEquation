using System;
using System.Collections.Generic;
using NUnit.Framework;
using Stepenko_Quadratic_Equation_Solver;
namespace QuadraticEquationSolverTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void getCoefficientsTest()
        {
            String equation = "5.0*x^2 + 6.0*x + 1.0";
            var uncheckedCoefficients = new List<string>();
            uncheckedCoefficients.Add("5.0");
            uncheckedCoefficients.Add("6.0");
            uncheckedCoefficients.Add("1.0");

            Assert.AreEqual(uncheckedCoefficients[0], 
                Stepenko_Quadratic_Equation_Solver.Program.get_coefficients(equation)[0]);
        }
        
        [Test]
        public void checkCoefficientsTest()
        {
            String equation = "5.0*x^2 + 6.0*x + 1.0";
            var uncheckedCoefficients = new List<string>();
            uncheckedCoefficients.Add("5.0");
            uncheckedCoefficients.Add("6.0");
            uncheckedCoefficients.Add("1.0");

            double[] ar = new double[] {5.0, 6.0, 1.0};

            Assert.AreEqual(ar, 
                Stepenko_Quadratic_Equation_Solver.Program.check_coefficients(uncheckedCoefficients));
        }
        
        [Test]
        public void solutionTypeChooserTest()
        {
            double[] equation_coefficients = new double[] {5.0, 6.0, 1.0};

            Assert.AreEqual(4, 
                Stepenko_Quadratic_Equation_Solver.Program.solution_type_chooser(equation_coefficients));
        }
        
        [Test]
        public void calculateDiscriminantTest()
        {
            double a = 5.0;
            double b = 6.0;
            double c = 1.0;

            Assert.AreEqual(16, 
                Stepenko_Quadratic_Equation_Solver.Program.calculate_discriminant(a, b, c));
        }
        
        [Test]
        public void rootsFinderTest()
        {
            
            double[] equation_coefficients = new double[] {5.0, 6.0, 1.0};
            int solutionType = 4;
            var roots = new List<String>();
            roots.Add("-1");
            roots.Add("-0.2");
            
            Assert.AreEqual(roots, 
                Stepenko_Quadratic_Equation_Solver.Program.solve_quadratic_equation(solutionType,
                    equation_coefficients));
        }
    }
}