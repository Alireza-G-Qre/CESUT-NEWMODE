using System.Linq;
using System.Collections.Generic;
using CESUT_NEWMODE.Toolkit.IDHandler;

namespace CESUT_NEWMODE.Base_Component.Account_Component
{
    internal class PLog : Log
    {
        public static List<PLog> AllPLogs { get; private set; }

        public static PLog GetPLogByID(string id)
        {
            return AllPLogs.AsParallel().Where(a => a.LogId.Equals(id))
                        .SingleOrDefault(null);
        }

        public override string Init_ID() => IDHandler.Init_ID<PLog>(AllPLogs);
    }
}
