using System;
using System.Configuration;
using System.Linq;
using System.Reflection;
using DbUp;

namespace Catalog.Databases.MySql
{
    public class Program
    {
        static int Main(string[] args)
        {
            // TODO: Use Core 2.0 configuration api
            var connectionString =
                args.FirstOrDefault()??ConfigurationManager.ConnectionStrings["Products"].ConnectionString;

            EnsureDatabase.For.SqlDatabase(connectionString);

            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
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
