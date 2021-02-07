#include "SourceSDK.CAPI.h"
#include <filesystem.h>



DllExport bool IFileSystem_IsSteam(void** fsPtr) {
	IFileSystem* fs = (IFileSystem*)fsPtr;
	return fs->IsSteam();
}

DllExport void IFileSystem_PrintSearchPaths(void** fsPtr) {
	IFileSystem* fs = (IFileSystem*)fsPtr;
	fs->PrintSearchPaths();
}
