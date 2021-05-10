#include <vgui/ISurface.h>

DLL_EXPORT void ISurface_Shutdown(vgui::ISurface* surf) {
	surf->Shutdown();
}

DLL_EXPORT void ISurface_RunFrame(vgui::ISurface* surf) {
	surf->RunFrame();
}

DLL_EXPORT unsigned int ISurface_GetEmbeddedPanel(vgui::ISurface* surf) {
	return surf->GetEmbeddedPanel();
}
DLL_EXPORT void ISurface_SetEmbeddedPanel(vgui::ISurface* surf, unsigned int panel) {
	surf->SetEmbeddedPanel(panel);
}

DLL_EXPORT void ISurface_PushMakeCurrent(vgui::ISurface* surf, unsigned int panel, bool useInsets) {
	surf->PushMakeCurrent(panel, useInsets);
}
DLL_EXPORT void ISurface_PopMakeCurrent(vgui::ISurface* surf, unsigned int panel) {
	surf->PopMakeCurrent(panel);
}

DLL_EXPORT void ISurface_DrawSetColor_RGBA(vgui::ISurface* surf, int r, int g, int b, int a) {
	surf->DrawSetColor(r, g, b, a);
}
DLL_EXPORT void ISurface_DrawSetColor_COLOR(vgui::ISurface* surf, Color color) {
	surf->DrawSetColor(color);
}

DLL_EXPORT void ISurface_DrawFilledRect(vgui::ISurface* surf, int x0, int y0, int x1, int y1) {
	surf->DrawFilledRect(x0, y0, x1, y1);
}
DLL_EXPORT void ISurface_DrawFilledRectArray(vgui::ISurface* surf, vgui::IntRect* pRects, int numRects) {
	surf->DrawFilledRectArray(pRects, numRects);
}
DLL_EXPORT void ISurface_DrawOutlinedRect(vgui::ISurface* surf, int x0, int y0, int x1, int y1) {
	surf->DrawOutlinedRect(x0, y0, x1, y1);
}

DLL_EXPORT void ISurface_DrawLine(vgui::ISurface* surf, int x0, int y0, int x1, int y1) {
	surf->DrawLine(x0, y0, x1, y1);
}
DLL_EXPORT void ISurface_DrawPolyLine(vgui::ISurface* surf, int* px, int* py, int numPoints) {
	surf->DrawPolyLine(px, py, numPoints);
}

DLL_EXPORT void ISurface_DrawSetTextureRGBAex(void** ptr, int id, const unsigned char* rgba, int wide, int tall, ImageFormat imageFormat) {
	vgui::ISurface* surf = (vgui::ISurface*)ptr;
	surf->DrawSetTextureRGBAEx(id, rgba, wide, tall, imageFormat);
}

DLL_EXPORT void ISurface_DrawTexturedRect(vgui::ISurface* s, int x0, int y0, int x1, int y1) {
	s->DrawTexturedRect(x0, y0, x1, y1);
}

