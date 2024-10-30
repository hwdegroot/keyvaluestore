using Calculator.Test.Fixtures;

namespace Calculator.Test.Services;

[TestClass]
public class CalculationTests
{
    private readonly CalculatorFixture _fixture = new();

    [TestMethod]
    public void PostfixExpression_ReturnsValidCalculation()
    {
        // Arrange
        var calculator = _fixture.calculator;
        // 1+2-3*4*5+6*7
        string postfixExpression = "12345**-+67*+";

        // Act
        int result = calculator.Evaluate(postfixExpression);

        // Assert
        Assert.AreEqual(-15, result);
    }

    [TestMethod]
    public void InfixExpression_CreatesCorrectPostfixExpression()
    {
        // Arrange
        var calculator = _fixture.calculator;
        string infixExpression = "1+2-3*4*5+6*7";
        string postfixExpression = "12345**-+67*+";
        //string infixExpression = "1+2*3-4";
        //string postfixExpression = "123*+4-";

        // Act

        // Assert
        Assert.AreEqual(-15, calculator.Calculate(infixExpression));
        Assert.AreEqual(postfixExpression, calculator.PostfixExpression);
    }
}
