using System;
using Gtk;

namespace SharpKernelUpdate
{
	public partial class SharpKernelUpdateWindow : Gtk.Window
	{
		public SharpKernelUpdateWindow() :
				base(Gtk.WindowType.Toplevel)
		{

			var component = new Component();

			Add(component.AddComponent());
			ShowAll();
			this.Build();


		}




	}
}
