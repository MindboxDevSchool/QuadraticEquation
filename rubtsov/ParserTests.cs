using System;
using NUnit.Framework;
using QuadraticEquations;

namespace QuadraticEquationsTests
{
    public class ParserTests
    {
        [Test]
        public void ThrowsFormatException()
        {
            Assert.Throws<FormatException>(() => Program.Parser(new object[] {"Text", 1, 2}));
        }
    }
}