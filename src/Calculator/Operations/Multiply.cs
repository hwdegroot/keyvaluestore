namespace Calculation.Operations;

public class Multiply : IOperation
{
    public char Symbol => '*';

    public int Calculate(int a, int b)
    {
        return a * b;
    }

}
