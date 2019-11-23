using System;

namespace Calculator
{
    public class Calc : ICalculator
    {
        private string operand1Txt;
        private string operand2Txt;
        private Operator? operation;

        public void AddOperand(Number operand)
        {
            if (!operation.HasValue)
            {
                operand1Txt += (int)operand;
            }
            else
            {
                operand2Txt += (int)operand;
            }
        }

        public bool AddComma()
        {
            if (!operation.HasValue && !operand1Txt.Contains(","))
            {
                operand1Txt += ",";

                return true;
            }

            else if (operation.HasValue && !operand2Txt.Contains(","))
            {
                operand2Txt += ",";

                return true;
            }

            return false;
        }

        public bool AddOperator(Operator operation)
        {
            if(!IsOperandUnset(operand1Txt) && (!this.operation.HasValue || this.operation.Value != operation))
            {
                this.operation = operation;

                return true;
            }

            return false;
        }

        public double GetResult()
        {
            double result;

            if(IsOperandUnset(operand1Txt))
            {
                return 0;
            }

            var operand1 = Convert.ToDouble(operand1Txt);

            if (IsOperandUnset(operand2Txt))
            {
                return operand1;
            }

            var operand2 = Convert.ToDouble(operand2Txt);

            switch (operation)
            {
                case Operator.Plus:
                    result = operand1 + operand2;
                    SetCarryOver(result);
                    break;

                case Operator.Minus:
                    result = operand1 - operand2;
                    SetCarryOver(result);
                    break;

                case Operator.Multi:
                    result = operand1 * operand2;
                    SetCarryOver(result);
                    break;

                case Operator.Div:
                    ThrowIfSecondOperandIsZero();
                    result = operand1 / operand2;
                    SetCarryOver(result);
                    break;

                default:
                    throw new InvalidOperationException();
            }

            return result;
        }

        public void Reset()
        {
            operand1Txt = null;
            operand2Txt = null;
            operation = null;
        }

        public double FlipSign()
        {
            if (IsOperandUnset(operand1Txt))
            {
                return 0;
            }

            var result = double.Parse(operand1Txt, System.Globalization.CultureInfo.InvariantCulture) * (-1);
            operand1Txt = result.ToString();
            
            return result;
        }

        public double DivideBy100()
        {
            if (IsOperandUnset(operand1Txt))
            {
                return 0;
            }

            var result = double.Parse(operand1Txt, System.Globalization.CultureInfo.InvariantCulture) / 100;
            operand1Txt = result.ToString();

            return result;
        }

        private void SetCarryOver(double result)
        {
            operand1Txt = result.ToString();
            operand2Txt = null;
            operation = null;
        }

        private bool IsOperandUnset(string operand)
        {
            if (string.IsNullOrEmpty(operand))
            {
                return true;
            }

            return false;
        }

        private void ThrowIfSecondOperandIsZero()
        {
            if(double.Parse(operand2Txt) == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}