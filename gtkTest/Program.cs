using System;
using Gtk;
using MyLibrary.System;

namespace gtkTest
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();

			MainWindow w = new MainWindow ();
			Button b = new Button ("Hit Me");

			w.DeleteEvent += new DeleteEventHandler (Window_Delete);
			b.Clicked += new EventHandler (Button_Clicked);
			w.Add (b);
//			w.SetDefaultSize (200, 100);
			w.ShowAll ();

			Application.Run ();
		}

		static void Window_Delete(object o, DeleteEventArgs args)
		{
			Application.Quit ();
			args.RetVal = true;
		}

		static void Button_Clicked(object o, EventArgs args)
		{
			PlatformID MyOID = MyCheckOS ();
			DateTimeOffset ct = DateTime.Now;

			String s = "Hello World! " + Enum.GetName (typeof(PlatformID), MyOID) + " : " + ct.ToString ();
			System.Console.WriteLine (s);
		}
	}
}
