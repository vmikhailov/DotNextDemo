using System;
using System.Diagnostics;
using System.Net.Http;
using Microsoft.Owin.Hosting;

namespace DotNextRZD.PublicApi.SelfHost
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var baseAddress = "http://localhost:9000/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(baseAddress))
            {
                Console.WriteLine("Host started. Press any key to warp up");
                Console.ReadLine();
                // Create HttpCient and make a request to api/values 
                var client = new HttpClient();

                var response1 = client.GetAsync(baseAddress + "/routes").Result;
                Console.WriteLine(response1);
                Console.WriteLine(response1.Content.ReadAsStringAsync().Result);

                var response2 = client.GetAsync(baseAddress + "/trains").Result;
                Console.WriteLine(response2);

                Console.WriteLine("Ready to start measure");
                Console.ReadLine();

                var sw = Stopwatch.StartNew();
                int n = 1000;
                for (int i = 0; i < n; i++)
                {
                    var addr = string.Format("{0}/trains/{1}", baseAddress, (i+1) % 15);
                    var response = client.GetAsync(addr).Result;
                    if (i%10 == 0)
                    {
                        Console.Write(".");
                    }
                }
                sw.Stop();
                Console.WriteLine("{0} calls in {1}ms. {2}ms per call", n, sw.ElapsedMilliseconds, sw.ElapsedMilliseconds / n);
            }

            Console.ReadLine();
        }
    }
}