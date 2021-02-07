#pragma once

#ifdef WIN32
#define DllExport extern "C" __declspec( dllexport )
#else
#define DllExport extern "C" __attribute__ ((dllexport))
#endif

