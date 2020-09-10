using NUnit.Framework;

namespace SolveQuadraticEquation.Tests
{
    public class SolveQuadraticEquationTests
    {
        [Test]
        public void ParseEquationGoodTest()
        {
            // Arrange
            var equation = "+123.45x^2+432.4x-2.34234";
            // Act
            var parsedCoefficients = Program.ParseEquation(equation);
            // Assert
            Assert.AreEqual(123.45, parsedCoefficients[0], 0.0001);
            Assert.AreEqual(432.4, parsedCoefficients[1], 0.0001);
            Assert.AreEqual(-2.34234, parsedCoefficients[2], 0.0001);
        }
        
        [Test]
        public void ParseEquationGoodTest2()
        {
            // Arrange
            var equation = "0x^2+0x-0";
            // Act
            var parsedCoefficients = Program.ParseEquation(equation);
            // Assert
            Assert.AreEqual(0, parsedCoefficients[0]);
            Assert.AreEqual(0, parsedCoefficients[1]);
            Assert.AreEqual(0, parsedCoefficients[2]);
        }
        
        [Test]
        public void EqualDiscriminantTest()
        {
            // Arrange
            var coefficients = new double[] {1, 2, 1};
            // Act
            var discriminant = Program.EqualDiscriminant(coefficients);
            // Assert
            Assert.AreEqual(0, discriminant);
        }

        [Test]
        public void EqualRoots1RootTest()
        {
            // Arrange
            var coefficients = new double[] {1, 2, 1};
            const int discriminant = 0;
            var rootsAssert = new double[] {-1};
            // Act
            var roots = Program.EqualRoots(coefficients, discriminant);
            // Assert
            Assert.AreEqual(rootsAssert, roots);
        }
        
        [Test]
        public void EqualRoots2RootTest()
        {
            // Arrange
            var coefficients = new double[] {1, -3, 4};
            const int discriminant = 25;
            var rootsAssert = new double[] {-1, 4};
            // Act
            var roots = Program.EqualRoots(coefficients, discriminant);
            // Assert
            Assert.AreEqual(rootsAssert, roots);
        }
        
        [Test]
        public void EqualRoots0RootTest()
        {
            // Arrange
            var coefficients = new double[] {1, 1, 1};
            const int discriminant = -3;
            var rootsAssert = new double[] {};
            // Act
            var roots = Program.EqualRoots(coefficients, discriminant);
            // Assert
            Assert.AreEqual(rootsAssert, roots);
        }
        
        [Test]
        public void EqualRootsUnlimitedRootTest()
        {
            // Arrange
            var coefficients = new double[] {0, 0, 0};
            const int discriminant = 0;
            var rootsAssert = new double[3];
            // Act
            var roots = Program.EqualRoots(coefficients, discriminant);
            // Assert
            Assert.AreEqual(rootsAssert, roots);
        }
        
        [Test]
        public void EqualRootsNoRootLinearTest()
        {
            // Arrange
            var coefficients = new double[] {0, 0, 4};
            const int discriminant = 0;
            var rootsAssert = new double[0];
            // Act
            var roots = Program.EqualRoots(coefficients, discriminant);
            // Assert
            Assert.AreEqual(rootsAssert, roots);
        }
        
        [Test]
        public void EqualRoots1RootLinearTest()
        {
            // Arrange
            var coefficients = new double[] {0, 2, -4};
            const int discriminant = 2;
            var rootsAssert = new double[] {2};
            // Act
            var roots = Program.EqualRoots(coefficients, discriminant);
            // Assert
            Assert.AreEqual(rootsAssert, roots);
        }
    }
}