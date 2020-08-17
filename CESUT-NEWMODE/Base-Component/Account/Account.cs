using CESUT_NEWMODE.Base_Component.Account_Component;
using CESUT_NEWMODE.Toolkit.Packing;
using CESUT_NEWMODE.Toolkit.InputEvaluators;
using System.Collections.Generic;
using System.Linq;
using System;

namespace CESUT_NEWMODE.Base_Component.Account
{
    internal abstract class Account
    {
        public static List<Account> AllAccount { get; set; }

        public static Account GetAccountBy(string key, string mode)
        {
            switch (mode)
            {
                case "id":
                    return AllAccount.AsParallel().Where(a => a.Mini.AccountId.Equals(key))
                        .SingleOrDefault(null);

                case "username":
                    return AllAccount.AsParallel().Where(a => a.Mini.Username.Equals(key))
                        .SingleOrDefault(null);
        
                default:
                    throw new Exception($"Mode:{mode} is not invalid.");
            }
        }

        public MiniAccount Mini { get; private set; }

        internal class MiniAccount : IPackable
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

            public Dictionary<string, object> Pack()
            {
                return new Dictionary<string, object>()
                {
                    { "accountId", AccountId},
                    { "username", Username},
                    { "password", Password},
                    { "wallet.credit", Wallet.Credit},
                };
            }

            public void Dpkg(Dictionary<string, object> dic)
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
    }
}
