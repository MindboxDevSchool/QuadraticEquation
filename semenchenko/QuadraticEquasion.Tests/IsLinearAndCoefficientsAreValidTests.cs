using System.Collections.Generic;
using NUnit.Framework;

namespace QuadraticEquation.Tests
{
    public class IsLinearAndCoefficientsAreValidTests
    {
        [Test]
        public void QuadraticEquationCoeffs_ReturnsFalse()
        {
            double[] coefficients = new double[] {2, 3, 1};
            var quadratic = new Quadratic();

            bool isLinear = quadratic.IsLinearAndCoefficientsAreValid(coefficients);

            Assert.IsFalse(isLinear);
        }

        [Test]
        public void LinearEquationValidCoeffs_ReturnsTrue()
        {
            double[] coefficients = new double[] {0, 3, 0};
            var quadratic = new Quadratic();

            bool isLinear = quadratic.IsLinearAndCoefficientsAreValid(coefficients);

            Assert.IsTrue(isLinear);
        }
        
        [Test]
        public void LinearEquationInvalidCoeffs_ReturnsFalse()
        {
            double[] coefficients = new double[] {0, 0, -10};
            var quadratic = new Quadratic();

            bool isLinear = quadratic.IsLinearAndCoefficientsAreValid(coefficients);

            Assert.IsFalse(isLinear);
        }

        [Test]
        public void InvalidInput_RaisesException()
        {
            double[] coefficients = new double[]{};
            var quadratic = new Quadratic();

            Assert.Throws<KeyNotFoundException>((() => quadratic.IsLinearAndCoefficientsAreValid(coefficients)));
        }
    }
}