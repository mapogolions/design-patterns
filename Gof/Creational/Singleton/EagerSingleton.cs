namespace Gof.Creational.Singleton;

public class EagerSingleton
{
    private static readonly EagerSingleton _instance = new();

    private EagerSingleton() { }

    public static EagerSingleton Singleton => _instance;
}
