namespace Calculation.Operations;

public class Substract : IOperation
{
    public char Symbol => '/';

    public int Calculate(int a, int b)
    {
        return a / b;
    }

}
