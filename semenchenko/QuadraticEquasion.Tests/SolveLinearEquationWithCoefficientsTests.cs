using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace ConsoleApp1.Tests
{
    public class SolveLinearEquationWithCoefficientsTests
    {
        [Test]
        public void ValidCoefficients_ReturnValidResult()
        {
            Dictionary<string, double> coeffitients = new Dictionary<string, double> {{"a", 2}, {"b", 3}, {"c", 1}};
            var quadatic = new Quadatic();

            double[] solutions = quadatic.SolveLinearEquationWithCoefficients(coeffitients);

            Assert.AreEqual(solutions, new [] {-1.0/3.0});
        }

        [Test]
        public void ZeroInLinearCoefficient_RaisesArgumentException()
        {
            Dictionary<string, double> coeffitients = new Dictionary<string, double> {{"a", 2}, {"b", 0}, {"c", 1}};
            var quadatic = new Quadatic();
            
            Assert.Throws<ArgumentException>((() => quadatic.SolveLinearEquationWithCoefficients(coeffitients)));
        }

        [Test]
        public void NoCoefficient_RaisesNotFoundException()
        {
            Dictionary<string, double> coeffitients = new Dictionary<string, double> {};
            var quadatic = new Quadatic();
            
            Assert.Throws<KeyNotFoundException>((() => 
                quadatic.SolveLinearEquationWithCoefficients(coeffitients)));
        }
    }
}