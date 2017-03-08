using System;
using Gtk;

namespace SharpKernelUpdate
{
	public partial class SharpKernelUpdateWindow : Gtk.Window
	{
		public SharpKernelUpdateWindow() :
				base(Gtk.WindowType.Toplevel)
		{
			Add(Components.AddComponent());

			DeleteEvent += OnDeleteEvent;

			ShowAll();
			Build();
		}

		protected void OnDeleteEvent(object sender, DeleteEventArgs a)
		{
			Application.Quit();
			a.RetVal = true;
		}
	}
}
