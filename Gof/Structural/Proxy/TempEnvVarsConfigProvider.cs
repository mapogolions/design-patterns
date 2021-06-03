using System;
using System.Collections.Generic;

namespace Gof.Structural.Proxy
{
    public class TempEnvVarsConfigProvider : IConfigProvider, IDisposable
    {
        private readonly EnvVarsConfigProvider _configProvider;
        private readonly IDictionary<string, string> _tempEnvVars;

        public TempEnvVarsConfigProvider(IDictionary<string, string> tempEnvVars, string prefix = "")
        {
            _tempEnvVars = tempEnvVars;
            _configProvider = new(prefix);
        }

        public void Load()
        {
            foreach (var tempEnvVar in _tempEnvVars)
            {
                Environment.SetEnvironmentVariable(tempEnvVar.Key, tempEnvVar.Value);
            }
            _configProvider.Load();
        }

        public void Set(string key, string value) => _configProvider.Set(key, value);

        public bool TryGet(string key, out string value) => _configProvider.TryGet(key, out value);


        public void Dispose()
        {
            foreach (var tempEnvVar in _tempEnvVars)
            {
                Environment.SetEnvironmentVariable(tempEnvVar.Key, null);
            }
        }
    }
}
