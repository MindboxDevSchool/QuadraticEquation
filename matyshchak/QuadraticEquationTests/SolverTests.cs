using System.Collections.Generic;
using NUnit.Framework;
using QuadraticEquation;

namespace QuadraticEquationTests
{
    public class SolverTests
    {
        [Test]
        public void When_coefficients_are_invalid_throws_custom_exception()
        {    
            var coefficients = (0.0, 0.0, 1.0);
            
            Assert.That(() => Solver.FindRoots(coefficients), Throws.TypeOf<InvalidCoefficientsException>());
        }
        
        [Test]
        public void When_first_coefficient_equals_zero_returns_expected_roots()
        {    
            var coefficients = (0.0, 1.0, 1.0);
            var expectedRoots = new List<double>{-1.0};
            
            var actualRoots = Solver.FindRoots(coefficients);
            
            Assert.That(actualRoots, Is.EqualTo(expectedRoots));
        }
        
        [Test]
        public void When_discriminant_is_positive_returns_list_with_two_expected_roots()
        {
            var coefficients = (1.0, -3.0, -4.0);
            var expectedRoots = new List<double> {-1.0, 4.0};

            var actualRoots = Solver.FindRoots(coefficients);

            Assert.That(actualRoots, Is.EqualTo(expectedRoots));
        }

        [Test]
        public void When_discriminant_is_negative_returns_empty_list()
        {
            var coefficients = (5.0, -2.0, 3.0);

            var actualRoots = Solver.FindRoots(coefficients);

            Assert.That(actualRoots, Is.Empty);
        }

        [Test]
        public void When_discriminant_equals_zero_returns_list_with_one_expected_root()
        {
            var coefficients = (1.0, -6.0, 9.0);
            var expectedRoots = new List<double> {3.0};

            var actualRoots = Solver.FindRoots(coefficients);

            Assert.That(actualRoots, Is.EqualTo(expectedRoots));
        }
    }
}