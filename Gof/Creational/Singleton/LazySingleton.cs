namespace Gof.Creational.Singleton;

public class LazySingleton
{
    private static LazySingleton? _instance;
    private static readonly object _lock = new();

    private LazySingleton() { }

    public static LazySingleton Singleton
    {
        get
        {
            if (_instance is null)
            {
                lock(_lock)
                {
                    _instance ??= new LazySingleton();
                }
            }
            return _instance;
        }
    }
}
