using System;
using Gtk;

namespace SharpKernelUpdate
{
	public class Component
	{
		public Component()
		{
		}


		public Widget AddComponent()
		{
			var vbox = new VBox(false, 5);
			var hbox = new HBox(true, 3);

			var valign = new Alignment(0, 1, 0, 0);
			vbox.PackStart(valign);

			hbox.Add(CreateCheckButton_OnlyStableVersion());
			hbox.Add(CreateRadioButton_Architecture());

			var halign = new Alignment(1, 0, 0, 0);
			halign.Add(hbox);

			vbox.PackStart(halign, false, false, 3);

			return vbox;
		}

		public Widget CreateCheckButton_OnlyStableVersion()
		{
			var cb = new CheckButton("Only stable version");
			cb.Toggled += OnToggled;

			return cb;
		}

		void OnToggled(object sender, EventArgs args)
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


		public Widget CreateRadioButton_Architecture()
		{
			var rb64 = new RadioButton("x64");
			var rb32 = new RadioButton(rb64, "x32");

			return rb32;
		}
	}
}
