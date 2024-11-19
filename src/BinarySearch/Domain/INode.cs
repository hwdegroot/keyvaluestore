namespace BinarySearch.Domain;

public interface INode<T>
{
    INode<T>? Left { get; set; }
    INode<T>? Right { get; set; }
    T Value { get; init; }
    INode<T>? Parent { get; set; }

    bool IsRightChild { get; }
    bool IsLeftChild { get; }
    bool IsRoot { get; }
    bool IsLeaf { get; }
}

