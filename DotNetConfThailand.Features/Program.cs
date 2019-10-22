using System;
using DotNetConfThailand.Features.Demos;

namespace DotNetConfThailand.Features
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2
                || args[0] != "/demo"
                || !int.TryParse(args[1], out int demoNumber))
            {
                Console.WriteLine("Usage: DotNetConfThailand.Features.exe /demo n");
                Console.WriteLine($"       where n is an integer from 0 to {Demos.Length - 1}");
                return;
            }

            Demos[demoNumber]();
        }

        private static Action[] Demos =
        {
            () => AsyncEnumerableDemo.Demo().Wait(),
            PatternsDemo.Demo,
            IndicesAndRangesDemo.Demo,
            DefaultInterfaceMemberDemo.Demo,
            StaticLocalFunctionDemo.Demo,
            NullCoallescingAssignmentDemo.Demo,
            ReadOnlyMemberDemo.Demo,
            () => UsingStatementDemo.Demo().Wait()
        };
    }
}
