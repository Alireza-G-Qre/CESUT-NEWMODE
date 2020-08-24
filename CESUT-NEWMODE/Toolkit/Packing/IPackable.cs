using System.Collections.Concurrent;
using System.Collections.Generic;

namespace CESUT_NEWMODE.Toolkit.Packing
{

    internal interface IPackable
    {

        ConcurrentDictionary<string, object> Pack();

        void Dpkg(ConcurrentDictionary<string, object> dic);

        string GetId();

        string Init_ID();
    }
}
