using System.Collections.Concurrent;
using System.Collections.Generic;
using CESUT_NEWMODE.Toolkit.Packing;

namespace CESUT_NEWMODE.Base_Component.Account_Component
{
    internal abstract class Log: IPackable
    {
        public string LogId { get; set; }

        public List<ConcurrentDictionary<string, object>> DataInLog { get; private set; }

        public string GetId() => LogId;

        public abstract string Init_ID();

        public ConcurrentDictionary<string, object> Pack()
        {
            return new ConcurrentDictionary<string, object>()
            {
                ["mlogid"] = null,
                ["datain"] = null,
                //...
            };
        }

        public void Dpkg(ConcurrentDictionary<string, object> dic)
        {
            //...
        }
    }
}
