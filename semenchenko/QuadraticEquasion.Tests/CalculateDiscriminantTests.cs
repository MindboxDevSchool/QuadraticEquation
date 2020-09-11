using System.Collections.Generic;
using NUnit.Framework;

namespace QuadraticEquation.Tests
{
    public class CalculateDiscriminantTests
    {
        [Test]
        public void ValidInput_ReturnsValidResult()
        {
            double[] coeffitients = new double[] {2, 3, 1};
            var quadratic = new Quadratic();

            double d = quadratic.CalculateDiscriminant(coeffitients);
            
            Assert.AreEqual(d, 1.0);
        }

        [Test]
        public void InvalidInput_RaisesException()
        {
            double[] coeffitients = new double[] {2, 3};
            var quadratic = new Quadratic();
            
            Assert.Throws<KeyNotFoundException>((() => quadratic.CalculateDiscriminant(coeffitients)));
        }
    }
}