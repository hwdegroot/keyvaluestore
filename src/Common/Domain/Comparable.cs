namespace Common.Domain;

public class Comparable<T> : IComparable<T>
{
    public int CompareTo(T other)
    {
        if (this == null || other == null)
        {
            return 0;
        }

        return ToString().CompareTo(other.ToString());
    }

    public bool GreaterThan(T other)
    {
        return CompareTo(other) > 0;
    }

    public bool SmallerThan(T other)
    {
        return CompareTo(other) < 0;
    }

    public bool Equals(T other)
    {
        return CompareTo(other) == 0;
    }
}


