using NUnit.Framework;
using QuadraticEquations;

namespace QuadraticEquationsTests
{
    public class GetDiscriminantTests
    {
        [Test]
        public void NegativeDiscr_neg3()
        {
            double a = 1;
            double b = 1;
            double c = 1;
            double expected = -3;
            
            var actual = Program.GetDiscriminant(a, b, c);
            
            Assert.AreEqual(expected, actual, 0.001);
        }
        
        [Test]
        public void ZeroDiscr()
        {
            double a = 1;
            double b = -4;
            double c = 4;
            double expected = 0;
            
            var actual = Program.GetDiscriminant(a, b, c);
            
            Assert.AreEqual(expected, actual, 0.001);
        }
        
        [Test]
        public void PositiveDiscr_9()
        {
            double a = 1;
            double b = -5;
            double c = 4;
            double expected = 9;
            
            var actual = Program.GetDiscriminant(a, b, c);
            
            Assert.AreEqual(expected, actual, 0.001);
        }
    }
}