using Calculation.Services;
using Calculation.Operations;
using Common.Domain;

namespace Calculation.Test.Fixtures;

public class CalculatorFixture
{
    public Calculator Calculator { get; } = new(
        new LinkedStack<char>(),
        new LinkedStack<int>(),
        [new Add(), new Substract(), new Multiply(), new Divide()]
    );
}
