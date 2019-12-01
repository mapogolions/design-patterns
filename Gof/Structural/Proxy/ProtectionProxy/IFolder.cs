namespace Gof.Structural.Proxy.ProtectionProxy
{
    public interface IFolder
    {
        bool Create(string fileName);
        bool Delete(string fileName);
        bool Rename(string oldName, string newName);
        string ShowAll(string sep);
    }
}
