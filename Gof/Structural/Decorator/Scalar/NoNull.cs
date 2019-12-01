using System;

namespace Gof.Structural.Decorator.Scalar
{
    public class NoNull<T> : IScalar<T>
    {
        private readonly IScalar<T> _origin;

        public NoNull(IScalar<T> origin) => _origin = origin;

        public T Value
        {
            get
            {
                if (_origin == null)
                    throw new ArgumentNullException($"Null instead of a valid scalar");
                var result = _origin.Value;
                if (result == null)
                    throw new ArgumentNullException($"Null instead of a valid scalar");
                return result;
            }
        }
    }
}
