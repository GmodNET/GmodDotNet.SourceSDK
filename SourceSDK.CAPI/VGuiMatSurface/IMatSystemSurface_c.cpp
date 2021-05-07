#include<VGuiMatSurface/IMatSystemSurface.h>

DLL_EXPORT void IMatSystemSurface_AttachToWindow(IMatSystemSurface* s, void* hwnd, bool bLetAppDriveInput) {
	s->AttachToWindow(hwnd, bLetAppDriveInput);
}
DLL_EXPORT void IMatSystemSurface_EnableWindowsMessages(IMatSystemSurface* s, bool enable) {
	s->EnableWindowsMessages(enable);
}


DLL_EXPORT void IMatSystemSurface_Begin3DPaint(IMatSystemSurface* s, int iLeft, int iTop, int iRight, int iBottom, bool bRenderToTexture) {
	s->Begin3DPaint(iLeft, iTop, iRight, iBottom, bRenderToTexture);
}
DLL_EXPORT void IMatSystemSurface_End3DPaint(IMatSystemSurface* s) {
	s->End3DPaint();
}

DLL_EXPORT void IMatSystemSurface_DisableClipping(IMatSystemSurface* s, bool disable) {
	s->DisableClipping(disable);
}
DLL_EXPORT void IMatSystemSurface_GetClippingRect(IMatSystemSurface* s, int& left, int& top, int& right, int& bottom, bool& bClippingDisabled) {
	s->GetClippingRect(left, top, right, bottom, bClippingDisabled);
}
DLL_EXPORT void IMatSystemSurface_SetClippingRect(IMatSystemSurface* s, int left, int top, int right, int bottom) {
	s->SetClippingRect(left, top, right, bottom);
}

DLL_EXPORT bool IMatSystemSurface_IsCursorLocked(IMatSystemSurface* s) {
	return s->IsCursorLocked();
}

DLL_EXPORT void IMatSystemSurface_SetMouseCallbacks(IMatSystemSurface* s, GetMouseCallback_t get, SetMouseCallback_t set) {
	s->SetMouseCallbacks(get, set);
}
DLL_EXPORT void IMatSystemSurface_InstallPlaySoundFunc(IMatSystemSurface* s, PlaySoundFunc_t f) {
	s->InstallPlaySoundFunc(f);
}
// aaaaaaaaaaaaaaaaaaaaaaaaaaa
DLL_EXPORT void IMatSystemSurface_DrawColoredCircle(IMatSystemSurface* s, int centerx, int centery, float radius, int r, int g, int b, int a) {
	s->DrawColoredCircle(centerx, centery, radius, r, g, b, a);
}
DLL_EXPORT int IMatSystemSurface_DrawColoredText(IMatSystemSurface* s, vgui::HFont font, int x, int y, int r, int g, int b, int a, const char* fmt) {
	return s->DrawColoredText(font, x, y, r, g, b, a, fmt);
}

DLL_EXPORT void IMatSystemSurface_DrawColoredTextRect(IMatSystemSurface* s, vgui::HFont font, int x, int y, int w, int h, int r, int g, int b, int a, const char* fmt) {
	s->DrawColoredTextRect(font, x, y, w, h, r, g, b, a, fmt);
}
DLL_EXPORT void IMatSystemSurface_DrawTextHeight(IMatSystemSurface* s, vgui::HFont font, int w, int& h, const char* fmt) {
	s->DrawTextHeight(font, w, h, fmt);
}

DLL_EXPORT int IMatSystemSurface_DrawTextLen(IMatSystemSurface* s, vgui::HFont font, const char* fmt) {
	return s->DrawTextLen(font, fmt);
}

DLL_EXPORT void IMatSystemSurface_DrawPanelIn3DSpace(IMatSystemSurface* s, vgui::VPANEL pRootPanel, const VMatrix& panelCenterToWorld, int nPixelWidth, int nPixelHeight, float flWorldWidth, float flWorldHeight) {
	s->DrawPanelIn3DSpace(pRootPanel, panelCenterToWorld, nPixelWidth, nPixelHeight, flWorldWidth, flWorldHeight);
}

DLL_EXPORT void IMatSystemSurface_DrawSetTextureMaterial(IMatSystemSurface* s, int id, IMaterial* pMaterial) {
	s->DrawSetTextureMaterial(id, pMaterial);
}

DLL_EXPORT void IMatSystemSurface_Set3DPaintTempRenderTarget(IMatSystemSurface* s, const char* renderTargetName) {
	s->Set3DPaintTempRenderTarget(renderTargetName);
}
DLL_EXPORT void IMatSystemSurface_Reset3DPaintTempRenderTarget(IMatSystemSurface* s) {
	s->Reset3DPaintTempRenderTarget();
}

DLL_EXPORT IMaterial* IMatSystemSurface_DrawGetTextureMaterial(IMatSystemSurface* s, int id) {
	return s->DrawGetTextureMaterial(id);
}

DLL_EXPORT void IMatSystemSurface_GetFullscreenViewportAndRenderTarget(IMatSystemSurface* s, int& x, int& y, int& w, int& h, ITexture** ppRenderTarget) {
	s->GetFullscreenViewportAndRenderTarget(x, y, w, h, ppRenderTarget);
}
DLL_EXPORT void IMatSystemSurface_SetFullscreenViewportAndRenderTarget(IMatSystemSurface* s, int x, int y, int w, int h, ITexture* pRenderTarget) {
	s->SetFullscreenViewportAndRenderTarget(x, y, w, h, pRenderTarget);
}

DLL_EXPORT int IMatSystemSurface_DrawGetTextureId(IMatSystemSurface* s, ITexture* t) {
	return s->DrawGetTextureId(t);
}

DLL_EXPORT void IMatSystemSurface_BeginSkinCompositionPainting(IMatSystemSurface* s) {
	s->BeginSkinCompositionPainting();
}
DLL_EXPORT void IMatSystemSurface_EndSkinCompositionPainting(IMatSystemSurface* s) {
	s->EndSkinCompositionPainting();
}
