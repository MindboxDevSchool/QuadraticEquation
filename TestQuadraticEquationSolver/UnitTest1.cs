using NUnit.Framework;
using QuadraticEquationSolver;

namespace TestQuadraticEquationSolver
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            //Arrange
            string inputString = "-x + x^2 - 9 +2x-15 + 9x= 0";
            
            //Act
            QuadraticEquation testEquation = new QuadraticEquation(inputString);
            double[] roots = testEquation.Roots;
            
            //Accert
            Assert.AreEqual(2, roots[0], 0.001);
            Assert.AreEqual(-12, roots[1], 0.001);
        }
    }
}