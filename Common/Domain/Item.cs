namespace Common.Domain;

public sealed record Item<T>
{
    public required T Value { get; init; }
    public Item<T>? Next { get; set; }
    public Item<T>? Previous { get; set; }
}

