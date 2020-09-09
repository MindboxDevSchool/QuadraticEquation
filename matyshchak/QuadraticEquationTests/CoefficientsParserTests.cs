using System;
using NUnit.Framework;
using QuadraticEquation;

namespace QuadraticEquationTests
{
    public class CoefficientsParserTests
    {
        [TestCase("Hello123")]
        [TestCase("  1  2  ")]
        public void Parsing_unexpected_input_throws_custom_format_exception(string input)
        {
            Assert.That(() => CoefficientsParser.Parse(input), Throws.TypeOf<EquationInputFormatException>());
        }
        
        [Test]
        public void Correctly_Parses_three_numbers_separated_by_spaces()
        {
            var input = "1 2 3.14";
            var expectedCoefficients = (1.0, 2.0, 3.14);
            var actualCoefficients = CoefficientsParser.Parse(input);
            Assert.That(actualCoefficients, Is.EqualTo(expectedCoefficients));
        }
    }
}