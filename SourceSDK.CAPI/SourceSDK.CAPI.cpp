#include <filesystem.h>

DLL_EXPORT bool IFileSystem_IsSteam(void** fsPtr) {
	IFileSystem* fs = (IFileSystem*)fsPtr;
	return fs->IsSteam();
}

DLL_EXPORT void IFileSystem_PrintSearchPaths(void** fsPtr) {
	IFileSystem* fs = (IFileSystem*)fsPtr;
	fs->PrintSearchPaths();
}
