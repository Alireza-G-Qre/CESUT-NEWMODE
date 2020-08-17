using System;
using System.Collections.Generic;
using System.IO;

namespace CESUT_NEWMODE.Toolkit.InvalidInputs
{
    internal class InputChecker
    {
        public static Dictionary<string, string> Files { get; set; } = new Dictionary<string, string>()
        {
            { "1","1"},
            { "1","1"},
            { "1","1"}
        };

        public List<string> InvalidList { get; private set; }

        public InputChecker(string keyMode)
        {

            if (Files.TryGetValue(keyMode, out string fileAddress))
                InvalidList = new List<string>(collection: File.ReadAllLines(fileAddress));
            else
                throw new ArgumentOutOfRangeException(keyMode, "Invalid Key");
        }
    }
}
