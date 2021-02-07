using System;
using System.Runtime.InteropServices;

namespace GmodNET.SourceSDK
{
	public class IFileSystem
	{
		static IFileSystem() => NativeLibraryResolver.Init();

		private IntPtr ptr;

		public IFileSystem(IntPtr ptr)
		{
			this.ptr = ptr;
		}

		[DllImport("sourcesdkc")]
		internal static extern bool IFileSystem_IsSteam(IntPtr ptr);
		public bool IsSteam()
		{
			return IFileSystem_IsSteam(ptr);
		}

		[DllImport("sourcesdkc")]
		internal static extern void IFileSystem_PrintSearchPaths(IntPtr ptr);
		public void PrintSearchPaths()
		{
			IFileSystem_PrintSearchPaths(ptr);
		}
	}
}
