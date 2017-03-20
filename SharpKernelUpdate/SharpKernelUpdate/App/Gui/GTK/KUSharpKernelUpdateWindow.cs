using Gtk;

namespace SharpKernelUpdate.App.Gui.Gtk
{
    public partial class KUSharpKernelUpdateWindow : Window
    {
        public KUSharpKernelUpdateWindow() :
                base(WindowType.Toplevel)
        {
            Add(KUComponents.AddComponent());

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

        protected void OnDeleteEvent(object sender, DeleteEventArgs e)
        {
            Application.Quit();
            e.RetVal = true;
        }
    }
}
