using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Calculator
{
    public enum Operator
    {
        Plus = 0,
        Minus = 1,
        Multi = 2,
        Div = 3,
    }

    public enum Number
    {
        Zero = 0,
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eigth = 8,
        Nine = 9,
    }

    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private ICalculator calculator;

        public MainPage(ICalculator calculator)
        {
            this.calculator = calculator;

            InitializeComponent();
        }

        private void OnButton_1_Clicked(object sender, EventArgs e)
        {
            calculator.AddOperand(Number.One);
            UpdateResult("1");
        }

        private void OnButton_2_Clicked(object sender, EventArgs e)
        {
            calculator.AddOperand(Number.Two);
            UpdateResult("2");
        }

        private void OnButton_3_Clicked(object sender, EventArgs e)
        {
            calculator.AddOperand(Number.Three);
            UpdateResult("3");
        }

        private void OnButton_4_Clicked(object sender, EventArgs e)
        {
            calculator.AddOperand(Number.Four);
            UpdateResult("4");
        }

        private void OnButton_5_Clicked(object sender, EventArgs e)
        {
            calculator.AddOperand(Number.Five);
            UpdateResult("5");
        }

        private void OnButton_6_Clicked(object sender, EventArgs e)
        {
            calculator.AddOperand(Number.Six);
            UpdateResult("6");
        }

        private void OnButton_7_Clicked(object sender, EventArgs e)
        {
            calculator.AddOperand(Number.Seven);
            UpdateResult("7");
        }

        private void OnButton_8_Clicked(object sender, EventArgs e)
        {
            calculator.AddOperand(Number.Eigth);
            UpdateResult("8");
        }

        private void OnButton_9_Clicked(object sender, EventArgs e)
        {
            calculator.AddOperand(Number.Nine);
            UpdateResult("9");
        }

        private void OnButton_0_Clicked(object sender, EventArgs e)
        {
            calculator.AddOperand(Number.Zero);
            UpdateResult("0");
        }

        private void OnButton_Plus_Clicked(object sender, EventArgs e)
        {
            if (calculator.AddOperator(Operator.Plus))
            {
                UpdateResult("+");
            }
        }

        private void OnButton_Minus_Clicked(object sender, EventArgs e)
        {
            if(calculator.AddOperator(Operator.Minus))
            {
                UpdateResult("-");
            }
        }

        private void OnButton_Div_Clicked(object sender, EventArgs e)
        {
            if (calculator.AddOperator(Operator.Div))
            {
                UpdateResult("/");
            }
        }

        private void OnButton_X_Clicked(object sender, EventArgs e)
        {
            if(calculator.AddOperator(Operator.Multi))
            {
                UpdateResult("*");
            }
        }

        private void OnButton_Equals_Clicked(object sender, EventArgs e)
        {
            string result;

            try
            {
                result = calculator.GetResult().ToString();
            }
            catch(InvalidOperationException)
            {
                result = "Divided by 0!!!";
            }

            SetResult(result);
        }

        private void OnButton_PlusMinus_Clicked(object sender, EventArgs e)
        {
            var result = calculator.FlipSign().ToString();

            SetResult(result);
        }

        private void OnButton_C_Clicked(object sender, EventArgs e)
        {
            calculator.Reset();

            ResetResult();
        }

        private void OnButton_Percent_Clicked(object sender, EventArgs e)
        {
            var result = calculator.DivideBy100().ToString();

            SetResult(result);
        }

        private void OnButton_Period_Clicked(object sender, EventArgs e)
        {
            if(calculator.AddComma())
            {
                UpdateResult(",");
            }
        }

        private void UpdateResult(string value)
        {
            Result.Text += value;
        }

        private void SetResult(string value)
        {
            Result.Text = value;
        }

        private void ResetResult()
        {
            Result.Text = string.Empty;
        }
    }
}
