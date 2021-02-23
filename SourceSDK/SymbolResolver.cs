using System;
using System.IO;
using System.Runtime.InteropServices;

namespace GmodNET.SourceSDK
{
	internal static class SymbolResolver
	{
		private static readonly Func<string, IntPtr> getLibPtr;
		private static readonly Func<IntPtr, string, IntPtr> getSymbolPtr;
		private static readonly string[] libNames;
		private static readonly string[] paths;

		private static string getPath(string path) => Path.Combine(Directory.GetCurrentDirectory(), path);

		static SymbolResolver()
		{
			switch (Environment.OSVersion.Platform)
			{
				case PlatformID.Win32NT:
					getLibPtr = LoadLibrary;
					getSymbolPtr = GetProcAddress;
					libNames = new[]
					{
						"{0}.dll"
					};
					paths = new[]
					{
						"bin/win64/{0}",
						// "bin/{0}"
					};
					break;
				case PlatformID.Unix:
					getLibPtr = dlopen;
					getSymbolPtr = dlsym;
					libNames = new[]
					{
						"{0}.so",
						"lib{0}.so"
					};
					paths = new[]
					{
						"bin/linux64/{0}"
					};
					break;
				case PlatformID.MacOSX:
					getLibPtr = dlopen;
					getSymbolPtr = dlsym;
					libNames = new[]
					{
						"{0}.dylib",
						"lib{0}.dylib"
					};
					paths = new[]
					{
						"bin/osx64/{0}"
					};
					break;
				default:
					throw new PlatformNotSupportedException();
			}
		}

		#region native
		[DllImport("dl", CharSet = CharSet.Ansi)]
		private static extern IntPtr dlopen(string libName, int flags);
		private static IntPtr dlopen(string libName) => dlopen(libName, 0x1);
		[DllImport("dl", CharSet = CharSet.Ansi)]
		private static extern IntPtr dlsym(IntPtr lib, string symbol);
		[DllImport("kernel32", SetLastError = true)]
		private static extern IntPtr LoadLibrary(string libName);
		[DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		private static extern IntPtr GetProcAddress(IntPtr lib, string name);
		#endregion

		internal static TDelegate ResolveSymbol<TDelegate>(string libName, string name)
		{
			foreach (string libNameFormat in libNames)
			{
				string fullLibName = string.Format(libNameFormat, libName);

				foreach (string path in paths)
				{
					string relativeLibPath = string.Format(path, fullLibName);

					string absoluteLibPath = getPath(relativeLibPath);

					if (File.Exists(absoluteLibPath))
					{
						IntPtr lib = getLibPtr(absoluteLibPath);
						if (lib == IntPtr.Zero) continue;

						IntPtr symbolPtr = getSymbolPtr(lib, name);

						if (symbolPtr == IntPtr.Zero) continue;

						return Marshal.GetDelegateForFunctionPointer<TDelegate>(symbolPtr);
					}
				}
			}
			Console.WriteLine("not found");
			return default;
		}
	}
}
