using System.Threading;

namespace Gof.Creational.Singleton
{
    // Have borrowed here: https://github.com/dotnet/runtime/blob/main/src/libraries/Microsoft.Extensions.Options/src/UnnamedOptionsManager.cs
    /**
        We run into this every time we use the options pattern in .net
        public class Service
        {
            public Service(IOptions<ServiceOptions> options)
            {
                ... options.Value
            }
        }
    **/
    public class CompareAndExchangeLockSingleton
    {
        private static CompareAndExchangeLockSingleton _instance;
        private static object _lockObj;

        private CompareAndExchangeLockSingleton() { }

        public static CompareAndExchangeLockSingleton Singleton
        {
            get
            {
                if (_instance is not null)
                {
                    return _instance;
                }
                lock(_lockObj ?? Interlocked.CompareExchange(ref _lockObj, value: new object(), comparand: null) ?? _lockObj)
                {
                    _instance ??= new CompareAndExchangeLockSingleton();
                    return _instance;
                    // if (_instance is null)
                    // {
                    //     _instance = new CompareAndExchangeLockSingleton();
                    // }
                }
            }
        }
    }
}
