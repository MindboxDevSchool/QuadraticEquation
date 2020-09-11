using System.Collections.Generic;
using NUnit.Framework;

namespace TestQuadraticEquation
{
    public class QuadraticEquationTests
    {
        [Test]
        public void Test_CalculateDiscriminant()
        {
            // arrange 
            double a = 1;
            double b = 3;
            double c = 1;
            QuadraticEquation.QuadraticEquation quadraticEquation = new QuadraticEquation.QuadraticEquation(a, b, c);

            // act
            var discriminant = quadraticEquation.CalculateDiscriminant();

            // assert
            Assert.AreEqual(discriminant, 5.0);
        }

        [Test]
        public void Test_Solve_NoRoots()
        {
            // arrange 
            double a = 1;
            double b = 1;
            double c = 1;
            QuadraticEquation.QuadraticEquation quadraticEquation = new QuadraticEquation.QuadraticEquation(a, b, c);

            // act
            var roots = quadraticEquation.Solve();

            // assert
            Assert.AreEqual(roots.Count, 0);
        }

        [Test]
        public void Test_Solve_OneRoot()
        {
            // arrange 
            double a = 1;
            double b = 2;
            double c = 1;
            QuadraticEquation.QuadraticEquation quadraticEquation = new QuadraticEquation.QuadraticEquation(a, b, c);

            // act
            var roots = quadraticEquation.Solve();

            // assert
            Assert.AreEqual(roots.Count, 1);
            Assert.AreEqual(roots[0], -1);
        }

        [Test]
        public void Test_Solve_TwoRoots()
        {
            // arrange 
            double a = 1;
            double b = 5;
            double c = 4;
            QuadraticEquation.QuadraticEquation quadraticEquation = new QuadraticEquation.QuadraticEquation(a, b, c);

            // act
            var roots = quadraticEquation.Solve();
            roots.Sort();

            // assert
            Assert.AreEqual(roots.Count, 2);
            Assert.AreEqual(roots, new List<double> {-4, -1});
        }

        [Test]
        public void Test_IsValid_CorrectEquation()
        {
            // arrange 
            double a = 1;
            double b = 3;
            double c = 1;
            QuadraticEquation.QuadraticEquation quadraticEquation = new QuadraticEquation.QuadraticEquation(a, b, c);

            // act
            var isValid = quadraticEquation.IsValid();

            // assert
            Assert.True(isValid);
        }

        [Test]
        public void Test_IsValid_IncorrectEquation()
        {
            // arrange 
            double a = 0;
            double b = 3;
            double c = 1;
            QuadraticEquation.QuadraticEquation quadraticEquation = new QuadraticEquation.QuadraticEquation(a, b, c);

            // act
            var isValid = quadraticEquation.IsValid();

            // assert
            Assert.False(isValid);
        }
    }
}