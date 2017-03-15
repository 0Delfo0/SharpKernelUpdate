using System;
using Gtk;

namespace SharpKernelUpdate
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

		protected void OnDeleteEvent(object sender, DeleteEventArgs a)
		{
			Application.Quit();
			a.RetVal = true;
		}
	}
}
