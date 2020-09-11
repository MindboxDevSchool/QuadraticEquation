using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace QuadraticEquation.Tests
{
    public class ParseAsIndecesTests
    {
        [Test]
        public void ValidCoefficients_3DistinctCoefficients()
        {
            string equation = "3.14 6.0 -10.0";
            double[] coefficients = 
                new double[] {3.14, 6, -10};
            var quadratic = new Quadratic();

            double[] result = quadratic.ParseAsIndices(equation);

            Assert.AreEqual(coefficients, result);
        }

        [Test]
        public void NotEnoughCoefficients_RaisesException()
        {
            string coefficients = "0.0 0.1";
            var quadratic = new Quadratic();
            
            Assert.Throws<ArgumentException>((() => quadratic.ParseAsIndices(coefficients)));
        }

        [Test]
        public void InvalidCoefficients_RaisesException()
        {
            string coefficients = "0.0 0.1 rbrtb";
            var quadratic = new Quadratic();
            
            Assert.Throws<InvalidCastException>((() => quadratic.ParseAsIndices(coefficients)));
        }
    }
}