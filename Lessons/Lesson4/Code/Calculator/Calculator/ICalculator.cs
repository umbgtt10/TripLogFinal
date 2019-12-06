namespace Calculator
{
    public enum Operator
    {
        Plus = 0,
        Minus = 1,
        Multi = 2,
        Div = 3,
        Unknown = 10,
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

