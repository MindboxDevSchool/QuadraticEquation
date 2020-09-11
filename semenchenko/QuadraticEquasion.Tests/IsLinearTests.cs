using System.Collections.Generic;
using NUnit.Framework;

namespace QuadraticEquation.Tests
{
    public class IsLinearTests
    {
        [Test]
        public void QuadraticEquasionCoeffs_ReturnsFalse()
        {
            double[] coefficients = new double[] {2, 3, 1};
            var quadratic = new Quadratic();

            bool isLinear = quadratic.IsLinear(coefficients);

            Assert.IsFalse(isLinear);
        }
        
        [Test]
        public void LinearEquasionCoeffs_ReturnsTrue()
        {
            double[] coefficients = new double[] {0, 3, 0};
            var quadratic = new Quadratic();

            bool isLinear = quadratic.IsLinear(coefficients);

            Assert.IsTrue(isLinear);
        }
        
        [Test]
        public void InvalidInput_RaisesException()
        {
            double[] coefficients = new double[]{};
            var quadratic = new Quadratic();
            
            Assert.Throws<KeyNotFoundException>((() => quadratic.IsLinear(coefficients)));
        }
    }
}