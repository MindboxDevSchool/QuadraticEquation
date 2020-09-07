using NUnit.Framework;
using QuadraticEquation;

namespace UnitTests
{
    public class Tests
    {
        [Test]
        public void SuitableInputString_GetCoefficients_StringCoefficients()
        {
            //arrange
            var inputString = "1*x2+4*x-5";
            //act
            var rawCoeffs = QuadraticEquationSolver.GetCoefficients(inputString);
            //assert
            Assert.AreEqual(new string[] {"1", "+4", "-5"}, rawCoeffs);
        }
        
        [Test]
        public void UnsuitableInputString_GetCoefficients_StringCoefficients()
        {
            //arrange
            var inputString = "Mindbox";
            //act
            var rawCoeffs = QuadraticEquationSolver.GetCoefficients(inputString);
            //assert
            Assert.AreEqual(new string[] {"0.0", "0.0", "0.0"}, rawCoeffs);
        }
        
        //[Test]
        public void StringCoefficients_CheckCoefficients_DoubleCoefficients()
        {
            //arrange
            string[] rawCoeffs = {"1", "+4", "-5"};
            //act
            QuadraticEquationSolver.CheckCoefficients(rawCoeffs);
            //assert
            //Assert.;
        }
        
        [Test]
        public void DoubleCoefficients_FindDeterminator_TrueDeterminator()
        {
            //arrange
            double[] coeffs = {1.0, -10.0, 21};
            //act
            var determinator = QuadraticEquationSolver.FindDeterminator(coeffs);
            //assert
            Assert.AreEqual(16.0, determinator);
        }
        
        [Test]
        public void DoubleCoefficientsAndZeroDeterminator_FindRootsWhenDeterminatorIsZero_TrueRoot()
        {
            //arrange
            double[] coeffs = {2.0, 4.0, 2.0};
            var determinator = 0;
            //act
            var root = QuadraticEquationSolver.FindRootsWhenDeterminatorIsZero(determinator, coeffs);
            //assert
            Assert.AreEqual(root, -1.0);
        }
        
        [Test]
        public void DoubleCoefficientsAndPositiveDeterminator_FindRootsWhenDeterminatorIsPositive_TrueRoots()
        {
            //arrange
            double[] coeffs = {1.0, -10.0, 21};
            var determinator = 16.0;
            //act
            var roots = QuadraticEquationSolver.FindRootsWhenDeterminatorIsPositive(determinator, coeffs);
            //assert
            Assert.AreEqual(roots, new double[] {7.0, 3.0});
        }
    }
}