//
// Run Docker/Linux test with:
//
// docker build -t sgr/findexecutable .
// docker run --rm sgr/findexecutable
//

using System;
using System.IO;
using System.Reflection;

namespace FindExecutable
{
	internal class Program
	{
		static int Main(string[] args)
		{
			Console.OutputEncoding = System.Text.Encoding.UTF8;
			int retval = 0;

			retval = Math.Max(retval, TestSearchGit());

			retval = Math.Max(retval, TestUnicodeFile());

			Console.WriteLine("done.");
			if (retval != 0)
			{
				Console.WriteLine($"exit code: {retval}");
			}
			return retval;
		}

		static int TestSearchGit()
		{
			string[] executables = [
				"git.exe",
				"git"
			];

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
						return 1;
					}
				}
				catch (Exception e)
				{
					Console.Error.WriteLine($"FAILED, Exception: {e}");
					return 2;
				}
			}

			return 0;
		}

		static int TestUnicodeFile()
		{
			Console.WriteLine("Searching for an (artificial) executable with a unicode name:");

			const string gitExec = "git";
			const string unicodeExec = "まじかよ。.exe";

			if (File.Exists(unicodeExec))
			{
				File.Delete(unicodeExec);
			}

			string unicodeExecPath = Path.Join(AppContext.BaseDirectory, unicodeExec);
			string? gitFullPath = FindExecutable.FullPath(gitExec);

			if (gitFullPath == null)
			{
				Console.WriteLine("Failed to find git exec as test subject");
				return 5;
			}

			File.Copy(gitFullPath, unicodeExecPath);

			if (!OperatingSystem.IsWindows())
			{
				File.SetUnixFileMode(unicodeExecPath, File.GetUnixFileMode(gitFullPath));
			}

			if (!FindExecutable.IsExecutable(unicodeExecPath))
			{
				Console.WriteLine($"Failed to setup the unicode executable file name: {unicodeExecPath}");
				return 3;
			}

			string? findIt = FindExecutable.FullPath(unicodeExec, includeCurrentDirectory: true);
			if (string.IsNullOrEmpty(findIt))
			{
				Console.WriteLine($"Failed to find the unicode executable file name: {unicodeExec}");
				return 4;
			}

			Console.WriteLine($"FOUND: {findIt}");

			return 0;
		}

	}
}
