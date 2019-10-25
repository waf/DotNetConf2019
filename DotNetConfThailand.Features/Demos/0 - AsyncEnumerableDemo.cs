using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetConfThailand.Features.Demos
{
    class AsyncEnumerableDemo
    {
        private static async IAsyncEnumerable<string> GetConferenceTalksAsync()
        {
            for (int page = 1; page <= 4; page++)
            {
                IEnumerable<string> talks = await ConferenceTalkWebServiceAsync(page); 

                foreach(string talk in talks)
                {
                    yield return talk;
                }
            }
        }

        public static async Task Demo()
        {
            await foreach(var talk in GetConferenceTalksAsync())
            {
                Console.WriteLine($"I <3 {talk}");
            }
        }




        // before C# 8...
        private static IEnumerable<Task<IEnumerable<string>>> GetConferenceTalks()
        {
            return Enumerable
                .Range(1, 4)
                .Select(page => ConferenceTalkWebServiceAsync(page));
        }

        public static async Task Demo2()
        {
            foreach (var pageTask in GetConferenceTalks())
            {
                var page = await pageTask;
                foreach (var talk in page)
                {
                    Console.WriteLine($"I <3 {talk}");
                }
            }
        }




        /// <summary>
        /// A fake webservice that pretends to load conference talks by page.
        /// Conference talks are separated into pages by snack break.
        /// </summary>
        private static async Task<IEnumerable<string>> ConferenceTalkWebServiceAsync(int page)
        {
            await Task.Delay(2000); // simulate asynchronous network call
            return ConferenceTalks[$"Page {page}"];
        }

        private static readonly IReadOnlyDictionary<string, string[]> ConferenceTalks = new Dictionary<string, string[]>()
        {
            ["Page 1"] = new[] { "Welcome", "Opening Keynote", "What's new in C# 8" },
            ["Page 2"] = new[] { "Functional Programming with F#", "The Long Hard Road from .NET Framework to .NET Core" },
            ["Page 3"] = new[] { "Scott Hanselman Special Video + Sponsor Lightning Talk", "DevOps for the .NET Developer", "Blazor and Azure Functions for Serverless Websites", "Creating Libra Cryptocurrency Wallet using .NET SDK", "Xamarin.Forms: More Productive and Beautiful Than Ever ", "Azure Services Every .NET Developer Needs to Know" },
            ["Page 4"] = new[] { "ASP.NET Core & Entity Framework Core 3.0 and beyond", "Awesome games with .NET, Visual Studio 2019 and Unity 2019", "What's new in ML.NET", "Closing Remarks/Gifts/Networking" }
        };
    }
}
