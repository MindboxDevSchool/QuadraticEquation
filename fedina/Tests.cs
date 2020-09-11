// using Microsoft.TestPlatform.TestHost;
using NUnit.Framework;
using ConsoleApp1;
using UnitTests.Tests;

namespace UnitTests.Tests
{
    public class MyClassTests
    {
        [Test]
        public void CorrectInputes_Calculates_1CorrectResult()
        {
            //arrange
            //1 3 2
            double a = 1;
            double b = 3;
            double c = 2;
            double d = Program1.GetDiscriminant(1, 3, 2);
            Program1.EquationTypes type = Program1.CheckEquationType(a, b, c);
            
            //act
            double[] result = Program1.FindRoots(type, d, a, b, c);
            
            //assert
            Assert.AreEqual(new double[] {-2.0, -1.0}, result);
        }
        
        [Test]
        public void LinearEquation()
        {
            //arrange
            //1 3 2
            double a = 0;
            double b = 3;
            double c = 2;
            double d = Program1.GetDiscriminant(1, 3, 2);
            Program1.EquationTypes type = Program1.CheckEquationType(a, b, c);
            
            //act
            double[] result = Program1.FindRoots(type, d, a, b, c);
            
            //assert
            Assert.AreEqual(new double[] {-2.0/3.0}, result);
        }
        
    }
}