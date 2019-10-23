using System;
using System.Linq;

namespace DotNetConfThailand.Features.Demos
{
    class StaticLocalFunctionDemo
    {
        public static void Demo()
        {
            ValidateUsername("Mark");
            ValidateUsername("Bob");
        }

        private static bool ValidateUsername(string name)
        {
            var bannedUsers = new[] { "JOE", "BOB", "JANE" };

            return name != null
                && IsNameLongEnough(name)
                && !IsBannedUser(name);

            bool IsNameLongEnough(string name) => name.Length > 1;
            bool IsBannedUser(string name) => bannedUsers.Contains(name.ToUpper());
        }
    }
}
