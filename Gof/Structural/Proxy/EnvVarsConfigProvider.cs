using System;
using System.Collections;
using System.Collections.Generic;

namespace Gof.Structural.Proxy
{
    public class EnvVarsConfigProvider : IConfigProvider
    {
        private readonly string _prefix;
        private readonly IDictionary<string, string> _data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public EnvVarsConfigProvider(string prefix) => _prefix = prefix;

        public void Set(string key, string value) => _data[key] = value;

        public bool TryGet(string key, out string value) => _data.TryGetValue(key, out value);

        public void Load() => Load(Environment.GetEnvironmentVariables());

        internal void Load(IDictionary envVars)
        {
            IDictionaryEnumerator e = envVars.GetEnumerator();
            try
            {
                while (e.MoveNext())
                {
                    DictionaryEntry entry = e.Entry;
                    string key = (string)entry.Key;
                    if (!key.StartsWith(_prefix, StringComparison.OrdinalIgnoreCase)) continue;
                    _data[key.Substring(_prefix.Length)] = entry.Value as string;
                }
            }
            finally
            {
                (e as IDisposable)?.Dispose();
            }
        }
    }
}
