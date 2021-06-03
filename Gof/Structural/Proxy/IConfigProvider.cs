namespace Gof.Structural.Proxy
{
    public interface IConfigProvider
    {
        bool TryGet(string key, out string value);
        void Set(string key, string value);
        void Load();
    }
}
