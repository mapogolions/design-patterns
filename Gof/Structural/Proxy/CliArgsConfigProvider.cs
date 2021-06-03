using System;

namespace Gof.Structural.Proxy
{
    public class CliArgsConfigProvider : IConfigProvider
    {
        public bool TryGet(string key, out string value) => throw new System.NotImplementedException();
        public void Set(string key, string value) => throw new System.NotImplementedException();
        public void Load() => throw new NotImplementedException();
    }
}
