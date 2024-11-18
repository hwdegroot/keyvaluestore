namespace BinarySearch.Domain;

public interface INode<T>
{
    INode<T>? Left { get; set; }
    INode<T>? Right { get; set; }
    T Value { get; set; }
    INode<T>? Parent { get; set; }

    bool IsRoot { get; }
    bool IsLeaf { get; }
}

