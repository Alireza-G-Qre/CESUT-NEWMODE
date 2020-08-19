using System;
using CESUT_NEWMODE.Base_Component.Product;
using CESUT_NEWMODE.Base_Component.Account_Component;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace CESUT_NEWMODE.Base_Component.Account
{
    internal class Seller : Account
    {
        public static List<Seller> AllSellers { get; set; }

        public static Seller GetSellerBy(string key, string mode = "id")
        {
            switch (mode)
            {
                case "id":
                    return GetById(AllSellers, key);

                case "username":
                    return GetByUser(AllSellers, key);

                default:
                    throw new Exception($"Mode:{mode} is not invalid.");
            }
        }

        public new MiniSeller Mini { get; private set; }

        public Seller(MiniSeller mini) : base(mini)
        {
            Mini = mini;
        }

        internal class MiniSeller : MiniAccount
        {
            public MiniSeller()
            {
                PersonalInfo = InitPersonalInfo();
                CompanyInfo = InitCompanyInfo();
                ProductOfMe = InitProductOfMe();
                PuchaseLogs = InitPuchaseLogsOfMe();
            }

            public ConcurrentDictionary<Personals, string> PersonalInfo { get; private set; }

            public ConcurrentDictionary<CompanyIf, string> CompanyInfo { get; private set; }

            public ConcurrentDictionary<string, ProductObj> ProductOfMe { get; private set; }

            public ConcurrentDictionary<string, PurchaseLog> PuchaseLogs { get; private set; }
        }

        internal enum CompanyIf
        {
            COM_BRAND,
            COM_PHONE,
            COM_EMAIL,
            COM_ADDRE,
            //...
        }

        public static ConcurrentDictionary<CompanyIf, string> InitCompanyInfo()
        {
            return new ConcurrentDictionary<CompanyIf, string>()
            {
                [CompanyIf.COM_BRAND] = "UNKNOWN",
                [CompanyIf.COM_EMAIL] = "UNKNOWN",
                [CompanyIf.COM_EMAIL] = "UNKNOWN",
                [CompanyIf.COM_ADDRE] = "UNKNOWN",
            };
        }

        public static ConcurrentDictionary<string, ProductObj> InitProductOfMe()
        {
            return new ConcurrentDictionary<string, ProductObj>()
            {
                //...
            };
        }

        public static ConcurrentDictionary<string, PurchaseLog> InitPuchaseLogsOfMe()
        {
            return new ConcurrentDictionary<string, PurchaseLog>()
            {
                //...
            };
        }
    }
}
