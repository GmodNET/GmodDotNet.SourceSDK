using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace GmodNET.SourceSDK
{
	internal class NativeLibraryResolver
	{
		internal static Assembly assembly = typeof(NativeLibraryResolver).Assembly;
		internal static string platformIdentifier = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "win-x64" : (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ? "linux-x64" : "osx-x64");
		internal static string lib = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "sourcesdkc.dll" : "libsourcesdkc.so";

		internal static void Init()
		{
			NativeLibrary.SetDllImportResolver(assembly, (libName, asm, searchPath) =>
			{
				if (asm == assembly && libName == "sourcesdkc")
				{
					string path = Path.Combine(Path.GetDirectoryName(assembly.Location), $"runtimes/{platformIdentifier}/native/{lib}");
					if (File.Exists(path))
					{
						return NativeLibrary.Load(path);
					}
					else
					{
						return NativeLibrary.Load("sourcesdkc");
					}
				}
				return IntPtr.Zero;
			});
		}
	}
}
