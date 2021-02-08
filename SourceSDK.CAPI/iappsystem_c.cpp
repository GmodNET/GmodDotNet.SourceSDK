#include <appframework/iappsystem.h>

DLL_EXPORT bool IAppSystem_Connect(void** ptr, CreateInterfaceFn factory) {
	IAppSystem* iAppSystem = (IAppSystem*)ptr;
	return iAppSystem->Connect(factory);
}

DLL_EXPORT void IAppSystem_Disconnect(void** ptr) {
	IAppSystem* iAppSystem = (IAppSystem*)ptr;
	iAppSystem->Disconnect();
}

DLL_EXPORT void* IAppSystem_QueryInterface(void** ptr, const char* pInterfaceName) {
	IAppSystem* iAppSystem = (IAppSystem*)ptr;
	return iAppSystem->QueryInterface(pInterfaceName);
}

DLL_EXPORT InitReturnVal_t IAppSystem_Init(void** ptr) {
	IAppSystem* iAppSystem = (IAppSystem*)ptr;
	return iAppSystem->Init();
}

DLL_EXPORT void IAppSystem_Shutdown(void** ptr) {
	IAppSystem* iAppSystem = (IAppSystem*)ptr;
	iAppSystem->Shutdown();
}

DLL_EXPORT const AppSystemInfo_t* IAppSystem_GetDependencies(void** ptr) {
	IAppSystem* iAppSystem = (IAppSystem*)ptr;
	return iAppSystem->GetDependencies();
}

DLL_EXPORT AppSystemTier_t IAppSystem_GetTier(void** ptr) {
	IAppSystem* iAppSystem = (IAppSystem*)ptr;
	return iAppSystem->GetTier();
}

DLL_EXPORT void IAppSystem_Reconnect(void** ptr, CreateInterfaceFn factory, const char* pInterfaceName) {
	IAppSystem* iAppSystem = (IAppSystem*)ptr;
	return iAppSystem->Reconnect(factory, pInterfaceName);
}

DLL_EXPORT bool IAppSystem_IsSingleton(void** ptr) {
	IAppSystem* iAppSystem = (IAppSystem*)ptr;
	return iAppSystem->IsSingleton();
}
