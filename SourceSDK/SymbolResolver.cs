using System;
using System.IO;
using System.Runtime.InteropServices;

namespace GmodNET.SourceSDK
{
	public static class SymbolResolver
	{
		public static bool Server { private get; set; } = true;

		private static readonly Func<string, IntPtr> getLibPtr;
		private static readonly Func<IntPtr, string, IntPtr> getSymbolPtr;
		private static readonly string[] libNames;
		private static readonly string[] paths;

		private static string GetPath(string path) => Path.Combine(Directory.GetCurrentDirectory(), path);

		static SymbolResolver()
		{
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
			{
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
			}
			else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
			{
				getLibPtr = dlopen;
				getSymbolPtr = dlsym;
				if (Server)
				{
					libNames = new[]
					{
						"{0}.so",
						"lib{0}.so"
					};
				}
				else
				{
					libNames = new[]
					{
						"{0}_client.so",
						"lib{0}_client.so",
						"{0}.so",
						"lib{0}.so"
					};
				}
				paths = new[]
				{
					"bin/linux64/{0}"
				};
			}
			else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
			{
				getLibPtr = dlopen;
				getSymbolPtr = dlsym;
				if (Server)
				{
					libNames = new[]
					{
						"{0}.dylib",
						"lib{0}.dylib"
					};
				}
				else
				{
					libNames = new[]
					{
						"{0}_client.dylib",
						"lib{0}_client.dylib",
						"{0}.dylib",
						"lib{0}.dylib"
					};
				}
				paths = new[]
				{
					"bin/osx64/{0}"
				};
			}
			else throw new PlatformNotSupportedException();
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

		private static TDelegate ResolveSymbol<TDelegate>(string libName, string name)
		{
			foreach (string libNameFormat in libNames)
			{
				string fullLibName = string.Format(libNameFormat, libName);

				foreach (string path in paths)
				{
					string relativeLibPath = string.Format(path, fullLibName);

					string absoluteLibPath = GetPath(relativeLibPath);

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
			return default;
		}

		internal static TDelegate GetSymbol<TDelegate>(string libName, string windows, string unix, string osx = null)
		{
			if (osx == null) osx = "_" + unix;
			string entryPoint = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? windows : (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ? unix : osx);

			return ResolveSymbol<TDelegate>(libName, entryPoint);
		}
	}
}
