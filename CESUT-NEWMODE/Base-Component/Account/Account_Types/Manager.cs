using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace CESUT_NEWMODE.Base_Component.Account
{
    internal partial class Manager : Account
    {
        public static List<Manager> AllManagers { get; set; }

        public static Manager GetManagerBy(string key, string mode = "id")
        {
            switch (mode)
            {
                case "id":
                    return GetById(AllManagers, key);

                case "username":
                    return GetByUser(AllManagers, key);

                default:
                    throw new Exception($"Mode:{mode} is not invalid.");
            }
        }

        public new MiniManager Mini { get; private set; }

        public Manager(MiniManager mini) : base(mini)
        {
            Mini = mini;
        }

        internal class MiniManager : MiniAccount
        {
            public MiniManager()
            {
                PersonalInfo = InitPersonalInfo();
                ManagerAccess = InitManagerAccess();
            }

            public ConcurrentDictionary<Personals, string> PersonalInfo { get; private set; }

            public ConcurrentDictionary<Access, bool> ManagerAccess { get; private set; }

            public override ConcurrentDictionary<string, object> Pack()
            {
                ConcurrentDictionary<string, object> cd = base.Pack();
                cd.TryAdd("personalInfo", null);
                cd.TryAdd("managerAccess", null);
                return cd;
            }

            public override void Dpkg(ConcurrentDictionary<string, object> dic)
            {
                //...
            }

        }

        internal enum Access
        {
            ADD_MANAGER,
            DELETE_SUPPORTER,
            ADD_SUPPORTER,
            DELETE_MANAGER,
            DELETE_CUSTOMER,
            DELETE_SELLER,
            //...
        }

        private static ConcurrentDictionary<Access, bool> InitManagerAccess()
        {
            return new ConcurrentDictionary<Access, bool>()
                {
                     [Access.ADD_MANAGER] = false ,
                     [Access.DELETE_SUPPORTER] = false ,
                     [Access.ADD_SUPPORTER] = false ,
                     [Access.DELETE_MANAGER] = false ,
                     [Access.DELETE_CUSTOMER] = false ,
                     [Access.DELETE_SELLER] = false
                };
        }
    }
}
