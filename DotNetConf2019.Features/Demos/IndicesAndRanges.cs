using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetConf2019.Features.Demos
{
    class IndicesAndRanges
    {
        public static void Demo()
        {
            string[] editors = {
                "Visual Studio",
                "VS Code",
                "Vim",
                "JetBrains Rider"
            };

            // first
            Print(editors[0]);

            // last
            Print(editors[^1]);

            // first two
            Print(editors[0..2]);

            // last two
            Print(editors[2..^0]);

            // all but first
            Print(editors[1..]);

            // all but last
            Print(editors[..^1]);

            // all 
            Print(editors[..]);

           
            // ranges are just data
        }

        private static void Print(params string[] args) =>
            Console.WriteLine(string.Join(", ", args));
    }
}
