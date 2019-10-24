namespace Gof.Behavioral.ChainOfResponsibility
{
    public abstract class Middleware
    {
        private Middleware _next;

        public Middleware LinkWith(Middleware next)
        {
            _next = next;
            return next;
        }

        public abstract bool Check(string datum);

        protected bool PassNext(string datum)
        {
            if (_next is null) return false;
            return _next.Check(datum);
        }
    }
}
