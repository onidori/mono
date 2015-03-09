using System;
using System.IO;

namespace MyLibrary
{
	public static class System
	{
		public static PlatformID MyCheckOS()
		{
			OperatingSystem MyOS = Environment.OSVersion;
			PlatformID MyPID = MyOS.Platform;

			switch (MyPID) {
			case PlatformID.Unix:
				if (Directory.Exists ("/Applications")
				    & Directory.Exists ("/System")
				    & Directory.Exists ("/Library/Frameworks")
				    & Directory.Exists ("/Volumes"))
					MyPID = PlatformID.MacOSX;
				break;
			default:
				break;
			}

			return(MyPID);
		}
	}
}

