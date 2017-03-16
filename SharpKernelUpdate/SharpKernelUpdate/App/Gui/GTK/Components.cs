using System;
using Gtk;

using System.Collections.Generic;
using System.Linq;
using SharpKernelUpdate.App.Model;
using SharpKernelUpdate.App.Parsers;
using System.Net;
using System.Threading;

namespace SharpKernelUpdate.App.Gui.GTK
{
	public class Components
	{

		private static VBox mainVBox = new VBox(false, 5);
		private static HBox mainHBox1 = new HBox(false, 5);
		private static HBox mainHBox2 = new HBox(false, 5);



        public static void Test()
        {
            var client = new WebClient();
            var reset = new ManualResetEvent(false);
            client.DownloadProgressChanged += (s, e) => Console.WriteLine("{0} percent complete", e.ProgressPercentage);
            client.DownloadFileCompleted += (s, e) => Console.WriteLine("END");  reset.Set();



            client.DownloadDataAsync(new Uri("http://kernel.ubuntu.com/~kernel-ppa/mainline/v4.10.3/linux-headers-4.10.3-041003-generic-lpae_4.10.3-041003.201703142331_armhf.deb"));
            //client.DownloadFileAsync(new Uri("http://myfilepathhere.com"), "file.name");
            //Block till download completes
            reset.WaitOne();

        }

        public static Widget AddComponent()
        {
            mainHBox1.PackStart(CreateCheckButton_OnlyStableVersion(), false, false, 1);

			mainHBox1.PackStart(new VSeparator());

			CreateRadioButtons_Architecture(mainHBox1);

			mainHBox1.PackStart(new VSeparator());
			mainHBox1.PackStart(CreateButton_Update(), false, false, 1);

			mainVBox.PackStart(mainHBox1, false, false, 1);

			mainVBox.PackStart(new HSeparator());
			mainVBox.PackStart(mainHBox2, false, false, 1);

			return mainVBox;
		}

		static Widget CreateButton_Update()
		{
			var b = new Button(GuiLabel.Update);
			b.SetSizeRequest(75, 30);
			b.Clicked += OnClicked_Update;

			return b;
		}

        static void OnClicked_Update(object sender, EventArgs args)
        {
            //Test();

            var list = Parser.GetMainList();

			var mainList = Filter.GetListElements(0, list);

            var children = mainHBox2.Children;

            foreach (var child in mainHBox2.Children)
            {
                child.Destroy();
            }

            foreach (var i in mainList)
            {
                var lb = new LinkButton(i.Key, i.Key);
                mainHBox2.PackStart(lb, false, false, 1);
                lb.Show();
            }
        }


		static Widget CreateCheckButton_OnlyStableVersion()
		{
			var cb = new CheckButton(GuiLabel.OnlyStableVersion);
			cb.Toggled += OnToggled_OnlyStableVersion;

			return cb;
		}

		static void OnToggled_OnlyStableVersion(object sender, EventArgs args)
		{
			var cb = (CheckButton)sender;
			if (cb.Active)
			{
				Configurator.isOnlyStableVersion = true;
			}
			else
			{
				Configurator.isOnlyStableVersion = false;
			}

			Program.LOG.Debug("Configurator.isOnlyStableVersion: " + Configurator.isOnlyStableVersion);
		}

		static void CreateRadioButtons_Architecture(Box container)
		{
			var rb64 = new RadioButton(GuiLabel.Architecture_x64);
			container.PackStart(rb64, false, false, 1);
			rb64.Toggled += OnToggled_Architecture;

			var rb32 = new RadioButton(rb64, GuiLabel.Architecture_x32);
			container.PackStart(rb32, false, false, 1);

			Configurator.is64Architecture = true;
		}

		static void OnToggled_Architecture(object sender, EventArgs args)
		{
			var rb = (RadioButton)sender;
			if (rb.Active)
			{
				Configurator.is64Architecture = true;
			}
			else
			{
				Configurator.is64Architecture = false;
			}
			Program.LOG.Debug("Configurator.is64Architecture: " + Configurator.is64Architecture);
		}
	}
}
