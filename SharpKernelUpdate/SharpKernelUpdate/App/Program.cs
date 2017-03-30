using System;
using Gtk;
using log4net;
using SharpKernelUpdate.App.Gui;
using SharpKernelUpdate.App.Gui.Gtk;

namespace SharpKernelUpdate.App
{
    internal static class Program
    {
        public static readonly ILog Log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static readonly KuConfigurator Configurator = new KuConfigurator();

        [STAThread]
        static void Main()
        {
            Log.Info("START");

            Application.Init();

            var sharpKernelUpdateWindow = new KuSharpKernelUpdateWindow();
            sharpKernelUpdateWindow.Show();

            Application.Run();
        }
    }
}