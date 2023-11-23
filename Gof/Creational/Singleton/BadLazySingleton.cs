namespace Gof.Creational.Singleton
{
    public class BadLazySingleton
    {
        private static BadLazySingleton? _instance;
        private static readonly object _lock = new();

        private BadLazySingleton() { }

        public static BadLazySingleton Singleton
        {
            get
            {
                lock(_lock)
                {
                    _instance ??= new BadLazySingleton();
                }
                return _instance;
            }
        }
    }
}
