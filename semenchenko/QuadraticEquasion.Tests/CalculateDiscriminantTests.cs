using System.Collections.Generic;
using NUnit.Framework;

namespace ConsoleApp1.Tests
{
    public class CalculateDiscriminantTests
    {
        [Test]
        public void ValidInput_ReturnsValidResult()
        {
            Dictionary<string, double> coeffitients = new Dictionary<string, double> {{"a", 2}, {"b", 3}, {"c", 1}};
            var quadratic = new Quadatic();

            double d = quadratic.CalculateDiscriminant(coeffitients);
            
            Assert.AreEqual(d, 1.0);
        }

        [Test]
        public void InvalidInput_RaisesException()
        {
            Dictionary<string, double> coeffitients = new Dictionary<string, double> {{"a", 2}, {"b", 3}, {"d", 1}};
            var quadratic = new Quadatic();
            
            Assert.Throws<KeyNotFoundException>((() => quadratic.CalculateDiscriminant(coeffitients)));
        }
    }
}