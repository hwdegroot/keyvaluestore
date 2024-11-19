using BinarySearch.Enums;
using Common.Domain;

namespace BinarySearch.Domain;

public class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable
{
    public INode<T> Root { get; init; }

    public BinarySearchTree(IEnumerable<T> values)
    {
        if (values.Count() == 0)
        {
            throw new ArgumentException("Values cannot be empty", nameof(values));
        }

        Root = new Node<T>(values.First());
        foreach (var value in values.Skip(1))
        {
            Insert(value);
        }

    }

    private Direction DetermineDirection(T value, INode<T> current)
    {
        if (value.Equals(current.Value))
        {
            throw new ArgumentException("Value already exists in tree", nameof(value));
        }

        if (Compare.SmallerThan(value, current.Value))
        {
            return Direction.Left;
        }
        return Direction.Right;
    }

    private bool ShouldInsertLeft(T value, INode<T> current)
    {
        return current.Left == null && DetermineDirection(value, current) == Direction.Left;
        // || DetermineDirection(value, current) == Direction.Left && Compare.GreaterThan(value, current.Left!.Value);
    }

    private bool ShouldInsertRight(T value, INode<T> current)
    {
        return current.Right == null && DetermineDirection(value, current) == Direction.Right;
        // || DetermineDirection(value, current) == Direction.Right && Compare.SmallerThan(value, current.Right!.Value);
    }

    private void InsertLeft(T value, INode<T> current)
    {
        var newNode = new Node<T>(value);
        newNode.Parent = current;
        newNode.Left = current.Left;
        current.Left = newNode;
    }

    private void InsertRight(T value, INode<T> current)
    {
        var newNode = new Node<T>(value);
        newNode.Parent = current;
        newNode.Right = current.Right;
        current.Right = newNode;
    }

    public void Insert(T value)
    {
        INode<T> current = Root;

        while (!current.IsLeaf)
        {
            if (ShouldInsertLeft(value, current))
            {
                InsertLeft(value, current);
                return;
            }

            if (ShouldInsertRight(value, current))
            {
                InsertRight(value, current);
                return;
            }

            current = DetermineDirection(value, current) == Direction.Left ? current.Left! : current.Right!;
        }

        if (ShouldInsertRight(value, current))
        {
            InsertRight(value, current);
            return;
        }

        InsertLeft(value, current);
    }

    private void RemoveNode(INode<T> node)
    {
        if (node == null)
        {
            throw new ArgumentException("Node is null", nameof(node));
        }

        if (node.Left != null)
        {
            if (node.Right != null)
            {
                if (!node.IsRoot)
                {
                    node.Parent!.Left = node.Right;
                    node.Right.Parent = node.Parent;
                }
                var newLeftNodeParent = node.Right;
                while (newLeftNodeParent.Left != null)
                {
                    newLeftNodeParent = newLeftNodeParent.Left;
                }
                newLeftNodeParent.Left = node.Left;
                node.Left.Parent = newLeftNodeParent;
            }
            else if (!node.IsRoot)
            {
                node.Parent!.Left = node.Left;
                node.Left.Parent = node.Parent;
            }
        }
        else if (node.Right != null && !node.IsRoot)
        {
            if (node.IsRightChild)
            {
                node.Parent!.Right = node.Right;
            }
            else if (node.IsLeftChild)
            {
                node.Parent!.Left = node.Right;
            }
            node.Right.Parent = node.Parent;
        }
    }

    public void Remove(T value)
    {
        var node = Find(value);
        if (node == null)
        {
            throw new ArgumentException("Value not found in tree", nameof(value));
        }

        if (node.IsRoot)
        {
            RemoveNode(Root!);
        }

        if (node.IsLeaf)
        {
            if (node.Parent!.Left == node)
            {
                node.Parent.Left = null;
            }
            else
            {
                node.Parent.Right = null;
            }
        }
        else if (node.Left != null)
        {
            node.Parent!.Left = node.Left;
        }
        if (node.Right != null)
        {
            node.Parent!.Right = node.Right;
        }
    }

    public bool Contains(T value) => Find(value) != null;

    private INode<T>? Find(T value)
    {
        if (Root == null)
        {
            return null;
        }

        INode<T>? current = Root;
        while (current != null)
        {
            if (current.Value.Equals(value)) return current;

            if (Compare.SmallerThan(value, current.Value) && (current.Left == null || Compare.GreaterThan(value, current.Left.Value)))
            {
                return null;
            }

            if (Compare.GreaterThan(value, current.Value) && (current.Right == null || Compare.SmallerThan(value, current.Right.Value)))
            {
                return null;
            }

            current = DetermineDirection(value, current) == Direction.Left ? current.Left : current.Right;

        }
        return null;
    }
}
