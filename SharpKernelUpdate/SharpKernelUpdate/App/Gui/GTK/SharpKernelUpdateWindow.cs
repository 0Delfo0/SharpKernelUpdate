using System;
using Gtk;

namespace SharpKernelUpdate.App.Gui.GTK
{
    public partial class SharpKernelUpdateWindow : Window
    {
        public SharpKernelUpdateWindow() :
                base(WindowType.Toplevel)
        {
            Add(Components.AddComponent());

            DeleteEvent += OnDeleteEvent;

            ShowAll();
            Build();
        }


        protected virtual void Build()
        {
            this.WindowPosition = ((global::Gtk.WindowPosition)(4));
            if ((this.Child != null))
            {
                this.Child.ShowAll();
            }
            this.DefaultWidth = 400;
            this.DefaultHeight = 300;
            this.Show();
        }


        protected void OnDeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
            a.RetVal = true;
        }
    }
}
