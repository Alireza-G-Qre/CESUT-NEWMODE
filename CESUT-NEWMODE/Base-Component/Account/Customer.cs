using System;
using CESUT_NEWMODE.Base_Component.Account_Component;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;

namespace CESUT_NEWMODE.Base_Component.Account
{
    class Customer : Account
    {
        public static List<Customer> AllCustomers { get; set; }

        public static Account GetCustomerBy(string key, string mode = "id")
        {
            switch (mode)
            {
                case "id":
                    return GetById(AllCustomers, key);

                case "username":
                    return GetByUser(AllCustomers, key);

                default:
                    throw new Exception($"Mode:{mode} is not invalid.");
            }
        }

        public new MiniCustomer Mini { get; private set; }

        public Customer(MiniCustomer mini) : base(mini)
        {
            Mini = mini;
        }

        internal class MiniCustomer : MiniAccount
        {
            public MiniCustomer()
            {
                PersonalInfo = InitPersonalInfo();
                PuchaseLogs = InitPuchaseLogsOfMe();
            }

            public ConcurrentDictionary<Personals, string> PersonalInfo { get; private set; }

            public ConcurrentDictionary<string, PurchaseLog> PuchaseLogs { get; private set; }

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
