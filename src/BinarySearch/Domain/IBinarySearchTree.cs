namespace BinarySearch.Domain;

public interface IBinarySearchTree<T>
{
    void Insert(T value);
    void Remove(T value);

    bool Contains(T value);
}
