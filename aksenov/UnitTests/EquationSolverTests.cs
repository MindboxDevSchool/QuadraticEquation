using NUnit.Framework;
using QuadraticEquation;

namespace UnitTests
{
    public class EquationSolverTests
    {
        [Test]
        public void Parse_ThreePositiveIntegerCoefficients()
        {
            //arrange
            string equation = "2x^2 + 4x + 8";
            EquationSolver equationSolver = new EquationSolver();

            //act
            double[] coefficients = equationSolver.Parse(equation);

            //assert
            Assert.AreEqual(2, coefficients[0]);
            Assert.AreEqual(4, coefficients[1]);
            Assert.AreEqual(8, coefficients[2]);
        }
        
        [Test]
        public void Parse_ThreeNegativeIntegerCoefficients()
        {
            //arrange
            string equation = "-6x^2 - 10x - 20";
            EquationSolver equationSolver = new EquationSolver();

            //act
            double[] coefficients = equationSolver.Parse(equation);

            //assert
            Assert.AreEqual(-6, coefficients[0]);
            Assert.AreEqual(-10, coefficients[1]);
            Assert.AreEqual(-20, coefficients[2]);
        }
        
        [Test]
        public void Parse_ThreeDoubleCoefficients()
        {
            //arrange
            string equation = "-6,2x^2 - 10,14x + 20,256";
            EquationSolver equationSolver = new EquationSolver();

            //act
            double[] coefficients = equationSolver.Parse(equation);

            //assert
            Assert.AreEqual(-6.2, coefficients[0]);
            Assert.AreEqual(-10.14, coefficients[1]);
            Assert.AreEqual(20.256, coefficients[2]);
        }
        
        [Test]
        public void Parse_ThreeBigCoefficients()
        {
            //arrange
            string equation = "-256000x^2 + 1281024.89000014x + 999999999.999999";
            EquationSolver equationSolver = new EquationSolver();

            //act
            double[] coefficients = equationSolver.Parse(equation);

            //assert
            Assert.AreEqual(-256000, coefficients[0]);
            Assert.AreEqual(1281024.89000014, coefficients[1]);
            Assert.AreEqual(999999999.999999, coefficients[2]);
        }
        
        [Test]
        public void Parse_ThreeUnitCoefficients()
        {
            //arrange
            string equation = "x^2 + x - 1";
            EquationSolver equationSolver = new EquationSolver();

            //act
            double[] coefficients = equationSolver.Parse(equation);

            //assert
            Assert.AreEqual(new double[] {1, 1, -1}, coefficients);
        }
        
        [Test]
        public void Parse_OnlyFirstAndSecondCoefficients()
        {
            //arrange
            string equation = "3x^2 + 4x";
            EquationSolver equationSolver = new EquationSolver();

            //act
            double[] coefficients = equationSolver.Parse(equation);

            //assert
            Assert.AreEqual(new double[] {3, 4, 0}, coefficients);
        }
        
        [Test]
        public void Parse_OnlyFirstAndThirdCoefficients()
        {
            //arrange
            string equation = "3x^2 + 4";
            EquationSolver equationSolver = new EquationSolver();

            //act
            double[] coefficients = equationSolver.Parse(equation);

            //assert
            Assert.AreEqual(new double[] {3, 0, 4}, coefficients);
        }
        
        [Test]
        public void Parse_OnlyFirstCoefficient()
        {
            //arrange
            string equation = "3x^2";
            EquationSolver equationSolver = new EquationSolver();

            //act
            double[] coefficients = equationSolver.Parse(equation);

            //assert
            Assert.AreEqual(new double[] {3, 0, 0}, coefficients);
        }
        
        [Test]
        public void GetDeterminant_ThreePositiveCoefficients_ReturnCorrectDeterminant()
        {
            //arrange
            double[] coefficients = new[] {1.0, 4, 2};
            EquationSolver equationSolver = new EquationSolver();

            //act
            double determinant = equationSolver.GetDeterminant(coefficients);

            //assert
            Assert.AreEqual(8, determinant);
        }
        
        [Test]
        public void GetDeterminant_ThreeNegativeCoefficients_ReturnCorrectDeterminant()
        {
            //arrange
            double[] coefficients = new[] {-1.0, -4, -2};
            EquationSolver equationSolver = new EquationSolver();

            //act
            double determinant = equationSolver.GetDeterminant(coefficients);

            //assert
            Assert.AreEqual(8, determinant);
        }
        
        [Test]
        public void GetRoots_ThreePositiveCoefficients_Return2Roots()
        {
            //arrange
            double determinant = 9;
            double[] coefficients = new[] {2.0, 5, 2};
            EquationSolver equationSolver = new EquationSolver();

            //act
            double[] roots = equationSolver.GetRoots(determinant, coefficients);

            //assert
            Assert.AreEqual(new[]{-0.5, -2}, roots);
        }
        
        [Test]
        public void GetRoots_ThreeNegativeCoefficients_Return2Roots()
        {
            //arrange
            double determinant = 1;
            double[] coefficients = new[] {-4.0, -9, -5};
            EquationSolver equationSolver = new EquationSolver();

            //act
            double[] roots = equationSolver.GetRoots(determinant, coefficients);

            //assert
            Assert.AreEqual(new[]{-1.25, -1}, roots);
        }
        
        [Test]
        public void GetRoots_OneZeroCoefficient_Return2Roots()
        {
            //arrange
            double determinant = 25;
            double[] coefficients = new[] {2.0, 5, 0};
            EquationSolver equationSolver = new EquationSolver();

            //act
            double[] roots = equationSolver.GetRoots(determinant, coefficients);

            //assert
            Assert.AreEqual(new[]{0, -2.5}, roots);
        }
        
        [Test]
        public void GetRoots_TwoZeroCoefficients_Return1Root()
        {
            //arrange
            double determinant = 0;
            double[] coefficients = new[] {2.0, 0, 0};
            EquationSolver equationSolver = new EquationSolver();

            //act
            double[] roots = equationSolver.GetRoots(determinant, coefficients);

            //assert
            Assert.AreEqual(new[]{0, 0}, roots);
        }
        
        [Test]
        public void IsEquationQuadratic_FullQuadraticEquation()
        {
            //arrange
            string equation = "2x^2-4x+5";
            EquationSolver equationSolver = new EquationSolver();

            //act
            bool isQuadratic = equationSolver.IsEquationQuadratic(equation);

            //assert
            Assert.AreEqual(true, isQuadratic);
        }
        
        [Test]
        public void IsEquationQuadratic_QuadraticEquationWithFirstAndSecondArguments()
        {
            //arrange
            string equation = "2x^2-4,5x";
            EquationSolver equationSolver = new EquationSolver();

            //act
            bool isQuadratic = equationSolver.IsEquationQuadratic(equation);

            //assert
            Assert.AreEqual(true, isQuadratic);
        }
        
        [Test]
        public void IsEquationQuadratic_QuadraticEquationWithFirstAndThirdArguments()
        {
            //arrange
            string equation = "2x^2+7,15";
            EquationSolver equationSolver = new EquationSolver();

            //act
            bool isQuadratic = equationSolver.IsEquationQuadratic(equation);

            //assert
            Assert.AreEqual(true, isQuadratic);
        }
        
        [Test]
        public void IsEquationQuadratic_QuadraticEquationWithOneArgument()
        {
            //arrange
            string equation = "3,14x^2";
            EquationSolver equationSolver = new EquationSolver();

            //act
            bool isQuadratic = equationSolver.IsEquationQuadratic(equation);

            //assert
            Assert.AreEqual(true, isQuadratic);
        }
    }
}