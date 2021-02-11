using GmodNET.SourceSDK.AppFramework;
using System;
using System.Runtime.InteropServices;

namespace GmodNET.SourceSDK
{
	#region Enums

	public enum EPureServerFileClass
	{
		/// <summary>
		/// dummy debugging value
		/// </summary>
		ePureServerFileClass_Unknown = -1,
		ePureServerFileClass_Any = 0,
		ePureServerFileClass_AnyTrusted = 1,
		ePureServerFileClass_CheckHash = 2,
	}
	public enum FileSystemSeek_t
	{
		FILESYSTEM_SEEK_HEAD = 0,
		FILESYSTEM_SEEK_CURRENT = 1,
		FILESYSTEM_SEEK_TAIL = 2,
	}
	public enum FileSystem_Handle
	{
		FILESYSTEM_INVALID_FIND_HANDLE = -1
	}
	public enum FileWarningLevel_t
	{
		/// <summary>A problem!</summary>
		FILESYSTEM_WARNING = -1,
		/// <summary>Don't print anything</summary>
		FILESYSTEM_WARNING_QUIET = 0,
		///<summary>On shutdown, report names of files left unclosed</summary>
		FILESYSTEM_WARNING_REPORTUNCLOSED = 1,
		/// <summary>Report number of times a file was opened, closed</summary>
		FILESYSTEM_WARNING_REPORTUSAGE = 2,
		/// <summary>Report all open/close events to console ( !slow! )</summary>
		FILESYSTEM_WARNING_REPORTALLACCESSES = 3,
		/// <summary>Report all open/close/read events to the console ( !slower! )</summary>
		FILESYSTEM_WARNING_REPORTALLACCESSES_READ = 4,
		/// <summary>Report all open/close/read/write events to the console ( !slower! )</summary>
		FILESYSTEM_WARNING_REPORTALLACCESSES_READWRITE = 5,
		/// <summary>Report all open/close/read/write events and all async I/O file events to the console ( !slower(est)! )</summary>
		FILESYSTEM_WARNING_REPORTALLACCESSES_ASYNC = 6,
	}
	/// <summary>
	/// search path filtering
	/// </summary>
	public enum PathTypeFilter_t
	{
		/// <summary>
		/// no filtering, all search path types match
		/// </summary>
		FILTER_NONE = 0,
		/// <summary>
		/// pack based search paths are culled (maps and zips)
		/// </summary>
		FILTER_CULLPACK = 1,
		/// <summary>
		/// non-pack based search paths are culled
		/// </summary>
		FILTER_CULLNONPACK = 2,
	}
	// search path querying (bit flags)
	public enum PATH
	{
		/// <summary>
		/// normal path, not pack based
		/// </summary>
		PATH_IS_NORMAL = 0x00,
		/// <summary>
		/// path is a pack file
		/// </summary>
		PATH_IS_PACKFILE = 0x01,
		/// <summary>
		/// path is a map pack file
		/// </summary>
		PATH_IS_MAPPACKFILE = 0x02,
		/// <summary>
		/// path is the remote filesystem
		/// </summary>
		PATH_IS_REMOTE = 0x04,
	}
	public enum DVDMode_t
	{
		/// <summary>
		/// not using dvd
		/// </summary>
		DVDMODE_OFF = 0,
		/// <summary>
		/// dvd device only
		/// </summary>
		DVDMODE_STRICT = 1,
		/// <summary>
		/// dev mode, mutiple devices ok
		/// </summary>
		DVDMODE_DEV = 2
	}
	public enum FilesystemMountRetval_t
	{
		FILESYSTEM_MOUNT_OK = 0,
		FILESYSTEM_MOUNT_FAILED = 1
	}
	public enum SearchPathAdd_t
	{
		/// <summary>
		/// First path searched
		/// </summary>
		PATH_ADD_TO_HEAD = 0,
		/// <summary>
		/// Last path searched
		/// </summary>
		PATH_ADD_TO_TAIL = 1
	}
	public enum FilesystemOpenExFlags_t
	{
		FSOPEN_UNBUFFERED = (1 << 0),
		FSOPEN_FORCE_TRACK_CRC = (1 << 1),      // This makes it calculate a CRC for the file (if the file came from disk) regardless 
												// of the IFileList passed to RegisterFileWhitelist.
		FSOPEN_NEVERINPACK = (1 << 2),      // 360 only, hint to FS that file is not allowed to be in pack file
	}
	public enum FSAsyncStatus_t
	{
		FSASYNC_ERR_NOT_MINE = -8,  // Filename not part of the specified file system, try a different one.  (Used internally to find the right filesystem)
		FSASYNC_ERR_RETRY_LATER = -7,   // Failure for a reason that might be temporary.  You might retry, but not immediately.  (E.g. Network problems)
		FSASYNC_ERR_ALIGNMENT = -6, // read parameters invalid for unbuffered IO
		FSASYNC_ERR_FAILURE = -5,   // hard subsystem failure
		FSASYNC_ERR_READING = -4,   // read error on file
		FSASYNC_ERR_NOMEMORY = -3,  // out of memory for file read
		FSASYNC_ERR_UNKNOWNID = -2, // caller's provided id is not recognized
		FSASYNC_ERR_FILEOPEN = -1,  // filename could not be opened (bad path, not exist, etc)
		FSASYNC_OK = 0, // operation is successful
		FSASYNC_STATUS_PENDING = 1,         // file is properly queued, waiting for service
		FSASYNC_STATUS_INPROGRESS = 2,      // file is being accessed
		FSASYNC_STATUS_ABORTED = 3,         // file was aborted by caller
		FSASYNC_STATUS_UNSERVICED = 4,      // file is not yet queued
	}
	public enum FSAsyncFlags_t
	{
		/// <summary>
		/// do the allocation for dataPtr, but don't free
		/// </summary>
		FSASYNC_FLAGS_ALLOCNOFREE = (1 << 0),
		/// <summary>
		/// free the memory for the dataPtr post callback
		/// </summary>
		FSASYNC_FLAGS_FREEDATAPTR = (1 << 1),
		/// <summary>
		/// Actually perform the operation synchronously. Used to simplify client code paths
		/// </summary>
		FSASYNC_FLAGS_SYNC = (1 << 2),
		/// <summary>
		/// allocate an extra byte and null terminate the buffer read in
		/// </summary>
		FSASYNC_FLAGS_NULLTERMINATE = (1 << 3)
	}
	/// <summary>
	/// Return value for CheckFileCRC.
	/// </summary>
	public enum EFileCRCStatus
	{
		/// <summary>
		/// We don't have this file. 
		/// </summary>
		k_eFileCRCStatus_CantOpenFile = 0,
		k_eFileCRCStatus_GotCRC = 1,
		k_eFileCRCStatus_FileInVPK = 2
	}
	/// <summary>
	/// Used in CacheFileCRCs.
	/// </summary>
	public enum ECacheCRCType
	{
		k_eCacheCRCType_SingleFile = 0,
		k_eCacheCRCType_Directory = 1,
		k_eCacheCRCType_Directory_Recursive = 2
	}

	#endregion

	internal static class BaseFileSystem_c
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

	internal static class FileSystem_c
	{
		[DllImport("sourcesdkc")]
		internal static extern bool IFileSystem_IsSteam(IntPtr ptr);

		[DllImport("sourcesdkc")]
		internal static extern FilesystemMountRetval_t IFileSystem_MountSteamContent(IntPtr ptr, int extraAppId = -1);
		[DllImport("sourcesdkc")]
		internal static extern void IFileSystem_AddSearchPath(IntPtr ptr, string path, string pathID, SearchPathAdd_t addType = SearchPathAdd_t.PATH_ADD_TO_TAIL);
		[DllImport("sourcesdkc")]
		internal static extern bool IFileSystem_RemoveSearchPath(IntPtr ptr, string path, string pathID);
		[DllImport("sourcesdkc")]
		internal static extern void IFileSystem_RemoveAllSearchPaths(IntPtr ptr);
		[DllImport("sourcesdkc")]
		internal static extern void IFileSystem_RemoveSearchPaths(IntPtr ptr, string pathID);

		[DllImport("sourcesdkc")]
		internal static extern void IFileSystem_PrintSearchPaths(IntPtr ptr);
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

		FilesystemMountRetval_t MountSteamContent(int extraAppId = -1);

		void AddSearchPath(string path, string pathID, SearchPathAdd_t addType = SearchPathAdd_t.PATH_ADD_TO_TAIL);
		bool RemoveSearchPath(string path, string pathID);
		void RemoveAllSearchPaths();
		void RemoveSearchPaths(string pathID);


		void PrintSearchPaths();
	}

	public class BaseFileSystem : IBaseFileSystem
	{
		public const string BASEFILESYSTEM_INTERFACE_VERSION = "VBaseFileSystem011";

		static BaseFileSystem() => NativeLibraryResolver.Init();

		protected readonly IntPtr ptr;

		public BaseFileSystem(IntPtr ptr) => this.ptr = ptr;

		public int Read(IntPtr output, int size, IntPtr file) => BaseFileSystem_c.IBaseFileSystem_Read(ptr, output, size, file);
		public int Write(IntPtr input, int size, IntPtr file) => BaseFileSystem_c.IBaseFileSystem_Write(ptr, input, size, file);

		public IntPtr Open(string fileName, string options, string pathID) => BaseFileSystem_c.IBaseFileSystem_Open(ptr, fileName, options, pathID);
		public void Close(IntPtr file) => BaseFileSystem_c.IBaseFileSystem_Close(ptr, file);

		public void Seek(IntPtr file, int pos, in FileSystemSeek_t seekType) => BaseFileSystem_c.IBaseFileSystem_Seek(ptr, file, pos, seekType);
		public uint Tell(IntPtr file) => BaseFileSystem_c.IBaseFileSystem_Tell(ptr, file);
		public uint Size(IntPtr file) => BaseFileSystem_c.IBaseFileSystem_Size(ptr, file);
		public uint Size(string fileName, string pathID) => BaseFileSystem_c.IBaseFileSystem_Size_string_string(ptr, fileName, pathID);

		public void Flush(IntPtr file) => BaseFileSystem_c.IBaseFileSystem_Flush(ptr, file);
		public bool Precache(string fileName, string pathID) => BaseFileSystem_c.IBaseFileSystem_Precache(ptr, fileName, pathID);

		public bool FileExists(string fileName, string pathID) => BaseFileSystem_c.IBaseFileSystem_FileExists(ptr, fileName, pathID);
		public bool IsFileWriteable(string fileName, string pathID) => BaseFileSystem_c.IBaseFileSystem_IsFileWritable(ptr, fileName, pathID);
		public bool SetFileWriteable(string fileName, bool writeable, string pathID) => BaseFileSystem_c.IBaseFileSystem_SetFileWritable(ptr, fileName, writeable, pathID);

		public long GetFileTime(string fileName, string pathID) => BaseFileSystem_c.IBaseFileSystem_GetFileTime(ptr, fileName, pathID);
	}

	public class FileSystem : IAppSystem, IBaseFileSystem, IFileSystem
	{
		public const int FILESYSTEM_MAX_SEARCH_PATHS = 128;

		public const string FILESYSTEM_INTERFACE_VERSION = "VFileSystem022";

		public FileSystem(IntPtr ptr) : base(ptr) { }


		public bool IsSteam() => FileSystem_c.IFileSystem_IsSteam(ptr);

		public FilesystemMountRetval_t MountSteamContent(int extraAppId = -1) => FileSystem_c.IFileSystem_MountSteamContent(ptr, extraAppId);

		public void AddSearchPath(string path, string pathID, SearchPathAdd_t addType = SearchPathAdd_t.PATH_ADD_TO_TAIL) => FileSystem_c.IFileSystem_AddSearchPath(ptr, path, pathID, addType);
		public bool RemoveSearchPath(string path, string pathID) => FileSystem_c.IFileSystem_RemoveSearchPath(ptr, path, pathID);
		public void RemoveAllSearchPaths() => FileSystem_c.IFileSystem_RemoveAllSearchPaths(ptr);
		public void RemoveSearchPaths(string pathID) => FileSystem_c.IFileSystem_RemoveSearchPaths(ptr, pathID);


		public void PrintSearchPaths() => FileSystem_c.IFileSystem_PrintSearchPaths(ptr);

		/// IBaseFileSystem

		public int Read(IntPtr output, int size, IntPtr file) => BaseFileSystem_c.IBaseFileSystem_Read(ptr, output, size, file);
		public int Write(IntPtr input, int size, IntPtr file) => BaseFileSystem_c.IBaseFileSystem_Write(ptr, input, size, file);

		public IntPtr Open(string fileName, string options, string pathID) => BaseFileSystem_c.IBaseFileSystem_Open(ptr, fileName, options, pathID);
		public void Close(IntPtr file) => BaseFileSystem_c.IBaseFileSystem_Close(ptr, file);

		public void Seek(IntPtr file, int pos, in FileSystemSeek_t seekType) => BaseFileSystem_c.IBaseFileSystem_Seek(ptr, file, pos, seekType);
		public uint Tell(IntPtr file) => BaseFileSystem_c.IBaseFileSystem_Tell(ptr, file);
		public uint Size(IntPtr file) => BaseFileSystem_c.IBaseFileSystem_Size(ptr, file);
		public uint Size(string fileName, string pathID) => BaseFileSystem_c.IBaseFileSystem_Size_string_string(ptr, fileName, pathID);

		public void Flush(IntPtr file) => BaseFileSystem_c.IBaseFileSystem_Flush(ptr, file);
		public bool Precache(string fileName, string pathID) => BaseFileSystem_c.IBaseFileSystem_Precache(ptr, fileName, pathID);

		public bool FileExists(string fileName, string pathID) => BaseFileSystem_c.IBaseFileSystem_FileExists(ptr, fileName, pathID);
		public bool IsFileWriteable(string fileName, string pathID) => BaseFileSystem_c.IBaseFileSystem_IsFileWritable(ptr, fileName, pathID);
		public bool SetFileWriteable(string fileName, bool writeable, string pathID) => BaseFileSystem_c.IBaseFileSystem_SetFileWritable(ptr, fileName, writeable, pathID);

		public long GetFileTime(string fileName, string pathID) => BaseFileSystem_c.IBaseFileSystem_GetFileTime(ptr, fileName, pathID);
	}
}
