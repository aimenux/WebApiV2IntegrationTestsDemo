using Microsoft.Owin.Hosting;
using System;

namespace Example06
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            const string url = "http://localhost:9000/";

            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine($"Application is running on host 8{url}");
                Console.WriteLine("Press any key to terminate...");
                Console.ReadLine();
            }
        }
    }
}
