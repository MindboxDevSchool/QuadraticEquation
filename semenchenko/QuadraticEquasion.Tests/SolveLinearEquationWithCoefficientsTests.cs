using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace QuadraticEquation.Tests
{
    public class SolveLinearEquationWithCoefficientsTests
    {
        [Test]
        public void ValidCoefficients_ReturnValidResult()
        {
            double[] coefficients = new double[] {2, 3, 1};
            var quadratic = new Quadratic();

            double[] solutions = quadratic.SolveLinearEquationWithCoefficients(coefficients);

            Assert.AreEqual(new [] {-1.0/3.0}, solutions);
        }

        [Test]
        public void ZeroInLinearCoefficient_RaisesArgumentException()
        {
            double[] coefficients = new double[] {2, 0, 1};
            var quadratic = new Quadratic();
            
            Assert.Throws<DivideByZeroException>((() => 
                quadratic.SolveLinearEquationWithCoefficients(coefficients)));
        }

        [Test]
        public void NoCoefficient_RaisesNotFoundException()
        {
            double[] coefficients = new double[] {};
            var quadratic = new Quadratic();
            
            Assert.Throws<KeyNotFoundException>((() => 
                quadratic.SolveLinearEquationWithCoefficients(coefficients)));
        }
    }
}