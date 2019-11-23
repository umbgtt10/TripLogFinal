using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void GetResult_AddOperand_ThenAddPlusOperator_ThanAdOperand_ReturnsExpectedResult()
        {
            // Arrange
            double expectedResult = 4;

            Calculator calculator = new Calculator();
            calculator.AddOperand(Number.Two);
            calculator.AddOperator(Operator.Plus);
            calculator.AddOperand(Number.Two);

            // Act
            double result = calculator.GetResult();

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GetResult_AddOpernadWithComma_AddMulti_AddOperandWithComma_ReturnsExpectedResult()
        {
            // Arrange
            double expectedResult = 10.89;

            Calculator calculator = new Calculator();
            calculator.AddOperand(Number.Three);
            calculator.AddComma();
            calculator.AddOperand(Number.Three);
            calculator.AddOperator(Operator.Multi);
            calculator.AddOperand(Number.Three);
            calculator.AddComma();
            calculator.AddOperand(Number.Three);

            // Act
            double result = calculator.GetResult();

            // Assert
            Assert.IsTrue(expectedResult - result < 0.001);
        }

        [TestMethod]
        public void GetResult_AddOperand_ThenAddMinusOperator_ThanAdOperand_ReturnsExpectedResult()
        {
            // Arrange
            double expectedResult = 0;

            Calculator calculator = new Calculator();
            calculator.AddOperand(Number.Two);
            calculator.AddOperator(Operator.Minus);
            calculator.AddOperand(Number.Two);

            // Act
            double result = calculator.GetResult();

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
