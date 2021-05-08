#include <materialsystem/imaterialsystemhardwareconfig.h>

DLL_EXPORT int IMaterialSystemHardwareConfig_GetFrameBufferColorDepth(IMaterialSystemHardwareConfig* c) {
	return c->GetFrameBufferColorDepth();
}
DLL_EXPORT int IMaterialSystemHardwareConfig_GetSamplerCount(IMaterialSystemHardwareConfig* c) {
	return c->GetSamplerCount();
}
DLL_EXPORT bool IMaterialSystemHardwareConfig_SupportsStaticControlFlow(IMaterialSystemHardwareConfig* c) {
	return c->SupportsStaticControlFlow();
}
DLL_EXPORT VertexCompressionType_t IMaterialSystemHardwareConfig_SupportsCompressedVertices(IMaterialSystemHardwareConfig* c) {
	return c->SupportsCompressedVertices();
}
DLL_EXPORT int IMaterialSystemHardwareConfig_MaximumAnisotropicLevel(IMaterialSystemHardwareConfig* c) {
	return c->MaximumAnisotropicLevel();
}
DLL_EXPORT int IMaterialSystemHardwareConfig_MaxTextureWidth(IMaterialSystemHardwareConfig* c) {
	return c->MaxTextureWidth();
}
DLL_EXPORT int IMaterialSystemHardwareConfig_MaxTextureHeight(IMaterialSystemHardwareConfig* c) {
	return c->MaxTextureHeight();
}
DLL_EXPORT int IMaterialSystemHardwareConfig_TextureMemorySize(IMaterialSystemHardwareConfig* c) {
	return c->TextureMemorySize();
}
DLL_EXPORT bool IMaterialSystemHardwareConfig_SupportsMipmappedCubemaps(IMaterialSystemHardwareConfig* c) {
	return c->SupportsMipmappedCubemaps();
}

DLL_EXPORT int IMaterialSystemHardwareConfig_NumVertexShaderConstants(IMaterialSystemHardwareConfig* c) {
	return c->NumVertexShaderConstants();
}
DLL_EXPORT int IMaterialSystemHardwareConfig_NumPixelShaderConstants(IMaterialSystemHardwareConfig* c) {
	return c->NumPixelShaderConstants();
}
DLL_EXPORT int IMaterialSystemHardwareConfig_MaxNumLights(IMaterialSystemHardwareConfig* c) {
	return c->MaxNumLights();
}
DLL_EXPORT int IMaterialSystemHardwareConfig_MaxTextureAspectRatio(IMaterialSystemHardwareConfig* c) {
	return c->MaxTextureAspectRatio();
}
DLL_EXPORT int IMaterialSystemHardwareConfig_MaxVertexShaderBlendMatrices(IMaterialSystemHardwareConfig* c) {
	return c->MaxVertexShaderBlendMatrices();
}
DLL_EXPORT int IMaterialSystemHardwareConfig_MaxUserClipPlanes(IMaterialSystemHardwareConfig* c) {
	return c->MaxUserClipPlanes();
}
DLL_EXPORT bool IMaterialSystemHardwareConfig_UseFastClipping(IMaterialSystemHardwareConfig* c) {
	return c->UseFastClipping();
}

DLL_EXPORT int IMaterialSystemHardwareConfig_GetDXSupportLevel(IMaterialSystemHardwareConfig* c) {
	return c->GetDXSupportLevel();
}
DLL_EXPORT const char* IMaterialSystemHardwareConfig_GetShaderDLLName(IMaterialSystemHardwareConfig* c) {
	return c->GetShaderDLLName();
}

DLL_EXPORT bool IMaterialSystemHardwareConfig_ReadPixelsFromFrontBuffer(IMaterialSystemHardwareConfig* c) {
	return c->ReadPixelsFromFrontBuffer();
}

DLL_EXPORT bool IMaterialSystemHardwareConfig_PreferDynamicTextures(IMaterialSystemHardwareConfig* c) {
	return c->PreferDynamicTextures();
}

DLL_EXPORT bool IMaterialSystemHardwareConfig_SupportsHDR(IMaterialSystemHardwareConfig* c) {
	return c->SupportsHDR();
}

DLL_EXPORT bool IMaterialSystemHardwareConfig_NeedsAAClamp(IMaterialSystemHardwareConfig* c) {
	return c->NeedsAAClamp();
}
DLL_EXPORT bool IMaterialSystemHardwareConfig_NeedsATICentroidHack(IMaterialSystemHardwareConfig* c) {
	return c->NeedsATICentroidHack();
}

DLL_EXPORT int IMaterialSystemHardwareConfig_GetMaxDXSupportLevel(IMaterialSystemHardwareConfig* c) {
	return c->GetMaxDXSupportLevel();
}

DLL_EXPORT bool IMaterialSystemHardwareConfig_SpecifiesFogColorInLinearSpace(IMaterialSystemHardwareConfig* c) {
	return c->SpecifiesFogColorInLinearSpace();
}

DLL_EXPORT bool IMaterialSystemHardwareConfig_SupportsSRGB(IMaterialSystemHardwareConfig* c) {
	return c->SupportsSRGB();
}
DLL_EXPORT bool IMaterialSystemHardwareConfig_FakeSRGBWrite(IMaterialSystemHardwareConfig* c) {
	return c->FakeSRGBWrite();
}
DLL_EXPORT bool IMaterialSystemHardwareConfig_CanDoSRGBReadFromRTs(IMaterialSystemHardwareConfig* c) {
	return c->CanDoSRGBReadFromRTs();
}

DLL_EXPORT bool IMaterialSystemHardwareConfig_SupportsGLMixedSizeTargets(IMaterialSystemHardwareConfig* c) {
	return c->SupportsGLMixedSizeTargets();
}

DLL_EXPORT bool IMaterialSystemHardwareConfig_IsAAEnabled(IMaterialSystemHardwareConfig* c) {
	return c->IsAAEnabled();
}

DLL_EXPORT int IMaterialSystemHardwareConfig_GetVertexSamplerCount(IMaterialSystemHardwareConfig* c) {
	return c->GetVertexSamplerCount();
}
DLL_EXPORT int IMaterialSystemHardwareConfig_GetMaxVertexTextureDimension(IMaterialSystemHardwareConfig* c) {
	return c->GetMaxVertexTextureDimension();
}

DLL_EXPORT int IMaterialSystemHardwareConfig_MaxTextureDepth(IMaterialSystemHardwareConfig* c) {
	return c->MaxTextureDepth();
}

DLL_EXPORT HDRType_t IMaterialSystemHardwareConfig_GetHDRType(IMaterialSystemHardwareConfig* c) {
	return c->GetHDRType();
}
DLL_EXPORT HDRType_t IMaterialSystemHardwareConfig_GetHardwareHDRType(IMaterialSystemHardwareConfig* c) {
	return c->GetHardwareHDRType();
}

DLL_EXPORT bool IMaterialSystemHardwareConfig_SupportsStreamOffset(IMaterialSystemHardwareConfig* c) {
	return c->SupportsStreamOffset();
}

DLL_EXPORT int IMaterialSystemHardwareConfig_StencilBufferBits(IMaterialSystemHardwareConfig* c) {
	return c->StencilBufferBits();
}
DLL_EXPORT int IMaterialSystemHardwareConfig_MaxViewports(IMaterialSystemHardwareConfig* c) {
	return c->MaxViewports();
}

DLL_EXPORT void IMaterialSystemHardwareConfig_OverrideStreamOffsetSupport(IMaterialSystemHardwareConfig* c, bool bOverrideEnabled, bool bEnableSupport) {
	c->OverrideStreamOffsetSupport(bOverrideEnabled, bEnableSupport);
}

DLL_EXPORT ShadowFilterMode_t IMaterialSystemHardwareConfig_GetShadowFilterMode(IMaterialSystemHardwareConfig* c, bool bForceLowQualityShadows, bool bPS30) {
	return c->GetShadowFilterMode(bForceLowQualityShadows, bPS30);
}

DLL_EXPORT int IMaterialSystemHardwareConfig_NeedsShaderSRGBConversion(IMaterialSystemHardwareConfig* c) {
	return c->NeedsShaderSRGBConversion();
}

DLL_EXPORT bool IMaterialSystemHardwareConfig_UsesSRGBCorrectBlending(IMaterialSystemHardwareConfig* c) {
	return c->UsesSRGBCorrectBlending();
}

DLL_EXPORT bool IMaterialSystemHardwareConfig_HasFastVertexTextures(IMaterialSystemHardwareConfig* c) {
	return c->HasFastVertexTextures();
}
DLL_EXPORT int IMaterialSystemHardwareConfig_MaxHWMorphBatchCount(IMaterialSystemHardwareConfig* c) {
	return c->MaxHWMorphBatchCount();
}

DLL_EXPORT bool IMaterialSystemHardwareConfig_GetHDREnabled(IMaterialSystemHardwareConfig* c) {
	return c->GetHDREnabled();
}
DLL_EXPORT void IMaterialSystemHardwareConfig_SetHDREnabled(IMaterialSystemHardwareConfig* c, bool bEnable) {
	c->SetHDREnabled(bEnable);
}

DLL_EXPORT bool IMaterialSystemHardwareConfig_SupportsBorderColor(IMaterialSystemHardwareConfig* c) {
	return c->SupportsBorderColor();
}
DLL_EXPORT bool IMaterialSystemHardwareConfig_SupportsFetch4(IMaterialSystemHardwareConfig* c) {
	return c->SupportsFetch4();
}

DLL_EXPORT float IMaterialSystemHardwareConfig_GetShadowDepthBias(IMaterialSystemHardwareConfig* c) {
	return c->GetShadowDepthBias();
}
DLL_EXPORT float IMaterialSystemHardwareConfig_GetShadowSlopeScaleDepthBias(IMaterialSystemHardwareConfig* c) {
	return c->GetShadowSlopeScaleDepthBias();
}

DLL_EXPORT bool IMaterialSystemHardwareConfig_PreferZPrepass(IMaterialSystemHardwareConfig* c) {
	return c->PreferZPrepass();
}

DLL_EXPORT bool IMaterialSystemHardwareConfig_SuppressPixelShaderCentroidHackFixup(IMaterialSystemHardwareConfig* c) {
	return c->SuppressPixelShaderCentroidHackFixup();
}
DLL_EXPORT bool IMaterialSystemHardwareConfig_PreferTexturesInHWMemory(IMaterialSystemHardwareConfig* c) {
	return c->PreferTexturesInHWMemory();
}
DLL_EXPORT bool IMaterialSystemHardwareConfig_PreferHardwareSync(IMaterialSystemHardwareConfig* c) {
	return c->PreferHardwareSync();
}
DLL_EXPORT bool IMaterialSystemHardwareConfig_ActualHasFastVertexTextures(IMaterialSystemHardwareConfig* c) {
	return c->ActualHasFastVertexTextures();
}

DLL_EXPORT bool IMaterialSystemHardwareConfig_SupportsShadowDepthTextures(IMaterialSystemHardwareConfig* c) {
	return c->SupportsShadowDepthTextures();
}
DLL_EXPORT ImageFormat IMaterialSystemHardwareConfig_GetShadowDepthTextureFormat(IMaterialSystemHardwareConfig* c) {
	return c->GetShadowDepthTextureFormat();
}
DLL_EXPORT ImageFormat IMaterialSystemHardwareConfig_GetHighPrecisionShadowDepthTextureFormat(IMaterialSystemHardwareConfig* c) {
	return c->GetHighPrecisionShadowDepthTextureFormat();
}
DLL_EXPORT ImageFormat IMaterialSystemHardwareConfig_GetNullTextureFormat(IMaterialSystemHardwareConfig* c) {
	return c->GetNullTextureFormat();
}
DLL_EXPORT int IMaterialSystemHardwareConfig_GetMinDXSupportLevel(IMaterialSystemHardwareConfig* c) {
	return c->GetMinDXSupportLevel();
}
DLL_EXPORT bool IMaterialSystemHardwareConfig_IsUnsupported(IMaterialSystemHardwareConfig* c) {
	return c->IsUnsupported();
}

DLL_EXPORT float IMaterialSystemHardwareConfig_GetLightMapScaleFactor(IMaterialSystemHardwareConfig* c) {
	return c->GetLightMapScaleFactor();
}

DLL_EXPORT bool IMaterialSystemHardwareConfig_SupportsCascadedShadowMapping(IMaterialSystemHardwareConfig* c) {
	return c->SupportsCascadedShadowMapping();
}
DLL_EXPORT CSMQualityMode_t IMaterialSystemHardwareConfig_GetCSMQuality(IMaterialSystemHardwareConfig* c) {
	return c->GetCSMQuality();
}
DLL_EXPORT bool IMaterialSystemHardwareConfig_SupportsBilinearPCFSampling(IMaterialSystemHardwareConfig* c) {
	return c->SupportsBilinearPCFSampling();
}
DLL_EXPORT CSMShaderMode_t IMaterialSystemHardwareConfig_GetCSMShaderMode(IMaterialSystemHardwareConfig* c, CSMQualityMode_t nQualityLevel) {
	return c->GetCSMShaderMode(nQualityLevel);
}
DLL_EXPORT bool IMaterialSystemHardwareConfig_GetCSMAccurateBlending(IMaterialSystemHardwareConfig* c) {
	return c->GetCSMAccurateBlending();
}
DLL_EXPORT void IMaterialSystemHardwareConfig_SetCSMAccurateBlending(IMaterialSystemHardwareConfig* c, bool bEnable) {
	c->SetCSMAccurateBlending(bEnable);
}

DLL_EXPORT bool IMaterialSystemHardwareConfig_SupportsResolveDepth(IMaterialSystemHardwareConfig* c) {
	return c->SupportsResolveDepth();
}
DLL_EXPORT bool IMaterialSystemHardwareConfig_HasFullResolutionDepthTexture(IMaterialSystemHardwareConfig* c) {
	return c->HasFullResolutionDepthTexture();
}
