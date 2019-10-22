using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DotNetConfThailand.Features.Demos
{
    class UsingStatementDemo
    {
        public static async Task Demo()
        {
            Console.WriteLine("creating HTTP client");
            using (var http = new HttpClient())
            {
                Console.WriteLine("starting download stream");
                using (var downloadStream = await http.GetStreamAsync("https://wiki.mozilla.org/images/f/ff/Example.json.gz"))
                {
                    Console.WriteLine("starting output file stream");
                    using (var tempFileStream = File.Create("data.json"))
                    {
                        Console.WriteLine("starting gzip decompression stream");
                        using (var decompressionStream = new GZipStream(downloadStream, CompressionMode.Decompress))
                        {
                            Console.WriteLine("beginning stream copy");
                            decompressionStream.CopyTo(tempFileStream);
                        }
                    }
                }
            }
        }
    }
}
