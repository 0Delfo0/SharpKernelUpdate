using System;
using Gtk;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using SharpKernelUpdate.App.Gui;
using SharpKernelUpdate.App.Gui.Gtk;

namespace SharpKernelUpdate.App
{
    internal class Program
    {
        public static ILogger Log;

        public static readonly KuConfigurator Configurator = new KuConfigurator();

        [STAThread]
        private static void Main()
        {
            var servicesProvider = GetServiceProvider();

            Log = GetLogger(servicesProvider);

            Log.LogInformation("START");

            Application.Init();

            var sharpKernelUpdateWindow = new KuSharpKernelUpdateWindow();
            sharpKernelUpdateWindow.Show();

            Application.Run();
        }

        private static ILogger GetLogger(IServiceProvider servicesProvider)
        {
            return servicesProvider.GetService<ILogger<Program>>();
        }

        private static IServiceProvider GetServiceProvider()
        {
            var services = new ServiceCollection();

            services.AddLogging();
            var provider = services.BuildServiceProvider();

            var factory = provider.GetService<ILoggerFactory>();
            factory.AddNLog(new NLogProviderOptions {CaptureMessageTemplates = true, CaptureMessageProperties = true});
            factory.ConfigureNLog(@"nlog.config");

            return services.BuildServiceProvider();
        }
    }
}