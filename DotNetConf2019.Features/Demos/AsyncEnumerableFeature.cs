using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetConf2019.Features.Demos
{
    class AsyncEnumerableFeature
    {
        // conference sessions, separated by snack breaks
        private static readonly IReadOnlyCollection<IReadOnlyCollection<string>> ConferenceSessions = new[]
        {
            new[] { "Welcome", "Opening Keynote", "What's new in C# 8" },
            new[] { "Functional Programming with F#", "The Long Hard Road from .NET Framework to .NET Core" },
            new[] { "Scott Hanselman Special Video + Sponsor Lightning Talk", "DevOps for the .NET Developer", "Blazor and Azure Functions for Serverless Websites", "Creating Libra Cryptocurrency Wallet using .NET SDK", "Xamarin.Forms: More Productive and Beautiful Than Ever ", "Azure Services Every .NET Developer Needs to Know" },
            new[] { "ASP .NET Core & Entity Framework Core 3.0 and beyond", "Awesome games with .NET, Visual Studio 2019 and Unity 2019", "Whats new in ML.NET", "Closing Remarks/Gifts/Networking" }
        };

        private static async IAsyncEnumerable<string> GetConferenceSessionsAsync()
        {
            foreach(IReadOnlyCollection<string> period in ConferenceSessions)
            {
                await Task.Delay(2000); // simulate network call

                foreach(string session in period)
                {
                    yield return session;
                }
            }
        }

        public static async Task Demo()
        {
            await foreach(var session in GetConferenceSessionsAsync())
            {
                Console.WriteLine($"I <3 {session}");
            }
        }
    }
}
