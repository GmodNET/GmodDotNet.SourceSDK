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
DLL_EXPORT bool IMaterialSystem_GetRecommendedConfigurationInfo(IMaterialSystem* m, int nDXLevel, KeyValues* pKeyValues) {
	return m->GetRecommendedConfigurationInfo(nDXLevel, pKeyValues);
}

DLL_EXPORT int IMaterialSystem_GetDisplayAdapterCount(IMaterialSystem* m) {
	return m->GetDisplayAdapterCount();
}
DLL_EXPORT int IMaterialSystem_GetCurrentAdapter(IMaterialSystem* m) {
	return m->GetCurrentAdapter();
}
DLL_EXPORT void IMaterialSystem_GetDisplayAdapterInfo(IMaterialSystem* m, int adapter, MaterialAdapterInfo_t& info) {
	m->GetDisplayAdapterInfo(adapter, info);
}
DLL_EXPORT int IMaterialSystem_GetModeCount(IMaterialSystem* m, int adapter) {
	return m->GetModeCount(adapter);
}
DLL_EXPORT void IMaterialSystem_GetModeInfo(IMaterialSystem* m, int adapter, int mode, MaterialVideoMode_t& info) {
	m->GetModeInfo(adapter, mode, info);
}
DLL_EXPORT void IMaterialSystem_AddModeChangeCallBack(IMaterialSystem* m, ModeChangeCallbackFunc_t func) {
	m->AddModeChangeCallBack(func);
}
DLL_EXPORT void IMaterialSystem_GetDisplayMode(IMaterialSystem* m, MaterialVideoMode_t& mode) {
	m->GetDisplayMode(mode);
}
DLL_EXPORT bool IMaterialSystem_SetMode(IMaterialSystem* m, void* hwnd, const MaterialSystem_Config_t& config) {
	return m->SetMode(hwnd, config);
}
DLL_EXPORT bool IMaterialSystem_SupportsMSAAMode(IMaterialSystem* m, int nMSAAMode) {
	return m->SupportsMSAAMode(nMSAAMode);
}
DLL_EXPORT const MaterialSystemHardwareIdentifier_t& IMaterialSystem_GetVideoCardIdentifier(IMaterialSystem* m) {
	return m->GetVideoCardIdentifier();
}
DLL_EXPORT void IMaterialSystem_SpewDriverInfo(IMaterialSystem* m) {
	m->SpewDriverInfo();
}
DLL_EXPORT void IMaterialSystem_GetBackBufferDimensions(IMaterialSystem* m, int& width, int& height) {
	m->GetBackBufferDimensions(width, height);
}
DLL_EXPORT ImageFormat IMaterialSystem_GetBackBufferFormat(IMaterialSystem* m) {
	return m->GetBackBufferFormat();
}
DLL_EXPORT const AspectRatioInfo_t& IMaterialSystem_GetAspectRatioInfo(IMaterialSystem* m) {
	return m->GetAspectRatioInfo();
}
DLL_EXPORT bool IMaterialSystem_SupportsHDRMode(IMaterialSystem* m, HDRType_t nHDRModede) {
	return m->SupportsHDRMode(nHDRModede);
}











DLL_EXPORT void IMaterialSystem_BeginRenderTargetAllocation(IMaterialSystem* m) {
	m->BeginRenderTargetAllocation();
}
DLL_EXPORT void IMaterialSystem_EndRenderTargetAllocation(IMaterialSystem* m) {
	m->EndRenderTargetAllocation();
}

DLL_EXPORT ITexture* IMaterialSystem_CreateRenderTargetTexture(IMaterialSystem* m, int w, int h, RenderTargetSizeMode_t sizeMode, ImageFormat format, MaterialRenderTargetDepth_t depth) {
	return m->CreateRenderTargetTexture(w, h, sizeMode, format, depth);
}
DLL_EXPORT ITexture* IMaterialSystem_CreateNamedRenderTargetTextureEx(IMaterialSystem* m, const char* pRTName, int w, int h, RenderTargetSizeMode_t sizeMode, ImageFormat format, MaterialRenderTargetDepth_t depth, unsigned int textureFlags, unsigned int renderTargetFlags) {
	return m->CreateNamedRenderTargetTextureEx(pRTName, w, h, sizeMode, format, depth, textureFlags, renderTargetFlags);
}
DLL_EXPORT ITexture* IMaterialSystem_CreateNamedRenderTargetTexture(IMaterialSystem* m, const char* pRTName, int w, int h, RenderTargetSizeMode_t sizeMode, ImageFormat format, MaterialRenderTargetDepth_t depth, bool bClampTexCoords, bool bAutoMipMap) {
	return m->CreateNamedRenderTargetTexture(pRTName, w, h, sizeMode, format, depth, bClampTexCoords, bAutoMipMap);
}
DLL_EXPORT ITexture* IMaterialSystem_CreateNamedRenderTargetTextureEx2(IMaterialSystem* m, const char* pRTName, int w, int h, RenderTargetSizeMode_t sizeMode, ImageFormat format, MaterialRenderTargetDepth_t depth, unsigned int textureFlags, unsigned int renderTargetFlags) {
	return m->CreateNamedRenderTargetTextureEx2(pRTName, w, h, sizeMode, format, depth, textureFlags, renderTargetFlags);
}
