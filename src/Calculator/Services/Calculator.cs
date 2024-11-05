using Common.Domain;
using Calculation.Operations;

namespace Calculation.Services;

public class Calculator(IStack<char> operatorStack, IStack<int> operandStack, IOperation[] operations)
{
    private readonly IStack<char> _operatorStack = operatorStack;
    private readonly IStack<int> _operandStack = operandStack;
    private readonly IOperation[] _operations = operations;
    public string PostfixExpression { get; private set; } = string.Empty;
    public string OperatorStack => _operatorStack?.ToString() ?? string.Empty;

    private readonly Dictionary<char, int> operatorPrecedence = new Dictionary<char, int> {
            { '+', 1 },
            { '-', 1 },
            { '*', 2 },
            { '/', 2 }
        };

    private const char OpenParenthesis = '(';
    private const char CloseParenthesis = ')';

    private string Infix2PostfixExpression(string infixExpression)
    {

        foreach (char c in infixExpression)
        {
            if (IsOperand(c))
            {
                PostfixExpression += c;
            }
            else if (c == OpenParenthesis)
            {
                _operatorStack.Push(c);
            }
            else if (c == CloseParenthesis)
            {
                while (!_operatorStack.IsEmpty && _operatorStack.Peek() != OpenParenthesis)
                {
                    PostfixExpression += _operatorStack.Pop();
                }
                _operatorStack.Pop();
            }
            else if (IsOperator(c))
            {
                while (!_operatorStack.IsEmpty && operatorPrecedence[_operatorStack.Peek()] >= operatorPrecedence[c])
                {
                    PostfixExpression += _operatorStack.Pop();
                }
                _operatorStack.Push(c);
            }
        }
        while (!_operatorStack.IsEmpty)
        {
            PostfixExpression += _operatorStack.Pop();
        }
        return PostfixExpression;
    }

    public int Calculate(string infixExpression)
    {
        string postfixExpression = Infix2PostfixExpression(infixExpression);
        return Evaluate(postfixExpression);
    }

    public int Evaluate(string postfixExpression)
    {
        foreach (char c in postfixExpression)
        {
            if (char.IsDigit(c))
            {
                _operandStack.Push(int.Parse(c.ToString()));
            }
            else if (IsOperator(c))
            {
                IOperation operation = _operations.FirstOrDefault(op => op.Symbol == c) ?? throw new InvalidOperationException("Unknown operator");
                int b = _operandStack.Pop();
                int a = _operandStack.Pop();
                int result = operation.Calculate(a, b);

                _operandStack.Push(result);
            }
            else
            {
                throw new InvalidOperationException("Invalid expression");
            }
        }

        // The result should be the only item in the stack
        if (_operandStack.Size != 1)
        {
            throw new InvalidOperationException("Invalid expression");
        }

        return _operandStack.Pop();
    }

    private bool IsOperator(char c)
    {
        return _operations.Any(op => op.Symbol == c);
    }

    private bool IsOperand(char c)
    {
        return char.IsDigit(c);
    }
}
