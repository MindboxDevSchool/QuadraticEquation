using NUnit.Framework;
using QuadraticEquations;

namespace QuadraticEquationsTests
{
    public class ValidateDiscrTests
    {
        [Test]
        public void NegativeDiscr()
        {
            //coefs: 1, -5, 4
            double d = -11;
            var expected = Program.DiscriminantValue.Negative;

            var actual = Program.ValidateDiscr(d);
            
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void PositiveDiscr()
        {
            //coefs: 1, -5, 4
            double d = 15;
            var expected = Program.DiscriminantValue.Positive;

            var actual = Program.ValidateDiscr(d);
            
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void ZeroDiscr()
        {
            //coefs: 1, -5, 4
            double d = 0;
            var expected = Program.DiscriminantValue.Zero;

            var actual = Program.ValidateDiscr(d);
            
            Assert.AreEqual(expected, actual);
        }
    }
}