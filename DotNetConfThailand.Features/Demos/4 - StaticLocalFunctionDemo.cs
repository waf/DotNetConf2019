using System;
using System.Linq;

namespace DotNetConfThailand.Features.Demos
{
    class StaticLocalFunctionDemo
    {
        public static void Demo()
        {
            ValidateConferenceTalk("What's new in C# 8");
            ValidateConferenceTalk("Azure Services Every .NET Developer Needs to Know");
        }

        private static bool ValidateConferenceTalk(string name)
        {
            var bannedTalk = new[] { "Don't write tests", "Let's all use the dynamic keyword"};

            return name != null
                && IsNameLongEnough(name)
                && !IsBannedTalk(name);

            bool IsNameLongEnough(string name) => name.Length > 3;
            bool IsBannedTalk(string name) => bannedTalk.Contains(name.ToUpper());
        }
    }
}
