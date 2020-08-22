using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Cities
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();


            // CreateWebHostBuilder()
            // etc
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
                        // WebHost.CreateDefaultBuilder(args)
                        //     .UseStartup<Startup>();

                        new WebHostBuilder()
                            .UseUrls("http://*:5000")
                            .UseKestrel()
                            .UseStartup<Startup>();
    }
}
