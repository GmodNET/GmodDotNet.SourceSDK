#include <filesystem.h>

#pragma region IBaseFileSystem
DLL_EXPORT int IBaseFileSystem_Read(void** ptr, void* pOutput, int size, FileHandle_t file) {
	IBaseFileSystem* bfs = (IBaseFileSystem*)ptr;
	return bfs->Read(pOutput, size, file);
}
DLL_EXPORT int IBaseFileSystem_Write(void** ptr, void const* pInput, int size, FileHandle_t file) {
	IBaseFileSystem* bfs = (IBaseFileSystem*)ptr;
	return bfs->Write(pInput, size, file);
}
DLL_EXPORT FileHandle_t IBaseFileSystem_Open(void** ptr, const char* pFileName, const char* pOptions, const char* pathID = 0) {
	IBaseFileSystem* bfs = (IBaseFileSystem*)ptr;
	return bfs->Open(pFileName, pOptions, pathID);
}
DLL_EXPORT void IBaseFileSystem_Close(void** ptr, FileHandle_t file) {
	IBaseFileSystem* bfs = (IBaseFileSystem*)ptr;
	bfs->Close(file);
}
DLL_EXPORT void IBaseFileSystem_Seek(void** ptr, FileHandle_t file, int pos, FileSystemSeek_t seekType) {
	IBaseFileSystem* bfs = (IBaseFileSystem*)ptr;
	bfs->Seek(file, pos, seekType);
}
DLL_EXPORT unsigned int IBaseFileSystem_Tell(void** ptr, FileHandle_t file) {
	IBaseFileSystem* bfs = (IBaseFileSystem*)ptr;
	return bfs->Tell(file);
}
DLL_EXPORT unsigned int IBaseFileSystem_Size(void** ptr, FileHandle_t file) {
	IBaseFileSystem* bfs = (IBaseFileSystem*)ptr;
	return bfs->Size(file);
}
DLL_EXPORT unsigned int IBaseFileSystem_Size_string_string(void** ptr, const char* pFileName, const char* pPathID = 0) {
	IBaseFileSystem* bfs = (IBaseFileSystem*)ptr;
	return bfs->Size(pFileName, pPathID);
}
DLL_EXPORT void IBaseFileSystem_Flush(void** ptr, FileHandle_t file) {
	IBaseFileSystem* bfs = (IBaseFileSystem*)ptr;
	bfs->Flush(file);
}
DLL_EXPORT bool IBaseFileSystem_Precache(void** ptr, const char* pFileName, const char* pPathID = 0) {
	IBaseFileSystem* bfs = (IBaseFileSystem*)ptr;
	return bfs->Precache(pFileName, pPathID);
}
DLL_EXPORT bool IBaseFileSystem_FileExists(void** ptr, const char* pFileName, const char* pPathID = 0) {
	IBaseFileSystem* bfs = (IBaseFileSystem*)ptr;
	return bfs->FileExists(pFileName, pPathID);
}
DLL_EXPORT bool IBaseFileSystem_IsFileWritable(void** ptr, const char* pFileName, const char* pPathID = 0) {
	IBaseFileSystem* bfs = (IBaseFileSystem*)ptr;
	return bfs->IsFileWritable(pFileName, pPathID);
}
DLL_EXPORT bool IBaseFileSystem_SetFileWritable(void** ptr, char const* pFileName, bool writable, const char* pPathID = 0) {
	IBaseFileSystem* bfs = (IBaseFileSystem*)ptr;
	return bfs->SetFileWritable(pFileName, writable, pPathID);
}
DLL_EXPORT long IBaseFileSystem_GetFileTime(void** ptr, const char* pFileName, const char* pPathID = 0) {
	IBaseFileSystem* bfs = (IBaseFileSystem*)ptr;
	return bfs->GetFileTime(pFileName, pPathID);
}
DLL_EXPORT bool IBaseFileSystem_ReadFile(void** ptr, const char* pFileName, const char* pPath, CUtlBuffer& buf, int nMaxBytes = 0, int nStartingByte = 0, FSAllocFunc_t pfnAlloc = NULL) {
	IBaseFileSystem* bfs = (IBaseFileSystem*)ptr;
	return bfs->ReadFile(pFileName, pPath, buf, nMaxBytes, nStartingByte, pfnAlloc);
}
DLL_EXPORT bool IBaseFileSystem_WriteFile(void** ptr, const char* pFileName, const char* pPath, CUtlBuffer& buf) {
	IBaseFileSystem* bfs = (IBaseFileSystem*)ptr;
	return bfs->WriteFile(pFileName, pPath, buf);
}
DLL_EXPORT bool IBaseFileSystem_UnzipFile(void** ptr, const char* pFileName, const char* pPath, const char* pDestination) {
	IBaseFileSystem* bfs = (IBaseFileSystem*)ptr;
	return bfs->UnzipFile(pFileName, pPath, pDestination);
}
#pragma endregion

DLL_EXPORT bool IFileSystem_IsSteam(void** fsPtr) {
	IFileSystem* fs = (IFileSystem*)fsPtr;
	return fs->IsSteam();
}

DLL_EXPORT FilesystemMountRetval_t IFileSystem_MountSteamContent(void** fsPtr, int nExtraAppId = -1) {
	IFileSystem* fs = (IFileSystem*)fsPtr;
	return fs->MountSteamContent(nExtraAppId);
}
DLL_EXPORT void IFileSystem_AddSearchPath(void** fsPtr, const char* pPath, const char* pathID, SearchPathAdd_t addType = PATH_ADD_TO_TAIL) {
	IFileSystem* fs = (IFileSystem*)fsPtr;
	fs->AddSearchPath(pPath, pathID, addType);
}
DLL_EXPORT bool IFileSystem_RemoveSearchPath(void** fsPtr, const char* pPath, const char* pathID = 0) {
	IFileSystem* fs = (IFileSystem*)fsPtr;
	return fs->RemoveSearchPath(pPath, pathID);
}
DLL_EXPORT void IFileSystem_RemoveAllSearchPaths(void** fsPtr) {
	IFileSystem* fs = (IFileSystem*)fsPtr;
	fs->RemoveAllSearchPaths();
}
DLL_EXPORT void IFileSystem_RemoveSearchPaths(void** fsPtr, const char* szPathID) {
	IFileSystem* fs = (IFileSystem*)fsPtr;
	fs->RemoveSearchPaths(szPathID);
}

DLL_EXPORT void IFileSystem_MarkPathIDByRequestOnly(void** fsPtr, const char* pPathID, bool bRequestOnly) {
	IFileSystem* fs = (IFileSystem*)fsPtr;
	fs->MarkPathIDByRequestOnly(pPathID, bRequestOnly);
}
DLL_EXPORT const char* IFileSystem_RelativePathToFullPath(void** fsPtr, const char* pFileName, const char* pPathID, char* pDest, int maxLenInChars, PathTypeFilter_t pathFilter = FILTER_NONE, PathTypeQuery_t* pPathType = NULL) {
	IFileSystem* fs = (IFileSystem*)fsPtr;
	return fs->RelativePathToFullPath(pFileName, pPathID, pDest, maxLenInChars, pathFilter, pPathType);
}
DLL_EXPORT int IFileSystem_GetSearchPath(void** fsPtr, const char* pathID, bool bGetPackFiles, char* pDest, int maxLenInChars) {
	IFileSystem* fs = (IFileSystem*)fsPtr;
	return fs->GetSearchPath(pathID, bGetPackFiles, pDest, maxLenInChars);
}
DLL_EXPORT bool IFileSystem_AddPackFile(void** fsPtr, const char* fullpath, const char* pathID) {
	IFileSystem* fs = (IFileSystem*)fsPtr;
	return fs->AddPackFile(fullpath, pathID);
}

DLL_EXPORT void IFileSystem_RemoveFile(void** fsPtr, char const* pRelativePath, const char* pathID = 0) {
	IFileSystem* fs = (IFileSystem*)fsPtr;
	fs->RemoveFile(pRelativePath, pathID);
}
DLL_EXPORT bool IFileSystem_RenameFile(void** fsPtr, char const* pOldPath, char const* pNewPath, const char* pathID = 0) {
	IFileSystem* fs = (IFileSystem*)fsPtr;
	return fs->RenameFile(pOldPath, pNewPath, pathID);
}
DLL_EXPORT void IFileSystem_CreateDirHierarchy(void** fsPtr, const char* path, const char* pathID = 0) {
	IFileSystem* fs = (IFileSystem*)fsPtr;
	fs->CreateDirHierarchy(path, pathID);
}
DLL_EXPORT bool IFileSystem_IsDirectory(void** fsPtr, const char* pFileName, const char* pathID = 0) {
	IFileSystem* fs = (IFileSystem*)fsPtr;
	return fs->IsDirectory(pFileName, pathID);
}
DLL_EXPORT void IFileSystem_FileTimeToString(void** fsPtr, char* pStrip, int maxCharsIncludingTerminator, long fileTime) {
	IFileSystem* fs = (IFileSystem*)fsPtr;
	fs->FileTimeToString(pStrip, maxCharsIncludingTerminator, fileTime);
}

DLL_EXPORT void IFileSystem_PrintSearchPaths(void** fsPtr) {
	IFileSystem* fs = (IFileSystem*)fsPtr;
	fs->PrintSearchPaths();
}
