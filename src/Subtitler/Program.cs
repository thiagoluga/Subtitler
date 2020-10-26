using System;
using Microsoft.Extensions.Configuration;
using System.Windows.Forms;
using Subtitler.Core.Config;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Subtitler
{
    internal static class Program
    {
        public static IConfigurationRoot ConfigurationRoot { get; set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var host = Host.CreateDefaultBuilder()
                            .ConfigureAppConfiguration((context, builder) =>
                            {
                                // Add other configuration files...
                                builder.AddJsonFile("appsettings.local.json", optional: true);
                            })
                            .ConfigureServices((context, services) =>
                            {
                                ConfigureServices(context.Configuration, services);
                            })
                            .ConfigureLogging(logging =>
                            {
                                // Add other loggers...
                            })
                            .Build();

            var services = host.Services;
            var mainForm = services.GetRequiredService<SubtitlerForm>();
            Application.Run(mainForm);
        }

        private static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddSingleton<SubtitlerForm>();
            services.Configure<AppSettings>(configuration);
        }
    }
}
