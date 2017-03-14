using System;
using Gtk;
using SharpKernelUpdate.App.Parser;
using System.Collections.Generic;
using System.Linq;
using SharpKernelUpdate.App.Model;

namespace SharpKernelUpdate
{
    public class Components
    {

        private static VBox mainVBox = new VBox(false, 5);
        private static HBox mainHBox1 = new HBox(false, 5);
        private static HBox mainHBox2 = new HBox(false, 5);


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
            var list = Parser.GetMainList();

            IEnumerable<IGrouping<string, UrlItem>> mainList = Filter.GetListElements(0, list);

            foreach (var i in mainList)
            {
                var lb = new LinkButton(i.Key);
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
