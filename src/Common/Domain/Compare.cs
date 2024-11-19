namespace Common.Domain;

public static class Compare
{
    public static int CompareTo(object value, object other)
    {
        if (value == null || other == null)
        {
            return 0;
        }

        return value.ToString()!.CompareTo(other.ToString());
    }

    public static bool GreaterThan(object value, object other)
    {
        return CompareTo(value, other) > 0;
    }

    public static bool SmallerThan(object value, object other)
    {
        return CompareTo(value, other) < 0;
    }
}


