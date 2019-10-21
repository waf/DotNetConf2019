using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetConf2019.Features.Demos
{
    class StaticLocalFunctionFeature
    {
        public static void Demo()
        {
            string[] users = { "Mark", "Bob" };
            ValidateUsername("Mark");
            ValidateUsername("Bob");
        }

        private static bool ValidateUsername(string username)
        {
            var bannedUsers = new[] { "JOE", "BOB", "JANE" };

            return username != null
                && IsNameLongEnough(username)
                && !IsBannedUser(username);

            bool IsNameLongEnough(string name) => name.Length > 1;
            bool IsBannedUser(string n) => bannedUsers.Contains(n.ToUpper());
        }
    }
}
