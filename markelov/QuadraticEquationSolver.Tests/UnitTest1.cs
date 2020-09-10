using System.Collections.Generic;
using NUnit.Framework;

namespace QuadraticEquationSolver.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void GetDiscriminant_GoodCoefficients_Success()
        {
            double[] coefs = new[] {1.0, 3, -4};
            double discriminant = Program.GetDiscriminant(coefs);
            Assert.AreEqual(25, discriminant);
        }
        [Test]
        public void GetDiscriminant_DiscriminantIsZero()
        {
            double[] coefs = new[] {1.0, 12, 36};
            double discriminant = Program.GetDiscriminant(coefs);
            Assert.AreEqual(0, discriminant);
        }
        [Test]
        public void GetDiscriminant_DiscriminantIsLessThanZero()
        {
            double[] coefs = new[] {5.0, 3, 7};
            double discriminant = Program.GetDiscriminant(coefs);
            Assert.AreEqual(-131, discriminant);
        }
        [Test]
        public void GetRoots_DiscriminantIsZero_OneRoot()
        {
            double a = 1;
            double b = 12;
            double discriminant = 0;
            List<double> roots = Program.GetRoots(discriminant, a, b);
            Assert.AreEqual(1, roots.Count);
            Assert.AreEqual(-6, roots[0]);
        }
        [Test]
        public void GetRoots_DiscriminantIsBiggerThanZero_TwoRoots()
        {
            double a = 1;
            double b = -2;
            double discriminant = 16;
            List<double> roots = Program.GetRoots(discriminant, a, b);
            Assert.AreEqual(2, roots.Count);
            Assert.AreEqual(3, roots[0]);
            Assert.AreEqual(-1, roots[1]);
        }
        [Test]
        public void GetRoots_DiscriminantIsLessThanZero_ZeroRoots()
        {
            double a = 5;
            double b = 3;
            double discriminant = -131;
            List<double> roots = Program.GetRoots(discriminant, a, b);
            Assert.AreEqual(0, roots.Count);
        }
    }
}