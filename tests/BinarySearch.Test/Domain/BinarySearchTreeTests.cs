using BinarySearch.Domain;

namespace BinarySearch.Test.Domain;

[TestClass]
public class BinarySearchTreeTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void EmptyValuesThrowsException()
    {
        new BinarySearchTree<int>([]);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void DuplicateValueThrowsArgumentException()
    {
        new BinarySearchTree<int>([1, 1]);
    }

    [TestMethod]
    public void LinearTreeOnlyRight()
    {
        //     1
        //      \
        //       2
        //        \ 
        //         3
        var tree = new BinarySearchTree<int>([1, 2, 3]);
        Assert.AreEqual(1, tree.Root.Value);
        Assert.AreEqual(2, tree.Root.Right!.Value);
        Assert.AreEqual(3, tree.Root.Right.Right!.Value);
        Assert.IsNull(tree.Root.Left);
    }

    [TestMethod]
    public void LinearTreeOnlyLeft()
    {
        //     3
        //    /
        //   2
        //  / 
        // 1
        var tree = new BinarySearchTree<int>([3, 2, 1]);
        Assert.AreEqual(3, tree.Root.Value);
        Assert.AreEqual(2, tree.Root.Left!.Value);
        Assert.AreEqual(1, tree.Root.Left.Left!.Value);
        Assert.IsNull(tree.Root.Right);
    }

    [TestMethod]
    public void TreeWithDistributedValues()
    {
        //     5
        //    / \ 
        //   3   8
        //  / \   \
        // 1   4   9
        var tree = new BinarySearchTree<int>([5, 8, 3, 9, 1, 4]);
        Assert.AreEqual(5, tree.Root.Value);

        Assert.AreEqual(8, tree.Root.Right!.Value);
        Assert.AreEqual(3, tree.Root.Left!.Value);

        Assert.AreEqual(1, tree.Root.Left.Left!.Value);
        Assert.AreEqual(4, tree.Root.Left.Right!.Value);
        Assert.AreEqual(9, tree.Root.Right.Right!.Value);
        Assert.IsNull(tree.Root.Right.Left);
    }

    [TestMethod]
    public void ContainsWillNotFindNonExistingElement()
    {
        var tree = new BinarySearchTree<int>([5, 8, 3, 9, 1, 4]);
        Assert.IsFalse(tree.Contains(2));
    }

    [TestMethod]
    public void ContainsWillFindExistingElement()
    {
        var tree = new BinarySearchTree<int>([5, 8, 3, 9, 1, 4]);
        Assert.IsTrue(tree.Contains(9));
    }
}
