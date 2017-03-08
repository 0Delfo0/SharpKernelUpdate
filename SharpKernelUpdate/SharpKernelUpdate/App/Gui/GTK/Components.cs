using System;
using Gtk;

namespace SharpKernelUpdate
{
	public class Components
	{
		public static Widget AddComponent()
		{
			var vbox = new VBox(false, 5);
			var hbox = new HBox(true, 3);

			var valign = new Alignment(0, 1, 0, 0);
			vbox.PackStart(valign);

			hbox.Add(CreateCheckButton_OnlyStableVersion());

			hbox.Add(new VSeparator());
			CreateRadioButton_Architecture(hbox);

			var halign = new Alignment(1, 0, 0, 0);
			halign.Add(hbox);

			vbox.PackStart(halign, false, false, 3);

			return vbox;
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


		static void CreateRadioButton_Architecture(Container container)
		{
			var rb64 = new RadioButton(GuiLabel.Architecture_x64);
			container.Add(rb64);
			rb64.Toggled += OnToggled_Architecture;

			var rb32 = new RadioButton(rb64, GuiLabel.Architecture_x32);
			container.Add(rb32);

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
