using System;

namespace Gof.Structural.Proxy.ProtectionProxy
{
    public class FolderProxy : IFolder
    {
        private readonly IFolder _folder;
        private readonly Privilege _privilege;

        public FolderProxy(Privilege privilege)
        {
            _folder = new Folder();
            _privilege = privilege;
        }

        public bool Create(string fileName)
        {
            if (_privilege.HasFlag(Privilege.WriteOnly))
                return _folder.Create(fileName);
            throw new InvalidOperationException();
        }

        public bool Delete(string fileName)
        {
            if (_privilege.HasFlag(Privilege.WriteOnly))
                return _folder.Delete(fileName);
            throw new InvalidOperationException();
        }

        public bool Rename(string oldName, string newName)
        {
            if (_privilege.HasFlag(Privilege.WriteOnly))
                return _folder.Rename(oldName, newName);
            throw new InvalidOperationException();
        }

        public string ShowAll(string sep)
        {
            if (_privilege.HasFlag(Privilege.ReadOnly))
                return _folder.ShowAll(sep);
            throw new InvalidOperationException();
        }
    }
}
