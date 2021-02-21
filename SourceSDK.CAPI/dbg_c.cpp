#include<tier0/platform.h>
#include<tier0/dbg.h>

DLL_EXPORT const char* DBG_CDbgFmtMsg(const char* format, va_list args) {
	char chars[256];
	Tier0Internal_vsntprintf(chars, sizeof(chars) - 1, format, args);
	chars[sizeof(chars) - 1] = 0;
	return chars;
}
