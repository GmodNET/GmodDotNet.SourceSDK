#include <filesystem.h>

#pragma region IBaseFileSystem
DLL_EXPORT int IBaseFileSystem_Read(IBaseFileSystem* bfs, void* pOutput, int size, FileHandle_t file) {
	return bfs->Read(pOutput, size, file);
}
DLL_EXPORT int IBaseFileSystem_Write(IBaseFileSystem* bfs, void const* pInput, int size, FileHandle_t file) {
	return bfs->Write(pInput, size, file);
}
DLL_EXPORT FileHandle_t IBaseFileSystem_Open(IBaseFileSystem* bfs, const char* pFileName, const char* pOptions, const char* pathID = 0) {
	return bfs->Open(pFileName, pOptions, pathID);
}
DLL_EXPORT void IBaseFileSystem_Close(IBaseFileSystem* bfs, FileHandle_t file) {
	bfs->Close(file);
}
DLL_EXPORT void IBaseFileSystem_Seek(IBaseFileSystem* bfs, FileHandle_t file, int pos, FileSystemSeek_t seekType) {
	bfs->Seek(file, pos, seekType);
}
DLL_EXPORT unsigned int IBaseFileSystem_Tell(IBaseFileSystem* bfs, FileHandle_t file) {
	return bfs->Tell(file);
}
DLL_EXPORT unsigned int IBaseFileSystem_Size(IBaseFileSystem* bfs, FileHandle_t file) {
	return bfs->Size(file);
}
DLL_EXPORT unsigned int IBaseFileSystem_Size_string_string(IBaseFileSystem* bfs, const char* pFileName, const char* pPathID = 0) {
	return bfs->Size(pFileName, pPathID);
}
DLL_EXPORT void IBaseFileSystem_Flush(IBaseFileSystem* bfs, FileHandle_t file) {
	bfs->Flush(file);
}
DLL_EXPORT bool IBaseFileSystem_Precache(IBaseFileSystem* bfs, const char* pFileName, const char* pPathID = 0) {
	return bfs->Precache(pFileName, pPathID);
}
DLL_EXPORT bool IBaseFileSystem_FileExists(IBaseFileSystem* bfs, const char* pFileName, const char* pPathID = 0) {
	return bfs->FileExists(pFileName, pPathID);
}
DLL_EXPORT bool IBaseFileSystem_IsFileWritable(IBaseFileSystem* bfs, const char* pFileName, const char* pPathID = 0) {
	return bfs->IsFileWritable(pFileName, pPathID);
}
DLL_EXPORT bool IBaseFileSystem_SetFileWritable(IBaseFileSystem* bfs, char const* pFileName, bool writable, const char* pPathID = 0) {
	return bfs->SetFileWritable(pFileName, writable, pPathID);
}
DLL_EXPORT long IBaseFileSystem_GetFileTime(IBaseFileSystem* bfs, const char* pFileName, const char* pPathID = 0) {
	return bfs->GetFileTime(pFileName, pPathID);
}
DLL_EXPORT bool IBaseFileSystem_ReadFile(IBaseFileSystem* bfs, const char* pFileName, const char* pPath, CUtlBuffer& buf, int nMaxBytes = 0, int nStartingByte = 0, FSAllocFunc_t pfnAlloc = NULL) {
	return bfs->ReadFile(pFileName, pPath, buf, nMaxBytes, nStartingByte, pfnAlloc);
}
DLL_EXPORT bool IBaseFileSystem_WriteFile(IBaseFileSystem* bfs, const char* pFileName, const char* pPath, CUtlBuffer& buf) {
	return bfs->WriteFile(pFileName, pPath, buf);
}
DLL_EXPORT bool IBaseFileSystem_UnzipFile(IBaseFileSystem* bfs, const char* pFileName, const char* pPath, const char* pDestination) {
	return bfs->UnzipFile(pFileName, pPath, pDestination);
}
#pragma endregion

DLL_EXPORT bool IFileSystem_IsSteam(IFileSystem* fs) {
	return fs->IsSteam();
}

DLL_EXPORT FilesystemMountRetval_t IFileSystem_MountSteamContent(IFileSystem* fs, int nExtraAppId = -1) {
	return fs->MountSteamContent(nExtraAppId);
}
DLL_EXPORT void IFileSystem_AddSearchPath(IFileSystem* fs, const char* pPath, const char* pathID, SearchPathAdd_t addType = PATH_ADD_TO_TAIL) {
	fs->AddSearchPath(pPath, pathID, addType);
}
DLL_EXPORT bool IFileSystem_RemoveSearchPath(IFileSystem* fs, const char* pPath, const char* pathID = 0) {
	return fs->RemoveSearchPath(pPath, pathID);
}
DLL_EXPORT void IFileSystem_RemoveAllSearchPaths(IFileSystem* fs) {
	fs->RemoveAllSearchPaths();
}
DLL_EXPORT void IFileSystem_RemoveSearchPaths(IFileSystem* fs, const char* szPathID) {
	fs->RemoveSearchPaths(szPathID);
}

DLL_EXPORT void IFileSystem_MarkPathIDByRequestOnly(IFileSystem* fs, const char* pPathID, bool bRequestOnly) {
	fs->MarkPathIDByRequestOnly(pPathID, bRequestOnly);
}
DLL_EXPORT const char* IFileSystem_RelativePathToFullPath(IFileSystem* fs, const char* pFileName, const char* pPathID, char* pDest, int maxLenInChars, PathTypeFilter_t pathFilter = FILTER_NONE, PathTypeQuery_t* pPathType = NULL) {
	return fs->RelativePathToFullPath(pFileName, pPathID, pDest, maxLenInChars, pathFilter, pPathType);
}
DLL_EXPORT int IFileSystem_GetSearchPath(IFileSystem* fs, const char* pathID, bool bGetPackFiles, char* pDest, int maxLenInChars) {
	return fs->GetSearchPath(pathID, bGetPackFiles, pDest, maxLenInChars);
}
DLL_EXPORT bool IFileSystem_AddPackFile(IFileSystem* fs, const char* fullpath, const char* pathID) {
	return fs->AddPackFile(fullpath, pathID);
}

DLL_EXPORT void IFileSystem_RemoveFile(IFileSystem* fs, char const* pRelativePath, const char* pathID = 0) {
	fs->RemoveFile(pRelativePath, pathID);
}
DLL_EXPORT bool IFileSystem_RenameFile(IFileSystem* fs, char const* pOldPath, char const* pNewPath, const char* pathID = 0) {
	return fs->RenameFile(pOldPath, pNewPath, pathID);
}
DLL_EXPORT void IFileSystem_CreateDirHierarchy(IFileSystem* fs, const char* path, const char* pathID = 0) {
	fs->CreateDirHierarchy(path, pathID);
}
DLL_EXPORT bool IFileSystem_IsDirectory(IFileSystem* fs, const char* pFileName, const char* pathID = 0) {
	return fs->IsDirectory(pFileName, pathID);
}
DLL_EXPORT void IFileSystem_FileTimeToString(IFileSystem* fs, char* pStrip, int maxCharsIncludingTerminator, long fileTime) {
	fs->FileTimeToString(pStrip, maxCharsIncludingTerminator, fileTime);
}

DLL_EXPORT void IFileSystem_SetBufferSize(IFileSystem* fs, FileHandle_t file, unsigned int nBytes) {
	fs->SetBufferSize(file, nBytes);
}
DLL_EXPORT bool IFileSystem_IsOk(IFileSystem* fs, FileHandle_t file) {
	return fs->IsOk(file);
}
DLL_EXPORT bool IFileSystem_EndOfFile(IFileSystem* fs, FileHandle_t file) {
	return fs->EndOfFile(file);
}
DLL_EXPORT char* IFileSystem_ReadLine(IFileSystem* fs, char* pOutput, int maxChars, FileHandle_t file) {
	return fs->ReadLine(pOutput, maxChars, file);
}
DLL_EXPORT int IFileSystem_FPrintf(IFileSystem* fs, FileHandle_t file, const char* pFormat, const char* pMsg = nullptr) {
	return fs->FPrintf(file, pFormat, pMsg);
}

DLL_EXPORT CSysModule* IFileSystem_LoadModule(IFileSystem* fs, const char* pFileName, const char* pPathID = 0, bool bValidatedDllOnly = true) {
	return fs->LoadModule(pFileName, pPathID, bValidatedDllOnly);
}
DLL_EXPORT void IFileSystem_UnloadModule(IFileSystem* fs, CSysModule* pModule) {
	fs->UnloadModule(pModule);
}

DLL_EXPORT const char* IFileSystem_FindFirst(IFileSystem* fs, const char* pWildCard, FileFindHandle_t* pHandle) {
	return fs->FindFirst(pWildCard, pHandle);
}
DLL_EXPORT const char* IFileSystem_FindNext(IFileSystem* fs, FileFindHandle_t Handle) {
	return fs->FindNext(Handle);
}
DLL_EXPORT bool IFileSystem_FindIsDirectory(IFileSystem* fs, FileFindHandle_t Handle) {
	return fs->FindIsDirectory(Handle);
}
DLL_EXPORT void IFileSystem_FindClose(IFileSystem* fs, FileFindHandle_t Handle) {
	fs->FindClose(Handle);
}
DLL_EXPORT const char* IFileSystem_FindFirstEx(IFileSystem* fs, const char* pWildCard, const char* pPathID, FileFindHandle_t* pHandle) {
	return fs->FindFirstEx(pWildCard, pPathID, pHandle);
}

DLL_EXPORT const char* IFileSystem_GetLocalPath(IFileSystem* fs, const char* pFileName, char* pDest, int maxLenInChars) {
	return fs->GetLocalPath(pFileName, pDest, maxLenInChars);
}
DLL_EXPORT bool IFileSystem_FullPathToRelativePath(IFileSystem* fs, const char* pFullpath, char* pDest, int maxLenInChars) {
	return fs->FullPathToRelativePath(pFullpath, pDest, maxLenInChars);
}
DLL_EXPORT bool IFileSystem_GetCurrentDirectory(IFileSystem* fs, char* pDirectory, int maxlen) {
	return fs->GetCurrentDirectory(pDirectory, maxlen);
}

DLL_EXPORT void* IFileSystem_FindOrAddFileName(IFileSystem* fs, char const* pFileName) {
	return fs->FindOrAddFileName(pFileName);
}
DLL_EXPORT bool IFileSystem_String(IFileSystem* fs, void* handle, char* buf, int buflen) {
	return fs->String(handle, buf, buflen);
}

DLL_EXPORT void IFileSystem_PrintSearchPaths(IFileSystem* fs) {
	fs->PrintSearchPaths();
}
