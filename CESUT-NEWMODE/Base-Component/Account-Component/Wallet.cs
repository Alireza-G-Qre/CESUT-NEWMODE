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

        public string WalletId { get; private set; }

        public double SrcBalance { get; private set; } = Primitives.baseBalance;

        public double MinBalance { get; private set; } = Primitives.minBalance;

        public string GetId() => WalletId;

        public string Init_ID() => IDHandler.Init_ID<Wallet>(AllWallets);

        public ConcurrentDictionary<string, object> Pack()
        {
            return new ConcurrentDictionary<string, object>()
            {
                ["walletid"] = WalletId,
                ["balance"] = SrcBalance.ToString(),
                ["minbalance"] = MinBalance.ToString(),
                //...
            };
        }

        public void Dpkg(ConcurrentDictionary<string, object> dic)
        {
            dic.TryGetValue("walletid", out object wi);
            WalletId = wi as string;
            dic.TryGetValue("balance", out object bl);
            SrcBalance = Double.Parse(bl as string);
            dic.TryGetValue("minbalance", out object mbl);
            MinBalance = Double.Parse(mbl as string);
        }

        internal static class Primitives
        {
            public static double baseBalance { get; set; } = 0;

            public static double minBalance { get; set; } = 0;

        }

    }
}
