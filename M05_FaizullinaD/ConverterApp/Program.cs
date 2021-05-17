using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using NLog.Extensions.Logging;
using ConverterLibrary;

namespace ConverterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddLogging((builder) => builder.SetMinimumLevel(LogLevel.Trace));
            var provider = services.BuildServiceProvider();

            var factory = provider.GetService<ILoggerFactory>();
            factory.AddNLog();
            factory.ConfigureNLog("NLog.config");

            var logger = provider.GetService<ILogger<Program>>();

            try
            {
                var converter = new ToIntConverter(logger);

                Console.WriteLine("Input string:");
                string input = Console.ReadLine();
                int num = converter.ToInt(input);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();

        }
    }
}
