namespace Calculator
{
    public interface ICalculator
    {
        bool AddOperator(Operator operation);

        void AddOperand(Number operand);

        bool AddComma();

        double GetResult();

        double FlipSign();

        double DivideBy100();

        void Reset();
    }
}

