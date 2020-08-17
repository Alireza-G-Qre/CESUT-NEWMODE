using CESUT_NEWMODE.Toolkit.InvalidInputs;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CESUT_NEWMODE.Toolkit.InputEvaluators
{
    class PasswordEvaluator
    {
        private static InvalidPassword invalids = new InvalidPassword("");

        public static void CheckPassword(string password)
        {
            if (!Regex.IsMatch(password, "^" + "\\w{6,100}" + "$"))
                throw new Exception($"Password:{password} is invalid.");

            bool check = invalids.InvalidList
                .Select(str => str.ToLower())
                .Any(str => str.Equals(password.ToLower()));

            if (check) throw new Exception($"Password:{password} is not appropriate.");
        }

        internal class InvalidPassword : InputChecker
        {
            public InvalidPassword(string keyMode) : base(keyMode)
            {
                invalids = this;
            }
        }
    }
}
