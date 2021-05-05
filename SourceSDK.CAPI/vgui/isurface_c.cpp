#include <vgui/ISurface.h>

DLL_EXPORT void ISurface_DrawSetColor_RGBA(vgui::ISurface* surf, int r, int g, int b, int a) {
	surf->DrawSetColor(r, g, b, a);
}
DLL_EXPORT void ISurface_DrawSetColor_COLOR(vgui::ISurface* surf, Color color) {
	surf->DrawSetColor(color);
}

DLL_EXPORT void ISurface_DrawFilledRect(void** ptr, int x0, int y0, int x1, int y1) {
	vgui::ISurface* surf = (vgui::ISurface*)ptr;
	surf->DrawFilledRect(x0, y0, x1, y1);
}

DLL_EXPORT void ISurface_DrawSetTextureRGBAex(void** ptr, int id, const unsigned char* rgba, int wide, int tall, ImageFormat imageFormat) {
	vgui::ISurface* surf = (vgui::ISurface*)ptr;
	surf->DrawSetTextureRGBAEx(id, rgba, wide, tall, imageFormat);
}


