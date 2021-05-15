#include <materialsystem/itexture.h>

DLL_EXPORT const char* ITexture_GetName(ITexture* t) {
	return t->GetName();
}
DLL_EXPORT int ITexture_GetMappingWidth(ITexture* t) {
	return t->GetMappingWidth();
}
DLL_EXPORT int ITexture_GetMappingHeight(ITexture* t) {
	return t->GetMappingHeight();
}
DLL_EXPORT int ITexture_GetActualWidth(ITexture* t) {
	return t->GetActualWidth();
}
DLL_EXPORT int ITexture_GetActualHeight(ITexture* t) {
	return t->GetActualHeight();
}
DLL_EXPORT int ITexture_GetNumAnimationFrames(ITexture* t) {
	return t->GetNumAnimationFrames();
}
DLL_EXPORT bool ITexture_IsTranslucent(ITexture* t) {
	return t->IsTranslucent();
}
DLL_EXPORT bool ITexture_IsMipmapped(ITexture* t) {
	return t->IsMipmapped();
}
