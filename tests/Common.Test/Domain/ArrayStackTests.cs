using Common.Domain;

namespace Common.Test.Domain;

[TestClass]
public class ArrayStackTests
{
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void EmptyStackWillNotPop()
    {
        var stack = new ArrayStack<int>();

        stack.Pop();
    }

    [TestMethod]
    public void StackWillPopItemsInOrder()
    {
        var stack = new ArrayStack<int>(100);

        for (var i = 0; i < 100; i++)
        {
            stack.Push(i);
        }

        for (var i = 99; i >= 0; i--)
        {
            Assert.AreEqual((uint)(i + 1), stack.Size);
            Assert.AreEqual(i, stack.Peek());
            Assert.AreEqual(i, stack.Pop());
        }
        Assert.AreEqual((uint)0, stack.Size);
    }

    [TestMethod]
    public void StackWillResizeWhenLimitReached()
    {
        var stack = new ArrayStack<int>();

        for (var i = 0; i < 100; i++)
        {
            stack.Push(i);
        }

        for (var i = 99; i >= 0; i--)
        {
            Assert.AreEqual((uint)(i + 1), stack.Size);
            Assert.AreEqual(i, stack.Peek());
            Assert.AreEqual(i, stack.Pop());
        }
        Assert.AreEqual((uint)0, stack.Size);
    }
}
