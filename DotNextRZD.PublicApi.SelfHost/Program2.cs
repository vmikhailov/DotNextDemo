using System;
using System.Diagnostics;
using System.Net.Http;
using Microsoft.Owin.Hosting;

namespace DotNextRZD.PublicApi.SelfHost
{
    internal class Program2
    {
        private static void Main1(string[] args)
        {
            var baseAddress = "http://localhost:9000/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(baseAddress))
            {
                Console.WriteLine("Host started. Press any key to warp up");
                Console.ReadLine();
            }

            Console.ReadLine();
        }
    }
}