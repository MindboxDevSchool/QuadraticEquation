using MindboxDetApp;
using NUnit.Framework;

namespace MindboxDet.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DeterminatorTest()
        {
            // arrange
            double expected = 0;
            // act
            double result = QuadraticEquation.Determinator(4, -4, 1);
            // assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SolutionTest()
        {
            // arrage
            double[] expected = {8};
            // act
            var result = QuadraticEquation.Solution(0, 4, -4);
            // assert
            Assert.AreEqual(expected, result);
        }
    }
}