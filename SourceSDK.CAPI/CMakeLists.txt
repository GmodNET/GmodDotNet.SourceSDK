# CMakeList.txt : CMake project for SourceSDK.CAPI, include source and define
# project specific logic here.
#
link_libraries("C:/Users/Дом/source/repos/SupinePandora43/GmodDotNet.SourceSDK/SourceSDK.CAPI/gmod_sdk/sourcesdk-minimal/lib/public/x64/tier0.lib")
link_libraries("C:/Users/Дом/source/repos/SupinePandora43/GmodDotNet.SourceSDK/SourceSDK.CAPI/gmod_sdk/sourcesdk-minimal/lib/public/libz.lib")
#link_libraries("C:/Users/Дом/source/repos/SupinePandora43/GmodDotNet.SourceSDK/SourceSDK.CAPI/gmod_sdk/sourcesdk-minimal/lib/public/tier1.lib")
link_libraries("C:/Users/Дом/source/repos/SupinePandora43/GmodDotNet.SourceSDK/SourceSDK.CAPI/gmod_sdk/sourcesdk-minimal/lib/public/tier2.lib")
link_libraries("C:/Users/Дом/source/repos/SupinePandora43/GmodDotNet.SourceSDK/SourceSDK.CAPI/gmod_sdk/sourcesdk-minimal/lib/public/tier3.lib")
link_libraries("C:/Users/Дом/source/repos/SupinePandora43/GmodDotNet.SourceSDK/SourceSDK.CAPI/gmod_sdk/sourcesdk-minimal/lib/public/x64/vstdlib.lib")
cmake_minimum_required (VERSION 3.8)
set(arch "x64")
set(CMAKE_SYSTEM_PROCESSOR "x64")
project("sourcesdkc")
add_library (sourcesdkc MODULE "SourceSDK.CAPI.cpp" "SourceSDK.CAPI.h")
include_directories()
target_include_directories(sourcesdkc PUBLIC "gmod_sdk/sourcesdk-minimal/public")

add_compile_definitions("COMPILER_MSVC" "COMPILER_MSVC64" "__x86_64__")
