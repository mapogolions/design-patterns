namespace Gof.Creational.Singleton
{
    public class LazySingleton
    {
        private static LazySingleton _instance;

        private LazySingleton() { }

        public static LazySingleton Singleton
        {
            get
            {
                if (_instance is null)
                {
                    lock(_instance)
                    {
                        if (_instance is null)
                        {
                            _instance = new LazySingleton();
                        }
                    }
                }
                return _instance;
            }
        }
    }
}
