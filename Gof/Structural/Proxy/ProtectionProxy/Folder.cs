using System.Collections.Generic;

namespace Gof.Structural.Proxy.ProtectionProxy
{
    public class Folder : IFolder
    {
        private readonly IList<string> _files = new List<string>();

        public bool Create(string fileName)
        {
            if (_files.Contains(fileName))
                return false;
            _files.Add(fileName);
            return true;
        }

        public bool Delete(string fileName)
        {
            if (!_files.Contains(fileName))
                return false;
            _files.Remove(fileName);
            return true;
        }

        public bool Rename(string oldName, string newName)
        {
            if (!_files.Contains(oldName) || _files.Contains(newName))
                return false;
            _files.Remove(oldName);
            _files.Add(newName);
            return true;
        }

        public string ShowAll(string sep) => string.Join(sep, _files);
    }
}
