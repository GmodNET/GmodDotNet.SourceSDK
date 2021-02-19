#include <vgui/ISurface.h>

DLL_EXPORT void ISurface_DrawSetTextureRGBAex(void** ptr, int id, const unsigned char* rgba, int wide, int tall, ImageFormat imageFormat) {
	vgui::ISurface* surf = (vgui::ISurface*)ptr;
	surf->DrawSetTextureRGBAEx(id, rgba, wide, tall, imageFormat);
}


