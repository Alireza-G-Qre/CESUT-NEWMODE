using CESUT_NEWMODE.Toolkit.IDHandler;
using System.Collections.Generic;
using System.Linq;

namespace CESUT_NEWMODE.Base_Component.Account_Component
{
    class CLog : Log
    {
        public static List<CLog> AllCLogs { get; private set; }

        public static CLog GetPLogByID(string id)
        {
            return AllCLogs.AsParallel().Where(a => a.LogId.Equals(id))
                        .SingleOrDefault(null);
        }

        public override string Init_ID() => IDHandler.Init_ID<CLog>(AllCLogs);
    }
}
