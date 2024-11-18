using BinarySearch.Enums;

namespace BinarySearch.Domain;

class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable<T>
{
    public Node<T>? Root { get; private set; }

    public BinarySearchTree(IEnumerable<T> values)
    {

        foreach (var value in values)
        {
            Insert(value);
        }

    }

    public void Insert(T value)
    {
        if (Root == null)
        {
            Root = new Node<T>(value);
            return;
        }

        Direction? direction = null;
        INode<T> current = Root;
        INode<T>? parent = null;


        while (parent == null)
        {
            if (value.CompareTo(current.Value) >= 0)
            {
                direction = Direction.Left;
            }
            else
            {
                direction = Direction.Right;
            }

            if (direction == Direction.Left && current.Left == null)
            {
                parent = current;
            }
            else if (direction == Direction.Left && value.CompareTo(current.Left!.Value) <= 0)
            {
                parent = current;
            }
            else if (direction == Direction.Right && current.Right == null)
            {
                parent = current;
            }
            else if (direction == Direction.Right && value.CompareTo(current.Right!.Value) > 0)
            {
                parent = current;
            }
            else if (current.IsLeaf)
            {
                parent = current;
            }
            current = direction == Direction.Left ? current.Left! : current.Right!;
        }

        var newNode = new Node<T>(value);
        newNode.Parent = parent;
        if (direction == Direction.Left)
        {
            newNode.Left = parent.Left;
            parent.Left = newNode;
        }
        else
        {
            newNode.Right = parent.Right;
            parent.Right = newNode;
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
            // TODO: promote new node to root
            throw new ArgumentException("Cannot remove root node", nameof(value));
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
        while (current != null && !current.IsLeaf)
        {
            if (current!.Value.Equals(value))
            {
                return current;
            }

            if (current!.Value.CompareTo(value) > 0)
            {
                // parent bigger than value, but child smaller
                // The value is not in the tree
                if (current.Left == null || current.Left!.Value.CompareTo(value) < 0)
                {
                    return null;
                }
                current = current!.Left;
            }
            else
            {
                // parent smaller than value, but child bigger
                // The value is not in the tree
                if (current.Right == null || current.Right!.Value.CompareTo(value) > 0)
                {
                    return null;
                }
                current = current!.Right;
            }
        }
        return null;
    }
}
