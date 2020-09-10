using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace ConsoleApp1.Tests
{
    public class CalculateSolutionsTests
    {
        [Test]
        public void ReturnsMultipleSolutions()
        {
            Dictionary<string, double> coeffitients = new Dictionary<string, double> {{"a", 2}, {"b", 3}, {"c", 1}};
            float D = 1;
            var quadatic = new Quadatic();

            double[] solutions = quadatic.CalculateSolutions(coeffitients, D);

            Assert.AreEqual(solutions, new double[] {-0.5, -1});
        }

        [Test]
        public void ReturnSingleSolution()
        {
            Dictionary<string, double> coeffitients = new Dictionary<string, double> {{"a", 1}, {"b", 0}, {"c", 0}};
            float D = 0;
            var quadatic = new Quadatic(); 

            double[] solutions = quadatic.CalculateSolutions(coeffitients, D);

            var doubles = new double[] {0};
            Assert.AreEqual(solutions, doubles);
        }
        
        [Test]
        public void InvalidInput_RaisesException()
        {
            Dictionary<string, double> coeffitients = new Dictionary<string, double> {{"a", 2}, {"b", 3}, {"d", 1}};
            float D = 0;
            var quadratic = new Quadatic();
            
            Assert.Throws<KeyNotFoundException>((() => quadratic.CalculateSolutions(coeffitients, D)));
        }
        
        [Test]
        public void ZeroInQuadraticCoefficient_RaisesArgumentException()
        {
            Dictionary<string, double> coeffitients = new Dictionary<string, double> {{"a", 0}, {"b", 0}, {"c", 1}};
            float D = 0;
            var quadatic = new Quadatic();
            
            Assert.Throws<ArgumentException>((() => quadatic.CalculateSolutions(coeffitients, D)));
        }
    }
}