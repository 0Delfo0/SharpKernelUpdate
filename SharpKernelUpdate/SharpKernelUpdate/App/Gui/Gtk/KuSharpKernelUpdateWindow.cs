using Gtk;

namespace SharpKernelUpdate.App.Gui.Gtk
{
    public class KuSharpKernelUpdateWindow : Window
    {
        public KuSharpKernelUpdateWindow() :
            base(WindowType.Toplevel)
        {
            Add(KuComponents.AddComponent());

            DeleteEvent += OnDeleteEvent;

            ShowAll();
            Build();
        }

        private void Build()
        {
            this.WindowPosition = ((global::Gtk.WindowPosition) (4));
            Child?.ShowAll();
            this.DefaultWidth = 400;
            this.DefaultHeight = 300;
            this.Show();
        }

        private static void OnDeleteEvent(object sender, DeleteEventArgs e)
        {
            Application.Quit();
            e.RetVal = true;
        }
    }
}