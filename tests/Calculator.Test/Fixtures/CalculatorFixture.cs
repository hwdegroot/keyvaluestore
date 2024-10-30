using Calculation.Operations;
using Common.Domain;

namespace Calculator.Test.Fixtures;

public class CalculatorFixture
{
    public Calculation.Services.Calculator calculator = new(
        new LinkedStack<char>(),
        new LinkedStack<int>(), 
        [new Add(), new Substract(), new Multiply(), new Divide()]
    );
}
