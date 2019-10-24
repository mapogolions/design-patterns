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

        public abstract bool Check(string email, string password);

        protected bool PassNext(string email, string password)
        {
            if (_next is null) return false;
            return _next.Check(email, password);
        }
    }
}
