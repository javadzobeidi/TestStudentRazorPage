﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DataClassStudent;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using Microsoft.Extensions.DependencyInjection;   // CreateScope



using Microsoft.EntityFrameworkCore;

namespace WebClassStudent
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var host=  CreateWebHostBuilder(args).Build();


            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<ClassStudentDbContext>();
                   context.Database.Migrate();
                   DbInitializer.Initialize(context);

                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }







            host.Run();

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
               .UseStartup<Startup>().ConfigureKestrel((context, options) =>
               {
                   options.Limits.MaxConcurrentConnections = long.MaxValue;
                   options.Limits.MaxConcurrentUpgradedConnections = long.MaxValue;

               }).UseUrls("http://localhost:5050");






    }
}
