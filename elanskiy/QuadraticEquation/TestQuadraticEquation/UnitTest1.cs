using NUnit.Framework;
using QuadraticEquation;

namespace TestQuadraticEquation
{
    public class Tests
    {
        [Test]
        public void DiscriminantCoefficientsAndB_FindRootes_2CorrectResults()
        {
            //arrange
            double discriminant = 16;
            double a = 2;
            double b = -3;
            
            //act
            double[] result = QuadraticEquations.FindRoots(discriminant, a, b);
            
            //assert
            Assert.AreEqual(1.75, result[0], 0.0000001); 
            Assert.AreEqual(-0.25, result[1], 0.0000001);
        }

        [Test]
        public void ThreeDoubleInputs_TryParse_4CorrectResults()
        {
            //arrange
            var input1 = "254.43";
            var input2 = "25";
            var input3 = "40.1234";
            
            //act
            var isSuccessedParsed = QuadraticEquations.TryParse
                (input1, input2, input3, out var a, out var b, out var c);
            
            //assert
            Assert.AreEqual(true, isSuccessedParsed);
            Assert.AreEqual(254.43, a);
            Assert.AreEqual(25, b);
            Assert.AreEqual(40.1234, c);
        }
        
        [Test]
        public void ThreeNotNumberInputs_TryParse_1CorrectResults()
        {
            //arrange
            var input1 = "aaa";
            var input2 = "2 5";
            var input3 = "40.1234c";
            
            //act
            var isSuccessedParsed = QuadraticEquations.TryParse
                (input1, input2, input3, out var a, out var b, out var c);
            
            //assert
            Assert.AreEqual(false, isSuccessedParsed);
        }

        [Test]
        public void ThreeNotZeroNumbers_AreValidatedInputes_1CorrectResult()
        {
            //arrange
            var a = 1;
            var b = -2.5;
            var c = 12700;
            
            //act
            var areValidatedInputes = QuadraticEquations.AreValidatedInputes(a, b, c);
            
            //assert
            Assert.AreEqual(true, areValidatedInputes);
        }

        [Test]
        public void OneZeroAndTwoNonZeroNumbers_AreValidatedInputes_1CorrectResult()
        {
            //arrange
            var a = 0;
            var b = -2.5;
            var c = 12700;
            
            //act
            var areValidatedInputes = QuadraticEquations.AreValidatedInputes(a, b, c);
            
            //assert
            Assert.AreEqual(false, areValidatedInputes);
        }
        
        [Test]
        public void ThreeNumbers_GetDiscriminant_1CorrectResult()
        {
            //arrange
            var a = 4;
            var b = -2.5;
            var c = 2.7;
            
            //act
            var discriminant = QuadraticEquations.GetDiscriminant(a, b, c);
            
            //assert
            Assert.AreEqual(-36.95, discriminant);
        }
        
        [Test]
        public void PositiveDiscriminant_DoesExistRealRoots_1CorrectResult()
        {
            //arrange
            var discriminant = 25.6;
            
            //act
            var doesExistRealRoots = QuadraticEquations.DoesExistRealRoots(discriminant);
            
            //assert
            Assert.AreEqual(true, doesExistRealRoots);
        }
        
        [Test]
        public void  NegativeDiscriminant_DoesExistRealRoots_1CorrectResult()
        {
            //arrange
            var discriminant = -25.6;
            
            //act
            var doesExistRealRoots = QuadraticEquations.DoesExistRealRoots(discriminant);
            
            //assert
            Assert.AreEqual(false, doesExistRealRoots);
        }
        
        
    }
}