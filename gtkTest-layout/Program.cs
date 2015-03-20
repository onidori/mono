using System;
using Gtk;

namespace gtkTestlayout
{
	class MainClass
	{
		private static Entry firstname_entry, lastname_entry, email_entry;

		public static void Main (string[] args)
		{
			Application.Init ();
			SetUpGui_2 ();
			Application.Run ();
		}

		static void SetUpGui()
		{
			Window w = new Window ("Layout Test");

			HBox h = new HBox ();
			h.BorderWidth = 6;
			h.Spacing = 6;
			w.Add (h);

			VBox v = new VBox ();
			v.Spacing = 6;
			h.PackStart (v, false, false, 0);

			Label l = new Label ("Full Name");
			l.Xalign = 0;
			v.PackStart (l, true, false, 0);

			l = new Label ("Email address");
			l.Xalign = 0;
			v.PackStart (l, true, false, 0);

			v = new VBox ();
			v.Spacing = 6;
			h.PackStart(v, true, true,0);

			v.PackStart(new Entry(), true, true, 0);
			v.PackStart(new Entry(), true, true, 0);

			w.DeleteEvent += Window_Delete;
			w.ShowAll ();
		}

		static void Window_Delete (object o, DeleteEventArgs args)
		{
			Application.Quit ();
			args.RetVal = true;
		}

		static void SetUpGui_2 ()
		{
			Window w = new Window ("Sign Up");

			firstname_entry = new Entry ();
			lastname_entry = new Entry ();
			email_entry = new Entry ();

			VBox outerV = new VBox ();
			outerV.BorderWidth = 12;
			outerV.Spacing = 12;
			w.Add (outerV);

			Label l = new Label ("<span weight=\"bold\" size = \"large\">" +
				"Enter your name and preferred address</span>");
			l.Xalign = 0;
			l.UseMarkup = true;
			outerV.PackStart (l, false, false, 0);
			HBox h = new HBox ();
			h.Spacing = 6;
			outerV.Add (h);

			VBox v = new VBox ();
			v.Spacing = 6;
			h.PackStart (v, false, false, 0);

			l = new Label ("_First name:");
			l.Xalign = 0;
			v.PackStart (l, true, false, 0);
			l.MnemonicWidget = firstname_entry;

			l = new Label ("_Last name:");
			l.Xalign = 0;
			v.PackStart (l, true, false, 0);
			l.MnemonicWidget = lastname_entry;

			l = new Label ("_Email Address:");
			l.Xalign = 0;
			v.PackStart (l, true, false, 0);
			l.MnemonicWidget = email_entry;

			v = new VBox ();
			v.Spacing = 6;
			h.PackStart (v, true, true, 0);

			v.PackStart (firstname_entry, true, true, 0);
			v.PackStart (lastname_entry, true, true, 0);
			v.PackStart (email_entry, true, true, 0);

			// hook up handlers

			firstname_entry.Changed += Name_Changed;
			lastname_entry.Changed += Name_Changed;
			w.DeleteEvent += Window_Delete;
			w.ShowAll();
		}

		static void Name_Changed(object o, EventArgs args)
		{
			string e = firstname_entry.Text.ToLower () +
			           "." + lastname_entry.Text .ToLower () +
				"@home.lan";
			email_entry.Text = e.Replace(" ","_");
		}
	}
}
