using System;

namespace Gof.Structural.Adapter
{

    public class Cons<T> : Iterable<T>
    {
        public virtual T Head { get; }
        public virtual Cons<T> Tail { get; }

        public Cons(T head, Cons<T> tail)
        {
            Head = head;
            Tail = tail;
        }

        public Iterator<T> Iterator() => new ConsIterator<T>(this);
    }

    public static class Nil
    {
        public static Nil<T> New<T>() => Nil<T>.GetInstance();
    }

    public class Nil<T> : Cons<T>
    {
        private static Nil<T> _instance;

        private Nil() : base(default(T), null) {}

        public static Nil<T> GetInstance()
        {
            if (_instance is null)
                _instance = new Nil<T>();
            return _instance;
        }

        public override T Head => throw new InvalidOperationException();
        public override Cons<T> Tail => throw new InvalidOperationException();
    }

    public class ConsIterator<T> : Iterator<T>
    {
        private  Cons<T> _origin;

        public ConsIterator(Cons<T> origin) => _origin = origin;

        public bool HasNext() => _origin is Cons<T> _;

        public T Next()
        {
            if (_origin is Nil<T> _)
                throw new IndexOutOfRangeException();
            var item = _origin.Head;
            _origin = _origin.Tail;
            return item;
        }
    }
}
