using System.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using CESUT_NEWMODE.Toolkit.IDHandler;
using CESUT_NEWMODE.Toolkit.Packing;

namespace CESUT_NEWMODE.Base_Component.Account_Component
{
    internal class Wallet : IPackable
    {
        public static List<Wallet> AllWallets { get; set; }

        public static Wallet GetWalletByID(string id)
        {
            return AllWallets.AsParallel().Where(a => a.WalletId.Equals(id))
                        .SingleOrDefault(null);
        }

        public string WalletId { get; private set; }

        public double SrcBalance { get; private set; } = Primitives.baseBalance;

        public double MinBalance { get; private set; } = Primitives.minBalance;

        public string GetId() => WalletId;

        public string Init_ID() => IDHandler.Init_ID<Wallet>(AllWallets);

        public ConcurrentDictionary<string, object> Pack()
        {
            return new ConcurrentDictionary<string, object>()
            {
                ["walletid"] = null,
                ["balance"] = null,
                ["minbalance"] = null,
                //...
            };
        }

        public void Dpkg(ConcurrentDictionary<string, object> dic)
        {
            //...
        }

        internal static class Primitives
        {
            public static double baseBalance { get; set; } = 0;

            public static double minBalance { get; set; } = 0;

        }

    }
}
