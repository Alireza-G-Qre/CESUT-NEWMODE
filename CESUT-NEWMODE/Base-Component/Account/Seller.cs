﻿using System.Linq;
using System;
using CESUT_NEWMODE.Base_Component.Product;
using CESUT_NEWMODE.Base_Component.Account_Component;
using System.Collections.Generic;
using System.Collections.Concurrent;
using CESUT_NEWMODE.Toolkit.ConcurrentDic;

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

            public override ConcurrentDictionary<string, object> Pack()
            {
                ConcurrentDictionary<string, object> cd = base.Pack();
                cd.TryAdd("personalInfo", PersonalInfo);
                cd.TryAdd("companyInfo", CompanyInfo);
                cd.TryAdd("ProductOfMe.ids", ProductOfMe.Keys);
                cd.TryAdd("PuchaseLogs.ids", PuchaseLogs.Keys);
                return cd;
            }

            public override void Dpkg(ConcurrentDictionary<string, object> dic)
            {
                base.Dpkg(dic);
                dic.TryGetValue("personalInfo", out object pi);
                PersonalInfo = pi as ConcurrentDictionary<Personals, string>;
                dic.TryGetValue("managerAccess", out object ci);
                CompanyInfo = ci as ConcurrentDictionary<CompanyIf, string>;
                dic.TryGetValue("ProductOfMe.ids", out object pmi);
                ProductOfMe = ConcurrentDic.ToDictionary<string, string, ProductObj>(
                    (pmi as ICollection<string>),
                    key => key,
                    key => ProductObj.getProductObjById(key)
                    );
                dic.TryGetValue("PuchaseLogs.ids", out object pli);
                PuchaseLogs = ConcurrentDic.ToDictionary<string, string, PurchaseLog>(
                    (pli as ICollection<string>),
                    key => key,
                    key => PurchaseLog.GetPurchaseLogById(key)
                    );
            }
        }

        internal enum CompanyIf
        {
            COM_BRAND,
            COM_PHONE,
            COM_EMAIL,
            COM_ADDRE,
            //...
        }

        private static ConcurrentDictionary<CompanyIf, string> InitCompanyInfo()
        {
            return new ConcurrentDictionary<CompanyIf, string>()
            {
                [CompanyIf.COM_BRAND] = "UNKNOWN",
                [CompanyIf.COM_EMAIL] = "UNKNOWN",
                [CompanyIf.COM_EMAIL] = "UNKNOWN",
                [CompanyIf.COM_ADDRE] = "UNKNOWN",
            };
        }

        private static ConcurrentDictionary<string, PurchaseLog> InitPuchaseLogsOfMe()
        {
            return new ConcurrentDictionary<string, PurchaseLog>()
            {
                //...
            };
        }

        private static ConcurrentDictionary<string, ProductObj> InitProductOfMe()
        {
            return new ConcurrentDictionary<string, ProductObj>()
            {
                //...
            };
        }

    }
}
