using Gtk;
using System;

namespace SharpKernelUpdate.App.Gui.Gtk
{
    public class KUComponents
    {
        private static VBox mainVBox = new VBox(false, 5);
        private static HBox mainHBox1 = new HBox(false, 5);
        private static HBox mainHBox2_ProgressBar = new HBox(false, 5);
        private static HBox mainHBox3 = new HBox(false, 5);

        public static Widget AddComponent()
        {
            mainHBox1.PackStart(CreateCheckButton_OnlyStableVersion(), false, false, 1);

            mainHBox1.PackStart(new VSeparator());

            mainHBox1.PackStart(CreateCheckButton_LowLatency(), false, false, 1);

            mainHBox1.PackStart(new VSeparator());

            CreateRadioButtons_Architecture(mainHBox1);

            mainHBox1.PackStart(new VSeparator());

            mainHBox1.PackStart(CreateButton_Update(), false, false, 1);

            mainHBox1.PackStart(new VSeparator());

            mainVBox.PackStart(mainHBox1, false, false, 1);

            mainVBox.PackStart(new HSeparator());

            mainHBox2_ProgressBar.PackStart(new ProgressBar(), true, true, 1);
            mainVBox.PackStart(mainHBox2_ProgressBar, false, false, 1);

            mainVBox.PackStart(new HSeparator());

            mainVBox.PackStart(mainHBox3, false, false, 1);

            return mainVBox;
        }

        static Widget CreateButton_Update()
        {
            var b = new Button(KUGuiLabel.Update);
            b.Clicked += OnClicked_Update;
            return b;
        }

        static void OnClicked_Update(object sender, EventArgs args)
        {
            mainVBox.PackStart(new KUTreCombo().Create(), false, false, 1);
        }

        static Widget CreateCheckButton_OnlyStableVersion()
        {
            var cb = new CheckButton(KUGuiLabel.OnlyStableVersion)
            {
                Active = Program.Configurator.IsOnlyStableVersion
            };
            cb.Toggled += OnToggled_OnlyStableVersion;

            return cb;
        }

        static void OnToggled_OnlyStableVersion(object sender, EventArgs args)
        {
            var cb = (CheckButton)sender;
            if (cb.Active)
            {
                Program.Configurator.IsOnlyStableVersion = true;
            }
            else
            {
                Program.Configurator.IsOnlyStableVersion = false;
            }

            Program.LOG.Debug("Configurator.isOnlyStableVersion: " + Program.Configurator.IsOnlyStableVersion);
        }

        static Widget CreateCheckButton_LowLatency()
        {
            var cb = new CheckButton(KUGuiLabel.LowLatency)
            {
                Active = Program.Configurator.IsLowLatency
            };
            cb.Toggled += OnToggled_LowLatency;

            return cb;
        }

        static void OnToggled_LowLatency(object sender, EventArgs args)
        {
            var cb = (CheckButton)sender;
            if (cb.Active)
            {
                Program.Configurator.IsLowLatency = true;
            }
            else
            {
                Program.Configurator.IsLowLatency = false;
            }

            Program.LOG.Debug("Configurator.IsLowLatency: " + Program.Configurator.IsLowLatency);
        }

        static void CreateRadioButtons_Architecture(Box container)
        {
            var rb64 = new RadioButton(KUGuiLabel.Architecture_x64);
            container.PackStart(rb64, false, false, 1);
            rb64.Toggled += OnToggled_Architecture;

            var rb32 = new RadioButton(rb64, KUGuiLabel.Architecture_x32);
            container.PackStart(rb32, false, false, 1);

            Program.Configurator.Is64Architecture = true;
        }

        static void OnToggled_Architecture(object sender, EventArgs args)
        {
            var rb = (RadioButton)sender;
            if (rb.Active)
            {
                Program.Configurator.Is64Architecture = true;
            }
            else
            {
                Program.Configurator.Is64Architecture = false;
            }
            Program.LOG.Debug("Configurator.is64Architecture: " + Program.Configurator.Is64Architecture);
        }
    }
}
