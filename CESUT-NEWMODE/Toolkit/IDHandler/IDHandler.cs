using CESUT_NEWMODE.Toolkit.Packing;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CESUT_NEWMODE.Toolkit.IDHandler
{
    internal static class IDHandler
    {
        public static string Init_ID<T>(List<T> pks) where T : IPackable 
            => (pks.Max(pk => long.Parse(pk.GetId())) + 1).ToString();
    }
}
