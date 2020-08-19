using System.Collections.Concurrent;

namespace CESUT_NEWMODE.Toolkit.Packing
{
    internal interface IPackable
    {
        ConcurrentDictionary<string, object> Pack();

        void Dpkg(ConcurrentDictionary<string, object> dic);

        string GetId();
    }
}
