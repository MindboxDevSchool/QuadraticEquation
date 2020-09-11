using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace QuadraticEquation.Tests
{
    public class CalculateSolutionsTests
    {
        [Test]
        public void ReturnsMultipleSolutions()
        {
            double[] coefficients = new double[] {2, 3, 1};
            float D = 1;
            var quadratic = new Quadratic();

            double[] solutions = quadratic.CalculateSolutions(coefficients, D);

            Assert.AreEqual(new[] {-0.5, -1}, solutions);
        }

        [Test]
        public void ReturnSingleSolution()
        {
            double[] coefficients = new double[] {1, 0, 0};
            float D = 0;
            var quadratic = new Quadratic(); 

            double[] solutions = quadratic.CalculateSolutions(coefficients, D);

            var doubles = new double[] {0};
            Assert.AreEqual(doubles, solutions);
        }
        
        [Test]
        public void InvalidInput_RaisesException()
        {
            double[] coefficients = new double[] {2, 3};
            float D = 0;
            var quadratic = new Quadratic();
            
            Assert.Throws<KeyNotFoundException>((() => quadratic.CalculateSolutions(coefficients, D)));
        }
        
        [Test]
        public void ZeroInQuadraticCoefficient_RaisesArgumentException()
        {
            double[] coefficients = new double[] {0, 0, 1};
            float D = 0;
            var quadratic = new Quadratic();
            
            Assert.Throws<DivideByZeroException>((() => quadratic.CalculateSolutions(coefficients, D)));
        }
    }
}