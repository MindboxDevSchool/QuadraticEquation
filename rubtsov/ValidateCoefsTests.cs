using NUnit.Framework;
using QuadraticEquations;

namespace QuadraticEquationsTests
{
    public class ValidateCoefsTests
    {
        [Test]
        public void ZeroCoefs_IfiniteNumOfRoots_0_0_0()
        {
            double a = 0;
            double b = 0;
            double c = 0;
            var expected = Program.CoefValidation.InfiniteNumberOfRoots;
            
            var actual = Program.ValidateCoefs(a, b, c);
            
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void NotQuadraticEquation_0_1_5()
        {
            double a = 0;
            double b = 1;
            double c = 5;
            var expected = Program.CoefValidation.NotQuadratic;
            
            var actual = Program.ValidateCoefs(a, b, c);
            
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void NoRoots_0_0_5()
        {
            double a = 0;
            double b = 0;
            double c = 5;
            var expected = Program.CoefValidation.NoRoots;
            
            var actual = Program.ValidateCoefs(a, b, c);
            
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void MayHaveOneOrTwoRoots_1_neg4_4()
        {
            double a = 1;
            double b = -4;
            double c = 4;
            var expected = Program.CoefValidation.MayHaveOneOrTwoRoots;
            
            var actual = Program.ValidateCoefs(a, b, c);
            
            Assert.AreEqual(expected, actual);
        }
        
    }
}