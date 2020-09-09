using System;
using NUnit.Framework;
using QuadraticEquation;

namespace QuadraticEquationTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void ParseCoefficients_ParsesCorrectly()
        {
            // Arrange
            string equation = "13.37x^2 - .2x + 1 = 0";
            double[] expectedCoefficients = {13.37, -.2, 1};

            // Act
            (double a, double b, double c) = Program.ParseCoefficients(equation);

            // Assert
            Assert.AreEqual(expectedCoefficients, new double[] {a, b, c});
        }
        
        [Test]
        public void ParseCoefficients_ThrowsCorrectly()
        {
            // Arrange
            string equation = "This is an equation, believe me!";

            // Act
            TestDelegate parseCoefficients = () => Program.ParseCoefficients(equation);

            // Assert
            Assert.Throws(typeof(FormatException), parseCoefficients);
        }
        
        [Test]
        public void ValidateCoefficients_AcceptsCorrectly()
        {
            // Arrange
            double a = 6, b = 11, c = -35;

            // Act
            bool isValid = Program.ValidateCoefficients(a, b, c);

            // Assert
            Assert.True(isValid);
        }
        
        [Test]
        public void ValidateCoefficients_DeniesCorrectly()
        {
            // Arrange
            double a = 0, b = 0, c = 0;

            // Act
            bool isValid = Program.ValidateCoefficients(a, b, c);

            // Assert
            Assert.False(isValid);
        }

        [Test]
        public void GetDiscriminant_CalculatesCorrectly()
        {
            // Arrange
            double a = 3, b = -14, c = -5;
            double expectedDiscriminant = 256;

            // Act
            double actualDiscriminant = Program.GetDiscriminant(a, b, c);

            // Assert
            Assert.AreEqual(expectedDiscriminant, actualDiscriminant);
        }

        [Test]
        public void GetRootCount_CalculatesCorrectly()
        {
            // Arrange
            double discriminant = 1;
            int expectedRootCount = 2;

            // Act
            int actualRootCount = Program.GetRootCount(discriminant);

            // Assert
            Assert.AreEqual(expectedRootCount, actualRootCount);
        }

        [Test]
        public void GetRoots_OneRoot_CalculatesCorrectly()
        {
            // Arrange
            double a = 4, b = -12;
            double discriminant = 0;
            double[] expectedRoots = {1.5};

            // Act
            double[] actualRoots = Program.GetRoots(a, b, discriminant);

            // Assert
            Assert.AreEqual(expectedRoots, actualRoots);
        }
        
        [Test]
        public void GetRoots_TwoRoots_CalculatesCorrectly()
        {
            // Arrange
            double a = 1, b = -6;
            double discriminant = 8;
            double[] expectedRoots = {3 + Math.Sqrt(2), 3 - Math.Sqrt(2)};

            // Act
            double[] actualRoots = Program.GetRoots(a, b, discriminant);

            // Assert
            Assert.AreEqual(expectedRoots, actualRoots);
        }
        
        [Test]
        public void Solve_CalculatesCorrectly()
        {
            // Arrange
            double a = 1, b = 2, c = -4;
            double[] expectedRoots =
            {
                -1 + Math.Sqrt(5),
                -1 - Math.Sqrt(5)
            };

            // Act
            double[] actualRoots = Program.Solve(a, b, c);

            // Assert
            Assert.AreEqual(expectedRoots, actualRoots);
        }
    }
}
