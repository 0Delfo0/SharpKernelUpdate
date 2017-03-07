using log4net;
using SharpKernelUpdate.App.Parser;
using System;
using Gtk;

namespace SharpKernelUpdate
{
	static class Program
	{

		public static readonly ILog LOG = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		/// <summary>
		/// Punto di ingresso principale dell'applicazione.
		/// </summary>
		/// 
		[STAThread]
		static void Main()
		{

			LOG.Info("START");
			//Application.EnableVisualStyles();
			//Application.SetCompatibleTextRenderingDefault(false);
			//Application.Run(new SharpKernelUpdateForm());



			Application.Init();

			var sharpKernelUpdateWindow = new SharpKernelUpdateWindow();
			sharpKernelUpdateWindow.Show();

			Application.Run();

			//string Pippo = "v3.111.222.333.";

			//            string[] p = Pippo.Split('.');

			//            foreach (string s in p)
			//{
			//Console.WriteLine(s);
			//}

			var parser = new Parser();
			parser.getItems();
			LOG.Info("STOP");
		}
	}
}
