using NUnit.Framework;
using QuadRoots;

namespace QuadRoots.Tests
{
    public class Tests
    {
        [Test]
        public void CorrectCoefficience_CalculatesDiscriminant_1CorrectDiscriminant()
        {
            //arrange
            //1 5 4
            HW2.QuadAndLinearEquation myclass = new HW2.QuadAndLinearEquation(1, 5, 4);

            //act
            double result = myclass.FindDiscriminant();
            
            //assert
            Assert.AreEqual(9.0, result);
        }

        [Test]
        public void CorrectDiscriminant_CalculatesRoots_2CorrectRoots()
        {
            //arrange
            //1 5 4
            HW2.QuadAndLinearEquation myclass = new HW2.QuadAndLinearEquation(1, 5, 4);
            myclass.FindDiscriminant();
            //act
            double[] result= myclass.FindQuadRoots();
            
            //assert
            Assert.AreEqual(-1.0, result[0]);
            Assert.AreEqual(-4.0, result[1]);
        }

        [Test]
        public void LinearRoots_CalculatesRoot_1CorrectRoot()
        {
            //arrange
            //1 5 4
            HW2.QuadAndLinearEquation myclass = new HW2.QuadAndLinearEquation(0, 5, 5);
            //myclass.FindDiscriminant();
            //act
            double result= myclass.FindLinearRoots();
            //assert
            Assert.AreEqual(-1.0, result);
        }
    }
}