using GmodNET.SourceSDK.AppFramework;
using System;
using System.Runtime.InteropServices;

namespace GmodNET.SourceSDK
{
	public enum FileSystemSeek_t
	{
		FILESYSTEM_SEEK_HEAD = 0,
		FILESYSTEM_SEEK_CURRENT = 1,
		FILESYSTEM_SEEK_TAIL = 2,
	};

	internal static class FileSystemH
	{
		[DllImport("sourcesdkc")]
		internal static extern int IBaseFileSystem_Read(IntPtr ptr, IntPtr output, int size, IntPtr file);
		[DllImport("sourcesdkc")]
		internal static extern int IBaseFileSystem_Write(IntPtr ptr, IntPtr input, int size, IntPtr file);

		[DllImport("sourcesdkc")]
		internal static extern IntPtr IBaseFileSystem_Open(IntPtr ptr, string fileName, string options, string pathID);
		[DllImport("sourcesdkc")]
		internal static extern void IBaseFileSystem_Close(IntPtr ptr, IntPtr file);

		[DllImport("sourcesdkc")]
		internal static extern void IBaseFileSystem_Seek(IntPtr ptr, IntPtr file, int pos, in FileSystemSeek_t seekType);
		[DllImport("sourcesdkc")]
		internal static extern uint IBaseFileSystem_Tell(IntPtr ptr, IntPtr file);
		[DllImport("sourcesdkc")]
		internal static extern uint IBaseFileSystem_Size(IntPtr ptr, IntPtr file);
		[DllImport("sourcesdkc")]
		internal static extern uint IBaseFileSystem_Size_string_string(IntPtr ptr, string fileName, string pathID);

		[DllImport("sourcesdkc")]
		internal static extern void IBaseFileSystem_Flush(IntPtr ptr, IntPtr file);
		[DllImport("sourcesdkc")]
		internal static extern bool IBaseFileSystem_Precache(IntPtr ptr, string fileName, string pathID);

		[DllImport("sourcesdkc")]
		internal static extern bool IBaseFileSystem_FileExists(IntPtr ptr, string fileName, string pathID);
		[DllImport("sourcesdkc")]
		internal static extern bool IBaseFileSystem_IsFileWritable(IntPtr ptr, string fileName, string pathID);
		[DllImport("sourcesdkc")]
		internal static extern bool IBaseFileSystem_SetFileWritable(IntPtr ptr, string fileName, bool writeable, string pathID);

		[DllImport("sourcesdkc")]
		internal static extern long IBaseFileSystem_GetFileTime(IntPtr ptr, string fileName, string pathID);

		//TODO: CUtlBuffer
	}
	internal interface IBaseFileSystem
	{
		int Read(IntPtr output, int size, IntPtr file);
		int Write(IntPtr input, int size, IntPtr file);

		IntPtr Open(string fileName, string options, string pathID);
		void Close(IntPtr file);

		void Seek(IntPtr file, int pos, in FileSystemSeek_t seekType);
		uint Tell(IntPtr file);
		uint Size(IntPtr file);
		uint Size(string fileName, string pathID);

		void Flush(IntPtr file);
		bool Precache(string fileName, string pathID);

		bool FileExists(string fileName, string pathID);
		bool IsFileWriteable(string fileName, string pathID);
		bool SetFileWriteable(string fileName, bool writeable, string pathID);

		long GetFileTime(string fileName, string pathID);


	}
	internal interface IFileSystem
	{
		bool IsSteam();



		void PrintSearchPaths();
	}

	public class BaseFileSystem : IBaseFileSystem
	{
		public const string BASEFILESYSTEM_INTERFACE_VERSION = "VBaseFileSystem011";

		static BaseFileSystem() => NativeLibraryResolver.Init();

		protected readonly IntPtr ptr;

		public BaseFileSystem(IntPtr ptr) => this.ptr = ptr;

		public int Read(IntPtr output, int size, IntPtr file) => FileSystemH.IBaseFileSystem_Read(ptr, output, size, file);
		public int Write(IntPtr input, int size, IntPtr file) => FileSystemH.IBaseFileSystem_Write(ptr, input, size, file);

		public IntPtr Open(string fileName, string options, string pathID) => FileSystemH.IBaseFileSystem_Open(ptr, fileName, options, pathID);
		public void Close(IntPtr file) => FileSystemH.IBaseFileSystem_Close(ptr, file);

		public void Seek(IntPtr file, int pos, in FileSystemSeek_t seekType) => FileSystemH.IBaseFileSystem_Seek(ptr, file, pos, seekType);
		public uint Tell(IntPtr file) => FileSystemH.IBaseFileSystem_Tell(ptr, file);
		public uint Size(IntPtr file) => FileSystemH.IBaseFileSystem_Size(ptr, file);
		public uint Size(string fileName, string pathID) => FileSystemH.IBaseFileSystem_Size_string_string(ptr, fileName, pathID);

		public void Flush(IntPtr file) => FileSystemH.IBaseFileSystem_Flush(ptr, file);
		public bool Precache(string fileName, string pathID) => FileSystemH.IBaseFileSystem_Precache(ptr, fileName, pathID);

		public bool FileExists(string fileName, string pathID) => FileSystemH.IBaseFileSystem_FileExists(ptr, fileName, pathID);
		public bool IsFileWriteable(string fileName, string pathID) => FileSystemH.IBaseFileSystem_IsFileWritable(ptr, fileName, pathID);
		public bool SetFileWriteable(string fileName, bool writeable, string pathID) => FileSystemH.IBaseFileSystem_SetFileWritable(ptr, fileName, writeable, pathID);

		public long GetFileTime(string fileName, string pathID) => FileSystemH.IBaseFileSystem_GetFileTime(ptr, fileName, pathID);
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
		public void Close(IntPtr file) => FileSystemH.IBaseFileSystem_Close(ptr, file);

		public void Seek(IntPtr file, int pos, in FileSystemSeek_t seekType) => FileSystemH.IBaseFileSystem_Seek(ptr, file, pos, seekType);
		public uint Tell(IntPtr file) => FileSystemH.IBaseFileSystem_Tell(ptr, file);
		public uint Size(IntPtr file) => FileSystemH.IBaseFileSystem_Size(ptr, file);
		public uint Size(string fileName, string pathID) => FileSystemH.IBaseFileSystem_Size_string_string(ptr, fileName, pathID);

		public void Flush(IntPtr file) => FileSystemH.IBaseFileSystem_Flush(ptr, file);
		public bool Precache(string fileName, string pathID) => FileSystemH.IBaseFileSystem_Precache(ptr, fileName, pathID);

		public bool FileExists(string fileName, string pathID) => FileSystemH.IBaseFileSystem_FileExists(ptr, fileName, pathID);
		public bool IsFileWriteable(string fileName, string pathID) => FileSystemH.IBaseFileSystem_IsFileWritable(ptr, fileName, pathID);
		public bool SetFileWriteable(string fileName, bool writeable, string pathID) => FileSystemH.IBaseFileSystem_SetFileWritable(ptr, fileName, writeable, pathID);

		public long GetFileTime(string fileName, string pathID) => FileSystemH.IBaseFileSystem_GetFileTime(ptr, fileName, pathID);
	}
}
