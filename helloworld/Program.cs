using System;
using System.Collections;
using static MyLibrary.System;

namespace BoxUnbox
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			PlatformID MyOID = MyCheckOS ();

			int i = 1;
			object o = i;
			o = 10;
			int j = (int)o;
			Console.WriteLine ("i is {0}!", i);
			Console.WriteLine ("j is {0}!", j);
			Console.WriteLine ("o is {0}!", o);

			Console.WriteLine (Enum.GetName(typeof(PlatformID), MyOID));
		}
	}
}

