using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace ConsoleApp1.Tests
{
    public class ParseAsIndecesTests
    {
        [Test]
        public void ValidCoefficients_3DistinctCoefficients()
        {
            string equation = "3.14 6.0 -10.0";
            Dictionary<string, double> coefficients = 
                new Dictionary<string, double> {{"a", 3.14}, {"b", 6}, {"c", -10}};
            var quadratic = new Quadatic();

            Dictionary<string, double> result = quadratic.ParseAsIndices(equation);

            Assert.AreEqual(coefficients, result);
        }

        [Test]
        public void NotEnoughCoefficients_RaisesException()
        {
            string coefficients = "0.0 0.1";
            var quadratic = new Quadatic();
            
            Assert.Throws<ArgumentException>((() => quadratic.ParseAsIndices(coefficients)));
        }

        [Test]
        public void InvalidCoefficients_RaisesException()
        {
            string coefficients = "0.0 0.1 rbrtb";
            var quadratic = new Quadatic();
            
            Assert.Throws<InvalidCastException>((() => quadratic.ParseAsIndices(coefficients)));
        }
    }
}