using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Calculator
{
    [TestClass]
    public class MainPageViewModelTests
    {
        private readonly Mock<ICalculator> calculatorMock;
        private readonly MainPageViewModel testee;

        public MainPageViewModelTests()
        {
            calculatorMock = new Mock<ICalculator>();
            testee = new MainPageViewModel(calculatorMock.Object);
        }

        [DataTestMethod]
        [DataRow("0", Number.Zero)]
        [DataRow("1", Number.One)]
        [DataRow("2", Number.Two)]
        [DataRow("3", Number.Three)]
        [DataRow("4", Number.Four)]
        [DataRow("5", Number.Five)]
        [DataRow("6", Number.Six)]
        [DataRow("7", Number.Seven)]
        [DataRow("8", Number.Eigth)]
        [DataRow("9", Number.Nine)]
        public void AddElementCommand_AddOperand_CallsCorrespondingMethod(string operand, Number expectedNumber)
        {
            // Arrange && Act
            testee.AddElementCommand.Execute(operand);

            // Assert
            calculatorMock.Verify(m => m.AddOperand(expectedNumber), Times.Once);
            Assert.AreEqual(testee.Result, operand);
        }

        [DataTestMethod]
        [DataRow("+", Operator.Plus)]
        [DataRow("-", Operator.Minus)]
        [DataRow("X", Operator.Multi)]
        [DataRow("/", Operator.Div)]
        public void AddElementCommand_AddOperator_CallsCorrespondingMethod(string @operator, Operator argumentOperator)
        {
            // Arrange 
            var firstOperand = "1";
            var expectedResult = firstOperand + @operator;
            this.calculatorMock.Setup(m => m.AddOperator(It.IsAny<Operator>())).Returns(true);
            testee.AddElementCommand.Execute(firstOperand);

            // Act
            testee.AddElementCommand.Execute(@operator);

            // Assert
            calculatorMock.Verify(m => m.AddOperator(argumentOperator), Times.Once);
            Assert.AreEqual(testee.Result, expectedResult);
        }

        [TestMethod]
        public void AddElementCommand_AddComma_CallsCorrespondingMethod()
        {
            // Arrange 
            var firstOperand = "1";
            var expectedResult = firstOperand + ",";
            this.calculatorMock.Setup(m => m.AddComma()).Returns(true);
            testee.AddElementCommand.Execute(firstOperand);

            // Act
            testee.AddElementCommand.Execute(".");

            // Assert
            calculatorMock.Verify(m => m.AddComma(), Times.Once);
            Assert.AreEqual(testee.Result, expectedResult);
        }

        [TestMethod]
        public void AddElementCommand_AddPercent_CallsCorrespondingMethod()
        {
            // Arrange 
            testee.AddElementCommand.Execute("1");

            // Act
            testee.AddElementCommand.Execute("%");

            // Assert
            calculatorMock.Verify(m => m.DivideBy100(), Times.Once);
        }

        [TestMethod]
        public void AddElementCommand_AddPlusMinus_CallsCorrespondingMethod()
        {
            // Arrange 
            var firstOperand = "1";
            var expectedResult = "-"+ firstOperand;
            testee.AddElementCommand.Execute(firstOperand);

            // Act
            testee.AddElementCommand.Execute("+-");

            // Assert
            calculatorMock.Verify(m => m.FlipSign(), Times.Once);
        }

        [TestMethod]
        public void AddElementCommand_AddReset_CallsCorrespondingMethod()
        {
            // Arrange 
            var expectedResult = string.Empty;

            // Act
            testee.AddElementCommand.Execute("C");

            // Assert
            calculatorMock.Verify(m => m.Reset(), Times.Once);
            Assert.AreEqual(testee.Result, expectedResult);
        }
        [TestMethod]
        public void AddElementCommand_AddOperandThanOperatorThanOperand_CallsCorrespondingMethod()
        {
            // Arrange 
            testee.AddElementCommand.Execute("10");
            testee.AddElementCommand.Execute("*");
            testee.AddElementCommand.Execute("10");

            // Act
            testee.AddElementCommand.Execute("=");

            // Assert
            calculatorMock.Verify(m => m.GetResult(), Times.Once);            
        }
    }
}

