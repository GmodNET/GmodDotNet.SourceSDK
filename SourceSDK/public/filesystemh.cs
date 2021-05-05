using GmodNET.SourceSDK.AppFramework;
using GmodNET.SourceSDK.tier1;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace GmodNET.SourceSDK
{
	public delegate void FileSystemLoggingFunc_t(string fileName, string accessType);
	/// <summary>File system allocation functions. Client must free on failure</summary>
	public delegate void FSAllocFunc_t(string szFileName, uint bytes);
	/// <summary>Used to display dirty disk error functions</summary>
	public delegate void FSDirtyDiskReportFunc_t();
	/// <summary>Completion callback for each async file serviced (or failed)</summary>
	public delegate void FSAsyncCallbackFunc_t(ref FileAsyncRequest_t request, int bytesRead, FSAsyncStatus_t err);

	#region Structs
	public struct FileAsyncRequest_t
	{
		static FileAsyncRequest_t() => throw new NotImplementedException("TODO");

		//FileAsyncRequest_t() { memset(this, 0, sizeof(*this) ); hSpecificAsyncFile = FS_INVALID_ASYNC_FILE; }
		/// <summary>file system name</summary>
		public string szFilename;
		/// <summary>optional, system will alloc/free if NULL</summary>
		public IntPtr data;
		/// <summary>optional initial seek_set, 0=beginning</summary>
		public int offset;
		/// <summary>optional read clamp, -1=exist test, 0=full read</summary>
		public int bytes;
		/// <summary>optional completion callback</summary>
		public FSAsyncCallbackFunc_t fnCallback;
		/// <summary>caller's unique file identifier</summary>
		public IntPtr context;
		/// <summary>inter list priority, 0=lowest</summary>
		public int priority;
		/// <summary>behavior modifier</summary>
		public FSAsyncFlags_t flags;
		/// <summary>path ID (NOTE: this field is here to remain binary compatible with release HL2 filesystem interface)</summary>
		public string szPathID;
		/// <summary>Optional hint obtained using AsyncBeginRead()</summary>
		public IntPtr hSpecificAsyncFile;
		/// <summary>custom allocator. can be null. not compatible with FSASYNC_FLAGS_FREEDATAPTR</summary>
		public FSAllocFunc_t fnAlloc;
	}
	public struct FileHash_t : IEquatable<FileHash_t>
	{
		public enum EFileHashType_t
		{
			k_EFileHashTypeUnknown = 0,
			k_EFileHashTypeEntireFile = 1,
			k_EFileHashTypeIncompleteFile = 2,
		}

		public EFileHashType_t m_eFileHashType;
		public uint m_crcIOSequence;
		public MD5Value_t m_md5contents;
		public int m_cbFileLen;
		public int m_PackFileID;
		public int m_nPackFileNumber;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(FileHash_t obj1, FileHash_t obj2) => obj1.m_crcIOSequence == obj2.m_crcIOSequence && obj1.m_md5contents == obj2.m_md5contents && obj1.m_eFileHashType == obj2.m_eFileHashType;
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(FileHash_t obj1, FileHash_t obj2) => obj1.m_crcIOSequence != obj2.m_crcIOSequence || obj1.m_md5contents != obj2.m_md5contents || obj1.m_eFileHashType != obj2.m_eFileHashType;

		public override bool Equals(object obj) => this == (FileHash_t)obj;
		public override int GetHashCode() => base.GetHashCode();

		public bool Equals(FileHash_t other) => this == other;
	}

	#endregion

	#region Enums
	/// <summary>How strict will the pure server be for a particular set of files</summary>
	public enum EPureServerFileClass
	{
		/// <summary>dummy debugging value</summary>
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
	/// <summary>search path filtering</summary>
	public enum PathTypeFilter_t
	{
		/// <summary>no filtering, all search path types match</summary>
		FILTER_NONE = 0,
		/// <summary>pack based search paths are culled (maps and zips)</summary>
		FILTER_CULLPACK = 1,
		/// <summary>non-pack based search paths are culled</summary>
		FILTER_CULLNONPACK = 2,
	}
	/// <summary>search path querying (bit flags)</summary>
	public enum PathTypeQuery_t
	{
		/// <summary>normal path, not pack based</summary>
		PATH_IS_NORMAL = 0x00,
		/// <summary>path is a pack file</summary>
		PATH_IS_PACKFILE = 0x01,
		/// <summary>path is a map pack file</summary>
		PATH_IS_MAPPACKFILE = 0x02,
		/// <summary>path is the remote filesystem</summary>
		PATH_IS_REMOTE = 0x04,
	}
	public enum DVDMode_t
	{
		/// <summary>not using dvd</summary>
		DVDMODE_OFF = 0,
		/// <summary>dvd device only</summary>
		DVDMODE_STRICT = 1,
		/// <summary>dev mode, mutiple devices ok</summary>
		DVDMODE_DEV = 2
	}
	public enum FilesystemMountRetval_t
	{
		FILESYSTEM_MOUNT_OK = 0,
		FILESYSTEM_MOUNT_FAILED = 1
	}
	public enum SearchPathAdd_t
	{
		/// <summary>First path searched</summary>
		PATH_ADD_TO_HEAD = 0,
		/// <summary>Last path searched</summary>
		PATH_ADD_TO_TAIL = 1
	}
	public enum FilesystemOpenExFlags_t
	{
		FSOPEN_UNBUFFERED = (1 << 0),
		/// <summary>This makes it calculate a CRC for the file (if the file came from disk) regardless of the IFileList passed to RegisterFileWhitelist.</summary>
		FSOPEN_FORCE_TRACK_CRC = (1 << 1),
		/// <summary>360 only, hint to FS that file is not allowed to be in pack file</summary>
		FSOPEN_NEVERINPACK = (1 << 2),
	}
	/// <summary>Async file status</summary>
	public enum FSAsyncStatus_t
	{
		///<summary>Filename not part of the specified file system, try a different one.  (Used internally to find the right filesystem)</summary>
		FSASYNC_ERR_NOT_MINE = -8,
		///<summary>Failure for a reason that might be temporary.  You might retry, but not immediately.  (E.g. Network problems)</summary>
		FSASYNC_ERR_RETRY_LATER = -7,
		///<summary>read parameters invalid for unbuffered IO</summary>
		FSASYNC_ERR_ALIGNMENT = -6,
		///<summary>hard subsystem failure</summary>
		FSASYNC_ERR_FAILURE = -5,
		///<summary>read error on file</summary>
		FSASYNC_ERR_READING = -4,
		///<summary>out of memory for file read</summary>
		FSASYNC_ERR_NOMEMORY = -3,
		///<summary>caller's provided id is not recognized</summary>
		FSASYNC_ERR_UNKNOWNID = -2,
		///<summary>filename could not be opened (bad path, not exist, etc)</summary>
		FSASYNC_ERR_FILEOPEN = -1,
		///<summary>operation is successful</summary>
		FSASYNC_OK = 0,
		///<summary>file is properly queued, waiting for service</summary>
		FSASYNC_STATUS_PENDING = 1,
		///<summary>file is being accessed</summary>
		FSASYNC_STATUS_INPROGRESS = 2,
		///<summary>file was aborted by caller</summary>
		FSASYNC_STATUS_ABORTED = 3,
		///<summary>file is not yet queued</summary>
		FSASYNC_STATUS_UNSERVICED = 4,
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
	/// <summary>Return value for CheckFileCRC.</summary>
	public enum EFileCRCStatus
	{
		/// <summary>We don't have this file.</summary>
		k_eFileCRCStatus_CantOpenFile = 0,
		k_eFileCRCStatus_GotCRC = 1,
		k_eFileCRCStatus_FileInVPK = 2
	}
	/// <summary>Used in CacheFileCRCs.</summary>
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
		internal static extern bool IFileSystem_RemoveSearchPath(IntPtr ptr, string path, string pathID = null);
		[DllImport("sourcesdkc")]
		internal static extern void IFileSystem_RemoveAllSearchPaths(IntPtr ptr);
		[DllImport("sourcesdkc")]
		internal static extern void IFileSystem_RemoveSearchPaths(IntPtr ptr, string pathID);

		[DllImport("sourcesdkc")]
		internal static extern void IFileSystem_MarkPathIDByRequestOnly(IntPtr ptr, string pathID, bool requestOnly);
		[DllImport("sourcesdkc")]
		internal static extern string IFileSystem_RelativePathToFullPath(IntPtr ptr, string fileName, string pathID, out string dest, int maxLenInChars, PathTypeFilter_t pathFilter = PathTypeFilter_t.FILTER_NONE, in PathTypeQuery_t pathType = PathTypeQuery_t.PATH_IS_NORMAL);
		[DllImport("sourcesdkc")]
		internal static extern int IFileSystem_GetSearchPath(IntPtr ptr, string pathID, bool getPackFiles, out string dest, int maxLenInChars);
		[DllImport("sourcesdkc")]
		internal static extern bool IFileSystem_AddPackFile(IntPtr ptr, string fullpath, string pathID);

		[DllImport("sourcesdkc")]
		internal static extern void IFileSystem_RemoveFile(IntPtr ptr, string relativePath, string pathID = null);
		[DllImport("sourcesdkc")]
		internal static extern bool IFileSystem_RenameFile(IntPtr ptr, string oldPath, string newPath, string pathID = null);
		[DllImport("sourcesdkc")]
		internal static extern void IFileSystem_CreateDirHierarchy(IntPtr ptr, string path, string pathID = null);
		[DllImport("sourcesdkc")]
		internal static extern bool IFileSystem_IsDirectory(IntPtr ptr, string fileName, string pathID = null);
		[DllImport("sourcesdkc")]
		internal static extern void IFileSystem_FileTimeToString(IntPtr ptr, out string strip, int maxCharsIncludingTerminator, long fileTime);

		[DllImport("sourcesdkc")]
		internal static extern void IFileSystem_SetBufferSize(IntPtr ptr, IntPtr file, uint bytes);
		[DllImport("sourcesdkc")]
		internal static extern bool IFileSystem_IsOk(IntPtr ptr, IntPtr file);
		[DllImport("sourcesdkc")]
		internal static extern bool IFileSystem_EndOfFile(IntPtr ptr, IntPtr file);
		[DllImport("sourcesdkc")]
		internal static extern string IFileSystem_ReadLine(IntPtr ptr, out string output, int maxChars, IntPtr file);
		[DllImport("sourcesdkc")]
		internal static extern int IFileSystem_FPrintf(IntPtr ptr, IntPtr file, string format, string msg = null);

		[DllImport("sourcesdkc")]
		internal static extern IntPtr IFileSystem_LoadModule(IntPtr ptr, string fileName, string pathID = null, bool validatedDllOnly = true);
		[DllImport("sourcesdkc")]
		internal static extern void IFileSystem_UnloadModule(IntPtr ptr, IntPtr module);

		[DllImport("sourcesdkc")]
		internal static extern string IFileSystem_FindFirst(IntPtr ptr, string wildCard, out int handle);
		[DllImport("sourcesdkc")]
		internal static extern string IFileSystem_FindNext(IntPtr ptr, int handle);
		[DllImport("sourcesdkc")]
		internal static extern bool IFileSystem_FindIsDirectory(IntPtr ptr, int handle);
		[DllImport("sourcesdkc")]
		internal static extern void IFileSystem_FindClose(IntPtr ptr, int handle);
		[DllImport("sourcesdkc")]
		internal static extern string IFileSystem_FindFirstEx(IntPtr ptr, string wildCard, string pathID, out int handle);

		[DllImport("sourcesdkc")]
		internal static extern string IFileSystem_GetLocalPath(IntPtr ptr, string fileName, ref string dest, int maxlen);
		[DllImport("sourcesdkc", CharSet = CharSet.Ansi)]
		[return: MarshalAs(UnmanagedType.I1)]
		internal static extern bool IFileSystem_FullPathToRelativePath(IntPtr ptr, string fullPath, ref string dest, int maxLenInChars);

		[DllImport("sourcesdkc", CharSet = CharSet.Ansi)]
		internal static extern bool IFileSystem_GetCurrentDirectory(IntPtr ptr, ref string pDirectory, int maxlen);

		[DllImport("sourcesdkc", CharSet = CharSet.Ansi)]
		internal static extern IntPtr IFileSystem_FindOrAddFileName(IntPtr ptr, string fileName);

		[DllImport("sourcesdkc", CharSet = CharSet.Ansi)]
		internal static extern bool IFileSystem_String(IntPtr ptr, IntPtr handle, ref string buffer, int bufMaxLen);

		[DllImport("sourcesdkc")]
		internal static extern void IFileSystem_PrintSearchPaths(IntPtr ptr);
	}

	internal interface IBaseFileSystem
	{
		int Read(IntPtr output, int size, IntPtr file);
		int Write(IntPtr input, int size, IntPtr file);

		/// <param name="fileName"></param>
		/// <param name="options"></param>
		/// <param name="pathID">if null, all paths will be searched for the file</param>
		/// <returns></returns>
		IntPtr Open(string fileName, string options, string pathID = null);
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
		#region Steam operations
		bool IsSteam();
		FilesystemMountRetval_t MountSteamContent(int extraAppId = -1);
		#endregion
		#region Search path manipulation
		/// <summary>
		/// Add paths in priority order (mod dir, game dir, ....)
		/// If the path is the relative path to a .bsp file, then any previous .bsp file 
		///  override is cleared and the current .bsp is searched for an embedded PAK file
		///  and this file becomes the highest priority search path ( i.e., it's looked at first
		///   even before the mod's file system path ).
		/// </summary>
		/// <param name="path">If one or more .pak files are in the specified directory, then they are added after the file system path</param>
		/// <param name="pathID"></param>
		/// <param name="addType"></param>
		void AddSearchPath(string path, string pathID, SearchPathAdd_t addType = SearchPathAdd_t.PATH_ADD_TO_TAIL);
		bool RemoveSearchPath(string path, string pathID = null);
		/// <summary>Remove all search paths (including write path?)</summary>
		void RemoveAllSearchPaths();
		/// <summary>Remove search paths associated with a given pathID</summary>
		void RemoveSearchPaths(string pathID);
		/// <summary>
		/// This is for optimization. If you mark a path ID as "by request only", then files inside it
		/// will only be accessed if the path ID is specifically requested. Otherwise, it will be ignored.
		/// If there are currently no search paths with the specified path ID, then it will still
		/// remember it in case you add search paths with this path ID.
		/// </summary>
		void MarkPathIDByRequestOnly(string pathID, bool requestOnly);
		/// <summary>converts a partial path into a full path</summary>
		string RelativePathToFullPath(string fileName, string pathID, out string dest, int maxLenInChars, PathTypeFilter_t pathFilter = PathTypeFilter_t.FILTER_NONE, in PathTypeQuery_t pathType = PathTypeQuery_t.PATH_IS_NORMAL);
		/// <summary>Returns the search path</summary>
		/// <param name="dest">the search path, each path is separated by ;s</param>
		/// <returns>the length of the string returned</returns>
		int GetSearchPath(string pathID, bool getPackFiles, out string dest, int maxLenInChars);
		/// <summary>interface for custom pack files > 4Gb</summary>
		bool AddPackFile(string fullpath, string pathID);
		#endregion
		#region File manipulation operations
		///<summary>Deletes a file (on the WritePath)</summary>
		void RemoveFile(string relativePath, string pathID = null);
		///<summary>Renames a file (on the WritePath)</summary>
		bool RenameFile(string oldPath, string newPath, string pathID = null);
		///<summary>create a local directory structure</summary>
		void CreateDirHierarchy(string path, string pathID = null);
		bool IsDirectory(string fileName, string pathID = null);
		void FileTimeToString(out string strip, int maxCharsIncludingTerminator, long fileTime);
		#endregion
		#region Open file operations
		void SetBufferSize(IntPtr file, uint bytes);
		bool IsOk(IntPtr file);
		bool EndOfFile(IntPtr file);
		string ReadLine(out string output, int maxChars, IntPtr file);
		int FPrintf(IntPtr file, string format, string msg = null);
		#endregion
		#region Dynamic library operations
		IntPtr IFileSystem_LoadModule(string fileName, string pathID = null, bool validatedDllOnly = true);
		void IFileSystem_UnloadModule(IntPtr module);
		#endregion
		#region File searching operations
		string IFileSystem_FindFirst(string wildCard, out int handle);
		string IFileSystem_FindNext(int handle);
		bool IFileSystem_FindIsDirectory(int handle);
		void IFileSystem_FindClose(int handle);
		string IFileSystem_FindFirstEx(string wildCard, string pathID, out int handle);
		#endregion
		void PrintSearchPaths();
	}

	public class BaseFileSystem : IBaseFileSystem
	{
		public const string BASEFILESYSTEM_INTERFACE_VERSION = "VBaseFileSystem011";

		protected readonly IntPtr ptr;

		public BaseFileSystem(IntPtr ptr) => this.ptr = ptr;

		public int Read(IntPtr output, int size, IntPtr file) => BaseFileSystem_c.IBaseFileSystem_Read(ptr, output, size, file);
		public int Write(IntPtr input, int size, IntPtr file) => BaseFileSystem_c.IBaseFileSystem_Write(ptr, input, size, file);

		public IntPtr Open(string fileName, string options, string pathID = null) => BaseFileSystem_c.IBaseFileSystem_Open(ptr, fileName, options, pathID);
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
		public const int FILESYSTEM_INVALID_FIND_HANDLE = -1;
		public static readonly IntPtr FILESYSTEM_INVALID_HANDLE = IntPtr.Zero;
		public const int FS_INVALID_ASYNC_FILE = 0x0000ffff;

		public const string FILESYSTEM_INTERFACE_VERSION = "VFileSystem022";

		public FileSystem(IntPtr ptr) : base(ptr) { }

		#region IBaseFileSystem

		public int Read(IntPtr output, int size, IntPtr file) => BaseFileSystem_c.IBaseFileSystem_Read(ptr, output, size, file);
		public int Write(IntPtr input, int size, IntPtr file) => BaseFileSystem_c.IBaseFileSystem_Write(ptr, input, size, file);

		public IntPtr Open(string fileName, string options, string pathID = null) => BaseFileSystem_c.IBaseFileSystem_Open(ptr, fileName, options, pathID);
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

		#endregion

		public bool IsSteam() => FileSystem_c.IFileSystem_IsSteam(ptr);

		public FilesystemMountRetval_t MountSteamContent(int extraAppId = -1) => FileSystem_c.IFileSystem_MountSteamContent(ptr, extraAppId);

		public void AddSearchPath(string path, string pathID, SearchPathAdd_t addType = SearchPathAdd_t.PATH_ADD_TO_TAIL) => FileSystem_c.IFileSystem_AddSearchPath(ptr, path, pathID, addType);
		public bool RemoveSearchPath(string path, string pathID = null) => FileSystem_c.IFileSystem_RemoveSearchPath(ptr, path, pathID);
		public void RemoveAllSearchPaths() => FileSystem_c.IFileSystem_RemoveAllSearchPaths(ptr);
		public void RemoveSearchPaths(string pathID) => FileSystem_c.IFileSystem_RemoveSearchPaths(ptr, pathID);

		public void MarkPathIDByRequestOnly(string pathID, bool requestOnly) => FileSystem_c.IFileSystem_MarkPathIDByRequestOnly(ptr, pathID, requestOnly);
		public string RelativePathToFullPath(string fileName, string pathID, out string dest, int maxLenInChars, PathTypeFilter_t pathFilter = PathTypeFilter_t.FILTER_NONE, in PathTypeQuery_t pathType = PathTypeQuery_t.PATH_IS_NORMAL) => FileSystem_c.IFileSystem_RelativePathToFullPath(ptr, fileName, pathID, out dest, maxLenInChars, pathFilter, pathType);
		public int GetSearchPath(string pathID, bool getPackFiles, out string dest, int maxLenInChars) => FileSystem_c.IFileSystem_GetSearchPath(ptr, pathID, getPackFiles, out dest, maxLenInChars);
		public bool AddPackFile(string fullpath, string pathID) => FileSystem_c.IFileSystem_AddPackFile(ptr, fullpath, pathID);

		public void RemoveFile(string relativePath, string pathID = null) => FileSystem_c.IFileSystem_RemoveFile(ptr, relativePath, pathID);
		public bool RenameFile(string oldPath, string newPath, string pathID = null) => FileSystem_c.IFileSystem_RenameFile(ptr, oldPath, newPath, pathID);
		public void CreateDirHierarchy(string path, string pathID = null) => FileSystem_c.IFileSystem_CreateDirHierarchy(ptr, path, pathID);
		public bool IsDirectory(string fileName, string pathID = null) => FileSystem_c.IFileSystem_IsDirectory(ptr, fileName, pathID);
		public void FileTimeToString(out string strip, int maxCharsIncludingTerminator, long fileTime) => FileSystem_c.IFileSystem_FileTimeToString(ptr, out strip, maxCharsIncludingTerminator, fileTime);

		public void SetBufferSize(IntPtr file, uint bytes) => FileSystem_c.IFileSystem_SetBufferSize(ptr, file, bytes);
		public bool IsOk(IntPtr file) => FileSystem_c.IFileSystem_IsOk(ptr, file);
		public bool EndOfFile(IntPtr file) => FileSystem_c.IFileSystem_EndOfFile(ptr, file);
		public string ReadLine(out string output, int maxChars, IntPtr file) => FileSystem_c.IFileSystem_ReadLine(ptr, out output, maxChars, file);
		public int FPrintf(IntPtr file, string format, string msg = null) => FileSystem_c.IFileSystem_FPrintf(ptr, file, format, msg);

		public IntPtr IFileSystem_LoadModule(string fileName, string pathID = null, bool validatedDllOnly = true) => FileSystem_c.IFileSystem_LoadModule(ptr, fileName, pathID, validatedDllOnly);
		public void IFileSystem_UnloadModule(IntPtr module) => FileSystem_c.IFileSystem_UnloadModule(ptr, module);

		public string IFileSystem_FindFirst(string wildCard, out int handle) => FileSystem_c.IFileSystem_FindFirst(ptr, wildCard, out handle);
		public string IFileSystem_FindNext(int handle) => FileSystem_c.IFileSystem_FindNext(ptr, handle);
		public bool IFileSystem_FindIsDirectory(int handle) => FileSystem_c.IFileSystem_FindIsDirectory(ptr, handle);
		public void IFileSystem_FindClose(int handle) => FileSystem_c.IFileSystem_FindClose(ptr, handle);
		public string IFileSystem_FindFirstEx(string wildCard, string pathID, out int handle) => FileSystem_c.IFileSystem_FindFirstEx(ptr, wildCard, pathID, out handle);

		public void PrintSearchPaths() => FileSystem_c.IFileSystem_PrintSearchPaths(ptr);
	}
}
