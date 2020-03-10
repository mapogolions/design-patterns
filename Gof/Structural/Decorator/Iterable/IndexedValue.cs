namespace Gof.Structural.Decorator.Iterable
{
    public readonly struct IndexedValue<T>
    {
        public IndexedValue(int index, T value)
        {
            Index = index;
            Value = value;
        }

        public int Index { get; }
        public T Value { get; }

        public override string ToString() => $"IndexedValue({Index}, {Value})";
    }
}
