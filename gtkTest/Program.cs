using System;
using Gtk;

namespace gtkTest
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();

			Window MainWindow = new Window ("GTK# Basics");
			Button b = new Button ("Hit Me");

			MainWindow.DeleteEvent += new DeleteEventHandler (Window_Delete);
			b.Clicked += new EventHandler (Button_Clicked);

			MainWindow.Add (b);
			MainWindow.SetDefaultSize (200, 100);
			MainWindow.ShowAll ();

			Application.Run ();
		}

		static void Window_Delete(object o, DeleteEventArgs args)
		{
			Application.Quit ();
			args.RetVal = true;
		}

		static void Button_Clicked(object o, EventArgs args)
		{
			System.Console.WriteLine ("Hello World!");
		}
	}
}
