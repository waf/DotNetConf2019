using System;

namespace DotNetConfThailand.Features.Demos
{
    class IndicesAndRangesDemo
    {
        public static void Demo()
        {
            string[] talks = {
                "What's new in C# 8",
                "Functional Programming with F#",
                "The Long Hard Road from .NET Framework to .NET Core",
                "DevOps for the .NET Developer"
            };

            // first
            Print(talks[0]);

            // last
            Print(talks[^1]);

            // first two
            Print(talks[0..2]);

            // last two
            Print(talks[^2..^0]);

            // all but first
            Print(talks[1..]);

            // all but last
            Print(talks[..^1]);

            // all 
            Print(talks[..]);

            // ranges are just data
            Range range = 0..2;
            Print(talks[range]);
        }

        private static void Print(params string[] args) =>
            Console.WriteLine(string.Join(", ", args));
    }
}
