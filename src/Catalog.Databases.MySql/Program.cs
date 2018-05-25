﻿using System;
using System.Configuration;
using System.Linq;
using System.Reflection;
using DbUp;

namespace Shop.Catalog.Databases.MySql
{
    public class Program
    {
        static int Main(string[] args)
        {
            // TODO: Use Core 2.0 configuration api
            var connectionString =
                args.FirstOrDefault()??ConfigurationManager.ConnectionStrings["catalog"].ConnectionString;

            EnsureDatabase.For.MySqlDatabase(connectionString);

            var upgrader =
                DeployChanges.To
                    .MySqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
#if DEBUG
                Console.ReadLine();
#endif
                return -1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
            return 0;
        }
    }
}
