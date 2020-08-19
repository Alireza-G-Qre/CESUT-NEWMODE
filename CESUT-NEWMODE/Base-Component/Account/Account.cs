using CESUT_NEWMODE.Toolkit.Packing;
using CESUT_NEWMODE.Toolkit.InputEvaluators;
using System.Collections.Generic;
using CESUT_NEWMODE.Base_Component.Account_Component;
using System.Collections.Concurrent;
using System.Linq;
using System;

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
                Wallet = new Wallet();
                Cart = new Cart();
                Logs = new Logs();
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

            public Cart Cart { get; private set; }

            public Wallet Wallet { get; private set; }

            public Logs Logs { get; private set; }

            public ConcurrentDictionary<string, object> Pack()
            {
                return new ConcurrentDictionary<string, object>()
                {
                    ["accountId"] = AccountId,
                    ["username"] =  Username,
                    ["password"] = Password,
                    ["wallet.credit"] = Wallet.Credit
                };
            }

            public void Dpkg(ConcurrentDictionary<string, object> dic)
            {
                dic.TryGetValue("accountId", out object a);
                AccountId = a as string;
                dic.TryGetValue("username", out object un);
                Username = un as string;
                dic.TryGetValue("password", out object pw);
                Password = pw as string;
                dic.TryGetValue("wallet.credit", out object wc);
                Wallet.Credit = Double.Parse(wc as string);
            }

            public string GetId() => AccountId;
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

        public static ConcurrentDictionary<Personals, string> InitPersonalInfo()
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
