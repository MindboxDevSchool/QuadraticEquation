using System;
using NUnit.Framework;


namespace QuadraticEquation.Tests
{
    public class Tests
    {
        [Test]
        public void CorrectInput_returns_CorrectResults()
        {
            //arrange
            QuadraticEquationSolver.QuadraticEquation equation =
                new QuadraticEquationSolver.QuadraticEquation(1, 1, -6);

            //run
            equation.Solve();
            //assert
            Assert.AreEqual(2, equation.X1);
            Assert.AreEqual(-3, equation.X2);
        }

        [Test]
        public void SecondCoefZero_returns_CorrectResults()
        {
            //arrange
            QuadraticEquationSolver.QuadraticEquation equation =
                new QuadraticEquationSolver.QuadraticEquation(1, 0, -4);

            //run
            equation.Solve();
            //assert
            Assert.AreEqual(2, equation.X1);
            Assert.AreEqual(-2, equation.X2);
        }

        [Test]
        public void TrirdCoefZero_returns_CorrectResults()
        {
            //arrange
            QuadraticEquationSolver.QuadraticEquation equation =
                new QuadraticEquationSolver.QuadraticEquation(1, -4, 0);

            //run
            equation.Solve();
            //assert
            Assert.AreEqual(4, equation.X1);
            Assert.AreEqual(0, equation.X2);
        }

        [Test]
        public void FirstCoefNotEqualOne_returns_CorrectResults()
        {
            //arrange
            QuadraticEquationSolver.QuadraticEquation equation =
                new QuadraticEquationSolver.QuadraticEquation(5, -5, -10);

            //run
            equation.Solve();
            //assert
            Assert.AreEqual(2, equation.X1);
            Assert.AreEqual(-1, equation.X2);
        }

        [Test]
        public void FirstCoefNegative_returns_CorrectResults()
        {
            //arrange
            QuadraticEquationSolver.QuadraticEquation equation =
                new QuadraticEquationSolver.QuadraticEquation(-5, -5, +10);

            //run
            equation.Solve();
            //assert
            Assert.AreEqual(-2, equation.X1);
            Assert.AreEqual(1, equation.X2);
        }

        [Test]
        public void InputZeroes_GetException()
        {
            Assert.Throws<ArgumentException>(() => new QuadraticEquationSolver.QuadraticEquation(0, 0, 0));
        }

        [Test]
        public void InputFirstCoefZero_GetException()
        {
            Assert.Throws<ArgumentException>(() => new QuadraticEquationSolver.QuadraticEquation(0, 6, 6));
        }
    }
}