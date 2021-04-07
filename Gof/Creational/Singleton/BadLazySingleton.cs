namespace Gof.Creational.Singleton
{
    public class BadLazySingleton
    {
        private static BadLazySingleton _instance;

        private BadLazySingleton() { }

        public static BadLazySingleton Singleton
        {
            get
            {
                lock(_instance)
                {
                    if (_instance is null)
                    {
                        _instance = new BadLazySingleton();
                    }
                }
                return _instance;
            }
        }
    }
}
