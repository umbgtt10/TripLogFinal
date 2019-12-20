using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Calculator
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly ICalculator calculator;

        private string result = string.Empty;
        public string Result
        {
            get
            {
                return result;
            }
            private set
            {
                if(result != value)
                {
                    result = value;
                    Notify(nameof(Result));
                }
            }
        }

        private ICommand addElementCommand;
        public ICommand AddElementCommand
        {
            get
            {
                addElementCommand = new Command<string>(CalculatorCommand);

                return addElementCommand;
            }
        }

        public MainPageViewModel(ICalculator calculator)
        {
            this.calculator = calculator;
        }

        private void CalculatorCommand(string args)
        {
            if(int.TryParse(args, out int number))
            {
                Number n = (Number)number;
                this.calculator.AddOperand(n);
                UpdateResult(args);
            }
            else if(TryParseOperator(args, out Operator op))
            {
                if(this.calculator.AddOperator(op))
                {
                    UpdateResult(args);
                }
            }
            else
            {
                switch(args)
                {
                    case "=":
                        string result;

                        try
                        {
                            result = calculator.GetResult().ToString();
                        }
                        catch (InvalidOperationException)
                        {
                            result = "Divided by 0!!!";
                        }

                        SetResult(result);
                        break;

                    case "%":
                        SetResult(calculator.DivideBy100().ToString());
                        break;

                    case ".":
                        if (calculator.AddComma())
                        {
                            UpdateResult(",");
                        }
                        break;

                    case "C":
                        calculator.Reset();
                        ResetResult();
                        break;

                    case "+-":
                        SetResult(calculator.FlipSign().ToString());
                        break;
                }
            }
        }

        private void UpdateResult(string value)
        {
            Result += value;
        }

        private void SetResult(string value)
        {
            Result = value;
        }

        private void ResetResult()
        {
            Result = string.Empty;
        }

        private bool TryParseOperator(string args, out Operator @operator)
        {
            @operator = Operator.Unknown;
            var result = false;

            switch (args)
            {
                case "/":
                    @operator = Operator.Div;
                    result = true;
                    break;

                case "-":
                    @operator = Operator.Minus;
                    result = true;
                    break;

                case "X":
                    @operator = Operator.Multi;
                    result = true;
                    break;

                case "+":
                    @operator = Operator.Plus;
                    result = true;
                    break;
            }

            return result;
        }
    }
}
