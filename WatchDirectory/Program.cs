using System;
using System.IO;

namespace WatcherTest
{
	public class WatchDirectory {
		private static void OnFileSystemEvent(object sender, FileSystemEventArgs e) {
			Console.WriteLine("Something happened to {0}", e.Name);
		}

		private static void OnChanged (object sender, FileSystemEventArgs e) {
			Console.WriteLine ("{0} has changed at {1}", e.Name, e.ChangeType);
		}

		private static void OnDeleted (object sender, FileSystemEventArgs e) {
			Console.WriteLine ("{0} has deleted at {1}", e.Name, e.ChangeType);
		}

		private static void OnCreated (object sender, FileSystemEventArgs e) {
			Console.WriteLine ("{0} was created at {1}", e.Name, e.ChangeType);
		}

		private static void OnRenamed (object sender, RenamedEventArgs e) {
			Console.WriteLine ("{0} was renamed to {1} at {2}",
				e.OldName, e.Name, e.ChangeType);
		}

		public static void Main (string[] args)
		{
			string path = (string)args [0];

			FileSystemWatcher watcher = new FileSystemWatcher(path);
			watcher.Filter = "";
			watcher.IncludeSubdirectories = true;

			watcher.Changed += new FileSystemEventHandler (OnChanged);
			watcher.Created += new FileSystemEventHandler (OnCreated);
			watcher.Deleted += new FileSystemEventHandler (OnDeleted);
			watcher.Renamed += new RenamedEventHandler (OnRenamed);

			FileSystemEventHandler onFileSystemEvent = 
				new FileSystemEventHandler (OnFileSystemEvent);

			watcher.Changed += onFileSystemEvent;
			watcher.Created += onFileSystemEvent;
			watcher.Deleted += onFileSystemEvent;

			watcher.EnableRaisingEvents = true;

			Console.WriteLine ("Enable event watcher on {0}; " +
			"hit return to terminate", path);

			Console.ReadLine ();

			watcher.EnableRaisingEvents = false;

			watcher.Changed -= new FileSystemEventHandler (OnChanged);
			watcher.Created -= new FileSystemEventHandler (OnCreated);
			watcher.Deleted -= new FileSystemEventHandler (OnDeleted);
			watcher.Renamed -= new RenamedEventHandler (OnRenamed);

			watcher.Changed -= onFileSystemEvent;
			watcher.Created -= onFileSystemEvent;
			watcher.Deleted -= onFileSystemEvent;

			Console.WriteLine ("Done!");
		}
	}
}
