using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetConfThailand.Features.Demos
{
    class AsyncEnumerableDemo
    {
        // conference sessions, separated by snack breaks
        // pretend this is a webservice that returns 1 page of data per call.
        private static readonly IReadOnlyDictionary<string, string[]> ConferenceSessions = new Dictionary<string, string[]>()
        {
            ["Page 1"] = new[] { "Welcome", "Opening Keynote", "What's new in C# 8" },
            ["Page 2"] = new[] { "Functional Programming with F#", "The Long Hard Road from .NET Framework to .NET Core" },
            ["Page 3"] = new[] { "Scott Hanselman Special Video + Sponsor Lightning Talk", "DevOps for the .NET Developer", "Blazor and Azure Functions for Serverless Websites", "Creating Libra Cryptocurrency Wallet using .NET SDK", "Xamarin.Forms: More Productive and Beautiful Than Ever ", "Azure Services Every .NET Developer Needs to Know" },
            ["Page 4"] = new[] { "ASP.NET Core & Entity Framework Core 3.0 and beyond", "Awesome games with .NET, Visual Studio 2019 and Unity 2019", "What's new in ML.NET", "Closing Remarks/Gifts/Networking" }
        };

        private static async IAsyncEnumerable<string> GetConferenceSessionsAsync()
        {
            foreach(var (page, sessions) in ConferenceSessions)
            {
                await Task.Delay(2000); // simulate asynchronous network call

                foreach(string session in sessions)
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




        // before C# 8...
        private static IEnumerable<Task<IEnumerable<string>>> GetConferenceSessions()
        {
            return ConferenceSessions
                .Select(async kvp =>
                {
                    await Task.Delay(2000); // simulate asynchronous network call
                    return kvp.Value.AsEnumerable();
                });
        }

        public static async Task Demo2()
        {
            foreach (var pageTask in GetConferenceSessions())
            {
                var page = await pageTask;
                foreach (var session in page)
                {
                    Console.WriteLine($"I <3 {session}");
                }
            }
        }
    }
}
