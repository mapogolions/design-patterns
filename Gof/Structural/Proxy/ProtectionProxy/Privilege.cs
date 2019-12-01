using System;

namespace Gof.Structural.Proxy.ProtectionProxy
{
    [Flags]
    public enum Privilege
    {
        ReadOnly = 1,
        WriteOnly = 2
    }
}
