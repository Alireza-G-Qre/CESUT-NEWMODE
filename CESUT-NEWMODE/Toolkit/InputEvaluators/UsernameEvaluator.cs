using System.Linq;
using System;
using System.Text.RegularExpressions;
using CESUT_NEWMODE.Toolkit.InvalidInputs;

namespace CESUT_NEWMODE.Toolkit.InputEvaluators
{

    internal class UsernameEvaluator
    {

        private static InvalidUsername invalids = new InvalidUsername("");

        public static void CheckUsername(string username)
        {
            if (!Regex.IsMatch(username, "^" + "\\w{6,100}" + "$"))
                throw new Exception($"Usrename:{username} is invalid.");

            bool check = invalids.InvalidList
                .Select(str => str.ToLower())
                .Any(str => str.Equals(username.ToLower()));

            if (check) throw new Exception($"Usrename:{username} is not appropriate.");
        }

        internal class InvalidUsername : InputChecker
        {
            public InvalidUsername(string keyMode) : base(keyMode)
            {
                invalids = this;
            }
        }
    }
}
