using NUnit.Framework;
using QuadraticEquations;

namespace QuadraticEquationsTests
{
    public class FindRootTests
    {
        [Test]
        public void TwoRoots_4_1()
        {
            //coefs: 1, -5, 4
            double a = 1;
            double b = -5;
            double discriminant = 9;
            var expected = new double[]{4, 1};

            var actual = Program.FindRoots(Program.DiscriminantValue.Positive, discriminant, a, b);
            
            Assert.AreEqual(expected[0], actual[0], 0.001);
            Assert.AreEqual(expected[1], actual[1], 0.001);
        }
        
        [Test]
        public void OneRoot_2()
        {
            //coefs 1, -4, 4
            double a = 1;
            double b = -4;
            double discriminant = 0;
            double expected = 2;

            var actual = Program.FindRoots(Program.DiscriminantValue.Zero, discriminant, a, b);
            
            Assert.AreEqual(expected, actual[0], 0.001);
        }
    }
}