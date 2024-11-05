using Calculation.Services;
using Calculation.Test.Fixtures;

namespace Calculation.Test.Services;

[TestClass]
public class CalculationTests(CalculatorFixture fixture)
{
    private readonly Calculator Calculator = fixture.Calculator;

    [TestMethod]
    public void PostfixExpression_ReturnsValidCalculation()
    {
        // Arrange
        // 1+2-3*4*5+6*7
        string postfixExpression = "12345**-+67*+";

        // Act
        int result = Calculator.Evaluate(postfixExpression);

        // Assert
        Assert.AreEqual(-15, result);
    }

    [TestMethod]
    public void InfixExpression_CreatesCorrectPostfixExpression()
    {
        // Arrange
        string infixExpression = "1+2-3*4*5+6*7";
        // Act
        var result = Calculator.Calculate(infixExpression);
        // Assert
        Assert.AreEqual(-15, result);
    }
}
