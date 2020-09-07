using System;
using NUnit.Framework;

namespace quadraticEquations.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        
        [Test]
        public void Test_Parse_ValidCoefficents()
        {
            // arrange
            string input = "-1x^2-2x+1=0";
            // act
            var result = Program.Parse(input);
            // assert
            Assert.AreEqual(-1, result[0]);
            Assert.AreEqual(-2, result[1]);
            Assert.AreEqual(1, result[2]);
        }

        [Test]
        public void CalculateDiscriminant_ValidCoefficents()
        {
            // arrange
            var coefficents = new Double[3] {1, -2, 1};
            // act
            var result = Program.CalculateDiscriminant(coefficents);
            // assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void CheckDeterminator_LessThanZero()
        {
            // arrange
            double determinator = -4;
            // act
            var result = Program.CheckDeterminator(determinator);
            // assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void CheckDeterminator_MoreThanZero()
        {
            // arrange
            double determinator = 16;
            // act
            var result = Program.CheckDeterminator(determinator);
            // assert
            Assert.AreEqual(true, result);
        }
        
        [Test]
        public void FindRoots_ValidCoefficents()
        {
            // arrange
            double determinator = 0;
            double a = 1;
            double b = -2;
            // act
            var result = Program.FindRoots(determinator, a, b);
            // assert
            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(1, result[1]);
        }
    }
}