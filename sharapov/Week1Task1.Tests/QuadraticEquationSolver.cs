using NUnit.Framework;

namespace Week1Task1.Tests {
    public class Tests {
        [Test]
        public void TwoRoots() {
            // arrange
            var (rootX1, rootX2) = (3.0, -1.0);
            // act
            var (x1, x2) = QuadraticEquationSolver.Solve(1.0, -2.0, -3.0);
            // assert
            Assert.AreEqual(rootX1, x1);
            Assert.AreEqual(rootX2, x2);
        }

        [Test]
        //result roots are same x1 == x2
        public void OneRoot() {
            // arrange
            var (rootX1, rootX2) = (-6.0, -6.0);

            // act
            var (x1, x2) = QuadraticEquationSolver.Solve(1.0, 12.0, 36.0);

            // assert
            //result roots are same x1 == x2
            Assert.AreEqual(rootX1, x1);
            Assert.AreEqual(rootX2, x2);
        }

        [Test]
        public void NoRoots() {
            // arrange
            var (rootX1, rootX2) = (double.NaN, double.NaN);

            // act
            var (x1, x2) = QuadraticEquationSolver.Solve(5.0, 2.0, 3.0);

            // assert
            //result roots are same x1 == x2
            Assert.AreEqual(double.IsNaN(rootX1), double.IsNaN(x1));
            Assert.AreEqual(double.IsNaN(rootX2), double.IsNaN(x2));
        }

        [Test]
        public void FirstCoefficientIsZeroSecondIsPositive() {
            // arrange
            var (rootX1, rootX2) = (double.NaN, double.NegativeInfinity);

            // act
            var (x1, x2) = QuadraticEquationSolver.Solve(0.0, 2.0, 3.0);

            // assert
            //result roots are same x1 == x2
            Assert.AreEqual(double.IsNaN(rootX1), double.IsNaN(x1));
            Assert.AreEqual(double.IsNegativeInfinity(rootX2), double.IsNegativeInfinity(x2));
        }
        
        [Test]
        public void FirstCoefficientIsZeroSecondIsNegative() {
            // arrange
            var (rootX1, rootX2) = (double.PositiveInfinity, double.NaN);

            // act
            var (x1, x2) = QuadraticEquationSolver.Solve(0.0, -2.0, 3.0);

            // assert
            //result roots are same x1 == x2
            Assert.AreEqual(double.IsInfinity(rootX1), double.IsInfinity(x1));
            Assert.AreEqual(double.IsNaN(rootX2), double.IsNaN(x2));
        }

        [Test]
        public void AllCoefficientsAreZero() {
            // arrange
            var (rootX1, rootX2) = (double.NaN, double.NaN);

            // act
            var (x1, x2) = QuadraticEquationSolver.Solve(0.0, 0.0, 0.0);

            // assert
            //result roots are same x1 == x2
            Assert.AreEqual(double.IsNaN(rootX1), double.IsNaN(x1));
            Assert.AreEqual(double.IsNaN(rootX2), double.IsNaN(x2));
        }
    }
}