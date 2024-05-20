//
// Run Docker/Linux test with:
//
// docker build -t sgr/findexecutable .
// docker run --rm sgr/findexecutable
//

using System;
using System.IO;

namespace FindExecutable
{
	internal class Program
	{
		static int Main(string[] args)
		{
			int retval = 0;

			string[] executables = new string[] {
				"git.exe",
				"giet"
			};

			foreach (string executable in executables)
			{
				try
				{
					Console.WriteLine($"Searching for: {executable}");

					string? fullPath = FindExecutable.FullPath(executable);

					if (fullPath != null)
					{
						if (Path.IsPathFullyQualified(fullPath))
						{
							Console.WriteLine($"FOUND: {fullPath}");
						}
						else
						{
							Console.WriteLine($"FOUND w/ WARNING: non-full path, {fullPath}");
						}
					}
					else
					{
						Console.Error.WriteLine("NOT FOUND");
						retval = 1;
					}
				}
				catch (Exception e)
				{
					Console.Error.WriteLine($"FAILED, Exception: {e}");
					retval = 2;
				}
			}

			Console.WriteLine("done.");
			if (retval != 0)
			{
				Console.WriteLine($"exit code: {retval}");
			}
			return retval;
		}
	}
}
