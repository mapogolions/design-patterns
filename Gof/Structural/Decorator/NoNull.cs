using System;
namespace Gof.Structural.Decorator
{
    public class NoNull<T> : Scalar<T>
    {
        private readonly Scalar<T> _origin;

        public NoNull(Scalar<T> origin) => _origin = origin;

        public T Value
        {
            get
            {
                if (_origin == null)
                    throw new ArgumentNullException("Null instead of a valid scalar");
                var result = _origin.Value;
                if (result == null)
                    throw new ArgumentNullException("Null instead of a valid scalar");
                return result;
            }
        }
    }
}
