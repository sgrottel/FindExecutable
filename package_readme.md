# SGrottel.FindExecutable
C# code to find the full path of an executable file by searching the system's search paths.

https://github.com/sgrottel/FindExecutable

## Example
`FindExecutable` is a static class with one public static method:
```cs
public static string? FullPath(
	string executable,
	bool includeCurrentDirectory = false,
	bool includeBaseDirectory = false,
	IEnumerable<string>? additionalPaths = null);
```

* `executable` -- The name of the executable to find.
* `includeCurrentDirectory` -- If set to true, the current execution directory is included in the list of search paths
* `includeBaseDirectory` -- If set to true, the application domain base directory is included in the list of search paths
* `additionalPaths` -- If set to something other then null, the paths iterated within are included in the list of search paths

The function will return the full file system path to the executable file requested, or null if the file is not found.

## License
This project is freely available under the terms of the [MIT License](./LICENSE)

	Copyright (c) 2023-2025 Sebastian Grottel

	Permission is hereby granted, free of charge, to any person obtaining a copy
	of this software and associated documentation files (the "Software"), to deal
	in the Software without restriction, including without limitation the rights
	to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
	copies of the Software, and to permit persons to whom the Software is
	furnished to do so, subject to the following conditions:

	The above copyright notice and this permission notice shall be included in all
	copies or substantial portions of the Software.

	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
	IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
	FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
	AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
	LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
	OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
	SOFTWARE.
