using System;
using Microsoft.Extensions.Configuration;
using System.Windows.Forms;
using Subtitler.Core.Config;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Subtitler.Forms;
using System.Security.Principal;

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
            try
            {
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                var host = Host.CreateDefaultBuilder()
                    .ConfigureAppConfiguration((context, builder) =>
                    {
                    // Add other configuration files...
                    builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
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
                var mainForm = services.GetRequiredService<MainForm>();
                Application.Run(mainForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.ToString());
            }
        }

        private static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddSingleton<MainForm>();
            services.AddSingleton<SettingsForm>();
            services.Configure<AppSettings>(configuration);
        }

        public static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
