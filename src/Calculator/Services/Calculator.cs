using Common.Domain;
using Calculation.Operations;

namespace Calculation.Services;

public class Calculator(IStack<int> stack, IOperation[] operations)
{
    private readonly IStack<int> _stack = stack;
    private readonly IOperation[] _operations = operations;

    public void FromArithmicExpression(string expression)
    {
        throw new NotImplementedException();
    }

    public int Evaluate(string expression)
    {
        foreach (char c in expression)
        {
            if (char.IsDigit(c))
            {
                _stack.Push(int.Parse(c.ToString()));
            }
            else
            {
                IOperation operation = _operations.First(op => op.Symbol == c);
                // If no operation, throw
                int b = _stack.Pop();
                int a = _stack.Pop();
                int result = operation.Calculate(a, b);
                _stack.Push(result);
            }
        }

        // The result should be the only item in the stack
        if (_stack.Size != 1)
        {
            throw new InvalidOperationException("Invalid expression");
        }

        return _stack.Pop();
    }
}
