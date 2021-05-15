#ifndef SourceSDK_CAPI_H
#define SourceSDK_CAPI_H

#ifdef WIN32
#pragma once
#endif

#ifdef WIN32
#define DllExport extern "C" __declspec( dllexport )
#else
#define DllExport extern "C" __attribute__ ((dllexport))
#endif

#endif
