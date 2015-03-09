using System;
using System.IO;
using System.Runtime.InteropServices;
using MyLibrary.System;

namespace CursesLibTest
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			PlatformID pid = MyCheckOS ();
			string LibString;

			switch (pid) {
			case PlatformID.Unix:
					LibString = "ncurses";
				break;
			case PlatformID.MacOSX:
				LibString = "libncurses.dylib";
				break;
			default:
				LibString = "unknown";
				Console.WriteLine ("Unknown NCurses Library");
				break;
			}
			Console.WriteLine (Enum.GetName (typeof(PlatformID), pid));
			Console.WriteLine (LibString);
		}
	}
}
