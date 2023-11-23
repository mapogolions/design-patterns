namespace Gof.Structural.Decorator.Iterable;

public readonly struct IndexedValue<T>(int index, T value)
{
    public int Index { get; } = index;
    public T Value { get; } = value;

    public override string ToString() => $"IndexedValue({Index}, {Value})";
}
