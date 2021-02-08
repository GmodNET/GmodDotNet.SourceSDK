using GmodNET.SourceSDK.AppFramework;
using System;
using System.Runtime.InteropServices;

namespace GmodNET.SourceSDK
{
	internal static class FileSystemH
	{
		[DllImport("sourcesdkc")]
		internal static extern int IBaseFileSystem_Read(IntPtr ptr, IntPtr output, int size, IntPtr file);
		[DllImport("sourcesdkc")]
		internal static extern int IBaseFileSystem_Write(IntPtr ptr, IntPtr input, int size, IntPtr file);
		[DllImport("sourcesdkc")]
		internal static extern IntPtr IBaseFileSystem_Open(IntPtr ptr, string fileName, string options, string pathID);
	}
	internal interface IBaseFileSystem
	{
		int Read(IntPtr output, int size, IntPtr file);
		int Write(IntPtr input, int size, IntPtr file);
		IntPtr Open(string fileName, string options, string pathID);
	}
	internal interface IFileSystem
	{
		bool IsSteam();
		void PrintSearchPaths();
	}

	public class BaseFileSystem : IBaseFileSystem
	{
		public const string BASEFILESYSTEM_INTERFACE_VERSION = "VBaseFileSystem011";

		protected readonly IntPtr ptr;

		public BaseFileSystem(IntPtr ptr) => this.ptr = ptr;

		public int Read(IntPtr output, int size, IntPtr file) => FileSystemH.IBaseFileSystem_Read(ptr, output, size, file);
		public int Write(IntPtr input, int size, IntPtr file) => FileSystemH.IBaseFileSystem_Write(ptr, input, size, file);
		public IntPtr Open(string fileName, string options, string pathID) => FileSystemH.IBaseFileSystem_Open(ptr, fileName, options, pathID);
	}

	public class FileSystem : IAppSystem, IBaseFileSystem, IFileSystem
	{
		public const string FILESYSTEM_INTERFACE_VERSION = "VFileSystem022";

		public FileSystem(IntPtr ptr) : base(ptr) { }

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

		public int Read(IntPtr output, int size, IntPtr file) => FileSystemH.IBaseFileSystem_Read(ptr, output, size, file);
		public int Write(IntPtr input, int size, IntPtr file) => FileSystemH.IBaseFileSystem_Write(ptr, input, size, file);
		public IntPtr Open(string fileName, string options, string pathID) => FileSystemH.IBaseFileSystem_Open(ptr, fileName, options, pathID);
	}
}
