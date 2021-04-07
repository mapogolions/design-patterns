namespace Gof.Creational.Singleton
{
    public class EagerSingleton
    {
        private static readonly EagerSingleton _instance;

        private EagerSingleton() { }

        public static EagerSingleton Singleton => _instance;
    }
}
