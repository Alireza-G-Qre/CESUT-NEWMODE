using CESUT_NEWMODE.Toolkit.Packing;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System;
using CESUT_NEWMODE.Toolkit.InputEvaluators;
using CESUT_NEWMODE.Toolkit.IDHandler;

namespace CESUT_NEWMODE.Base_Component.Account
{
    internal abstract class Account
    {
        public static List<Account> AllAccounts { get; set; }

        public static Account GetAccountBy(string key, string mode = "id")
        {
            switch (mode)
            {
                case "id":
                    return GetById(AllAccounts, key);

                case "username":
                    return GetByUser(AllAccounts, key);

                default:
                    throw new Exception($"Mode:{mode} is not invalid.");
            }
        }

        protected static T GetById<T>(List<T> list, string key) where T : Account
        {
            return list.AsParallel().Where(a => a.Mini.AccountId.Equals(key))
                        .SingleOrDefault(null);
        }

        protected static T GetByUser<T>(List<T> list, string key) where T : Account
        {
            return list.AsParallel().Where(a => a.Mini.Username.Equals(key))
                        .SingleOrDefault(null);
        }

        public MiniAccount Mini { get; private set; }

        public Account(MiniAccount mini)
        {
            Mini = mini;
        }

        internal abstract class MiniAccount : IPackable
        {

            public MiniAccount()
            {
                
            }

            private string _username;

            public string Username
            {
                get { return _username; }
                set
                {
                    UsernameEvaluator.CheckUsername(value);
                    _username = value;
                }
            }

            private string _password;

            public string Password
            {
                get { return _password; }
                set
                {
                    PasswordEvaluator.CheckPassword(value);
                    _password = value;
                }
            }

            public string AccountId { get; private set; }

            public string usrClazz { get; private set; }

            public string CartId { get; private set; }

            public string Wallet { get; private set; }

            public string LogsId { get; private set; }

            public virtual ConcurrentDictionary<string, object> Pack()
            {
                return new ConcurrentDictionary<string, object>()
                {
                    ["accountId"] = null,
                    ["username"] = null,
                    ["password"] = null,
                    ["usrClazz"] = null,
                    ["walletin"] = null,
                    ["mycartin"] = null,
                    ["mylogsin"] = null,
                    //...
                };
            }

            public virtual void Dpkg(ConcurrentDictionary<string, object> dic)
            {
                //...
            }

            public string GetId() => AccountId;

            public string Init_ID() => IDHandler.Init_ID<MiniAccount>(
                AllAccounts.Select(account => account.Mini).ToList());
        }

        internal enum Personals
        {
            FIRST_NAME,
            LAST_NAME,
            EMAIL,
            PHONE_NUMBER,
            DTAE_OF_BIRTH,
            //...
        }

        internal enum UserClass
        {
            Legend,
            Super,
            Normal,
            Weak,
            Dead,
            //...
        }

        protected static ConcurrentDictionary<Personals, string> InitPersonalInfo()
        {
            return new ConcurrentDictionary<Personals, string>()
            {
                [Personals.FIRST_NAME] = "UNKNOWN ACCOUNT",
                [Personals.LAST_NAME] = "UNKNOWN ACCOUNT",
                [Personals.EMAIL] = "UNKNOWN ACCOUNT",
                [Personals.PHONE_NUMBER] = "UNKNOWN ACCOUNT",
                [Personals.DTAE_OF_BIRTH] = "UNKNOWN ACCOUNT",
            };
        }

    }
}
