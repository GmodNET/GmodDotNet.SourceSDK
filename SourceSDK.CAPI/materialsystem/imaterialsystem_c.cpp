#include <materialsystem/imaterialsystem.h>


DLL_EXPORT CreateInterfaceFn IMaterialSystem_Init(IMaterialSystem* m, char const* pShaderAPIDLL, IMaterialProxyFactory* pMaterialProxyFactory, CreateInterfaceFn fileSystemFactory, CreateInterfaceFn cvarFactory = NULL) {
	return m->Init(pShaderAPIDLL, pMaterialProxyFactory, fileSystemFactory, cvarFactory);
}

DLL_EXPORT void	IMaterialSystem_SetShaderAPI(IMaterialSystem* m, char const* pShaderAPIDLL) {
	m->SetShaderAPI(pShaderAPIDLL);
}
DLL_EXPORT void	IMaterialSystem_SetAdapter(IMaterialSystem* m, int nAdapter, int nFlags) {
	m->SetAdapter(nAdapter, nFlags);
}

DLL_EXPORT void	IMaterialSystem_ModInit(IMaterialSystem* m) {
	m->ModInit();
}
DLL_EXPORT void	IMaterialSystem_ModShutdown(IMaterialSystem* m) {
	m->ModShutdown();
}

DLL_EXPORT void	IMaterialSystem_SetThreadMode(IMaterialSystem* m, MaterialThreadMode_t mode, int nServiceThread = -1) {
	m->SetThreadMode(mode, nServiceThread);
}
DLL_EXPORT MaterialThreadMode_t IMaterialSystem_GetThreadMode(IMaterialSystem* m) {
	return m->GetThreadMode();
}
DLL_EXPORT bool IMaterialSystem_IsRenderThreadSafe(IMaterialSystem* m) {
	return m->IsRenderThreadSafe();
}
DLL_EXPORT void IMaterialSystem_ExecuteQueued(IMaterialSystem* m) {
	m->ExecuteQueued();
}
DLL_EXPORT void IMaterialSystem_OnDebugEvent(IMaterialSystem* m, const char* pEvent = "") {
	m->OnDebugEvent(pEvent);
}

DLL_EXPORT IMaterialSystemHardwareConfig* IMaterialSystem_GetHardwareConfig(IMaterialSystem* m, const char* pVersion, int* returnCode) {
	return m->GetHardwareConfig(pVersion, returnCode);
}

DLL_EXPORT bool IMaterialSystem_UpdateConfig(IMaterialSystem* m, bool bForceUpdate) {
	return m->UpdateConfig(bForceUpdate);
}
DLL_EXPORT bool IMaterialSystem_OverrideConfig(IMaterialSystem* m, const MaterialSystem_Config_t& config, bool bForceUpdate) {
	return m->OverrideConfig(config, bForceUpdate);
}
DLL_EXPORT const MaterialSystem_Config_t& IMaterialSystem_GetCurrentConfigForVideoCard(IMaterialSystem* m) {
	return m->GetCurrentConfigForVideoCard();
}
DLL_EXPORT bool GetRecommendedConfigurationInfo(IMaterialSystem* m, int nDXLevel, KeyValues* pKeyValues) {
	return m->GetRecommendedConfigurationInfo(nDXLevel, pKeyValues);
}
