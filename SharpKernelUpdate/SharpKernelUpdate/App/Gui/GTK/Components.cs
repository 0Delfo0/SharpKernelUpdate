using System;
using Gtk;

using System.Collections.Generic;
using System.Linq;
using SharpKernelUpdate.App.Model;
using SharpKernelUpdate.App.Parsers;
using System.Net;
using System.Threading;
using System.ComponentModel;

namespace SharpKernelUpdate.App.Gui.GTK
{
    public class Components
    {
        private static VBox mainVBox = new VBox(false, 5);
        private static HBox mainHBox1 = new HBox(false, 5);
        private static HBox mainHBox2_ProgressBar = new HBox(false, 5);
        private static HBox mainHBox3 = new HBox(false, 5);

        public static Widget AddComponent()
        {
            mainHBox1.PackStart(CreateCheckButton_OnlyStableVersion(), false, false, 1);

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
            var b = new Button(GuiLabel.Update);        
            b.Clicked += OnClicked_Update;
            return b;
        }

        static void OnClicked_Update(object sender, EventArgs args)
        {
            mainHBox3.PackStart(new TreCombo().Create(), false, false, 1);
        }

        private static void Cb_Changed(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            int index = cb.Active;            
        }

        static Widget CreateComboBox(List<UrlItem> listUrlItem)
        {
            var cb = new ComboBox();
            //cb. += OnClicked_Update;
            return cb;
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
