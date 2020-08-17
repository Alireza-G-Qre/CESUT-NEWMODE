using System;
using System.Collections.Generic;
using System.Text;

namespace CESUT_NEWMODE.Toolkit.Packing
{
    internal interface IPackable
    {
        Dictionary<string, object> Pack();
        void Dpkg(Dictionary<string, object> dic);
        string GetId();
    }
}
