using DotNetConf2019.Features.Demos;
using System;
using System.Threading.Tasks;

namespace DotNetConf2019.Features
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //await AsyncEnumerableFeature.Demo();
            IndicesAndRanges.Demo();
        }
    }
}
