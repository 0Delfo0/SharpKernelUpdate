using System;
using Gtk;
using Microsoft.Extensions.Logging;

namespace SharpKernelUpdate.App.Gui.Gtk
{
    public static class KuComponents
    {
        private static readonly VBox MainVBox = new VBox(false, 5);
        private static readonly HBox MainHBox1 = new HBox(false, 5);
        private static readonly HBox MainHBox2ProgressBar = new HBox(false, 5);
        private static readonly ProgressBar MainProgressBar = new ProgressBar();
        private static readonly HBox MainHBox3 = new HBox(false, 5);

        public static Widget AddComponent()
        {
            MainHBox1.PackStart(CreateCheckButton_OnlyStableVersion(), false, false, 1);

            MainHBox1.PackStart(new VSeparator(), false, false, 1);

            MainHBox1.PackStart(CreateCheckButton_LowLatency(), false, false, 1);

            MainHBox1.PackStart(new VSeparator(), false, false, 1);

            CreateRadioButtons_Architecture(MainHBox1);

            MainHBox1.PackStart(new VSeparator(), false, false, 1);

            MainHBox1.PackStart(CreateButton_Update(), false, false, 1);

            MainHBox1.PackStart(new VSeparator(), false, false, 1);

            MainVBox.PackStart(MainHBox1, false, false, 1);

            MainVBox.PackStart(new HSeparator(), false, false, 1);

            MainHBox2ProgressBar.PackStart(MainProgressBar, true, true, 1);
            MainVBox.PackStart(MainHBox2ProgressBar, false, false, 1);

            MainVBox.PackStart(new HSeparator(), false, false, 1);

            MainVBox.PackStart(MainHBox3, false, false, 1);

            return MainVBox;
        }

        private static Widget CreateButton_Update()
        {
            var b = new Button(KuGuiLabel.Update);
            b.Clicked += OnClicked_Update;
            return b;
        }

        private static void OnClicked_Update(object sender, EventArgs args)
        {
            MainVBox.PackStart(new KuTreCombo(MainProgressBar).Create(), false, false, 1);
        }

        private static Widget CreateCheckButton_OnlyStableVersion()
        {
            var cb = new CheckButton(KuGuiLabel.OnlyStableVersion)
            {
                Active = Program.Configurator.IsOnlyStableVersion
            };
            cb.Toggled += OnToggled_OnlyStableVersion;

            return cb;
        }

        private static void OnToggled_OnlyStableVersion(object sender, EventArgs args)
        {
            var cb = (CheckButton) sender;
            Program.Configurator.IsOnlyStableVersion = cb.Active;

            Program.Log.LogDebug("Configurator.isOnlyStableVersion: " + Program.Configurator.IsOnlyStableVersion);
        }

        private static Widget CreateCheckButton_LowLatency()
        {
            var cb = new CheckButton(KuGuiLabel.LowLatency)
            {
                Active = Program.Configurator.IsLowLatency
            };
            cb.Toggled += OnToggled_LowLatency;

            return cb;
        }

        private static void OnToggled_LowLatency(object sender, EventArgs args)
        {
            var cb = (CheckButton) sender;
            Program.Configurator.IsLowLatency = cb.Active;

            Program.Log.LogDebug("Configurator.IsLowLatency: " + Program.Configurator.IsLowLatency);
        }

        private static void CreateRadioButtons_Architecture(Box container)
        {
            var rb64 = new RadioButton(KuGuiLabel.ArchitectureX64);
            container.PackStart(rb64, false, false, 1);
            rb64.Toggled += OnToggled_Architecture;

            var rb32 = new RadioButton(rb64, KuGuiLabel.ArchitectureX32);
            container.PackStart(rb32, false, false, 1);

            Program.Configurator.Is64Architecture = true;
        }

        private static void OnToggled_Architecture(object sender, EventArgs args)
        {
            var rb = (RadioButton) sender;
            Program.Configurator.Is64Architecture = rb.Active;
            Program.Log.LogDebug("Configurator.is64Architecture: " + Program.Configurator.Is64Architecture);
        }
    }
}