namespace BinarySearch.Domain;

public class Node<T> : INode<T>
{
    public INode<T>? Left { get; set; }
    public INode<T>? Right { get; set; }
    public T Value { get; set; }
    public INode<T>? Parent { get; set; }

    public Node(T value)
    {
        Value = value;
    }

    public bool IsRoot => Parent == null;
    public bool IsLeaf => Left == null && Right == null;
}


