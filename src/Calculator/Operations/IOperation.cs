namespace Calculation.Operations;

public interface IOperation {
    public char Symbol { get; }
    public int Calculate(int a, int b);
}
