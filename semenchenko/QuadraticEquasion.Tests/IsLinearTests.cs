using System.Collections.Generic;
using NUnit.Framework;

namespace ConsoleApp1.Tests
{
    public class IsLinearTests
    {
        [Test]
        public void QuadraticEquasionCoeffs_ReturnsFalse()
        {
            Dictionary<string, double> coeffitients = new Dictionary<string, double> {{"a", 2}, {"b", 3}, {"c", 1}};
            var quadatic = new Quadatic();

            bool isLinear = quadatic.IsLinear(coeffitients);

            Assert.AreEqual(isLinear, false);
        }
        
        [Test]
        public void LinearEquasionCoeffs_ReturnsTrue()
        {
            Dictionary<string, double> coeffitients = new Dictionary<string, double> {{"a", 0}, {"b", 3}, {"c", 0}};
            var quadatic = new Quadatic();

            bool isLinear = quadatic.IsLinear(coeffitients);

            Assert.AreEqual(isLinear, true);
        }
        
        [Test]
        public void InvalidInput_RaisesException()
        {
            Dictionary<string, double> coeffitients = new Dictionary<string, double>();
            var quadratic = new Quadatic();
            
            Assert.Throws<KeyNotFoundException>((() => quadratic.IsLinear(coeffitients)));
        }
    }
}