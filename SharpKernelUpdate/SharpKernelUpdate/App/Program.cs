using log4net;
using System;
using Gtk;
using SharpKernelUpdate.App.Gui.GTK;
using SharpKernelUpdate.App.Gui;

namespace SharpKernelUpdate
{
	static class Program
	{
		public static readonly ILog LOG = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		public static readonly KUConfigurator Configurator = new KUConfigurator();

		    [STAThread]
		static void Main()
		{
			LOG.Info("START");

			Application.Init();

			var sharpKernelUpdateWindow = new KUSharpKernelUpdateWindow();
			sharpKernelUpdateWindow.Show();

			Application.Run();
		}
	}
}
