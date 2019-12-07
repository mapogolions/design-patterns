namespace Gof.Structural.Adapter
{
    public static class PersistentList
    {
        public static Cons<T> Of<T>(params T[] items)
        {
            Cons<T> iter(Cons<T> tail, int index)
            {
                if (index <= 0)
                    return tail;
                return iter(new Cons<T>(items[index - 1], tail), --index);
            }
            return iter(null, items.Length);
        }
    }
}
