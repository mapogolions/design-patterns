using System;

namespace Gof.Structural.Adapter
{
    public static class PersistentList
    {
        public static Cons<T> Of<T>(params T[] items)
        {
            Cons<T> iter(Cons<T> tail, int index)
            {
                if (index >= items.Length)
                    return tail;
                return iter(new Cons<T>(items[index], tail), ++index);
            }
            return iter(null, 0);
        }

        public class Cons<T> : Iterable<T>
        {
            public T Head { get; }
            public Cons<T> Tail { get; }

            public Cons(T head, Cons<T> tail)
            {
                Head = head;
                Tail = tail;
            }

            public Iterator<T> Iterator() => new ConsIterator<T>(this);
        }

        public class ConsIterator<T> : Iterator<T>
        {
            private  Cons<T> _origin;

            public ConsIterator(Cons<T> origin) => _origin = origin;

            public bool HasNext() => _origin is null;

            public T Next()
            {
                if (_origin is null)
                    throw new IndexOutOfRangeException();
                var item = _origin.Head;
                _origin = _origin.Tail;
                return item;
            }
        }
    }
}
