namespace BinarySearch.Domain;

public class Node<T> : INode<T>
{
    public INode<T>? Left { get; set; }
    public INode<T>? Right { get; set; }
    public T Value { get; init; }
    public INode<T>? Parent { get; set; }

    public Node(T value)
    {
        Value = value;
    }


    public bool Equals(INode<T>? other)
    {
        if (other == null)
        {
            return false;
        }
        return Value!.Equals(other.Value);
    }

    public bool Equals(T? otherValue)
    {
        if (otherValue == null)
        {
            return false;
        }
        return Value!.Equals(otherValue);
    }

    public bool IsRightChild => Parent?.Right?.Equals(this) == true;
    public bool IsLeftChild => Parent?.Left?.Equals(this) == true;
    public bool IsRoot => Parent == null;
    public bool IsLeaf => Left == null && Right == null;
}


