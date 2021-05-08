cmake_minimum_required (VERSION 3.8)

project("sourcesdkc" CXX)
set (CMAKE_CXX_STANDARD 11)
set(SOURCESDK_DEFINES
  "PLATFORM_64BITS"
  "__x86_64__"
)
if(CMAKE_CXX_COMPILER_ID MATCHES "GNU")
	list(APPEND SOURCESDK_DEFINES "COMPILER_GCC" "GNUC")
elseif(CMAKE_CXX_COMPILER_ID MATCHES "MSVC")
	list(APPEND SOURCESDK_DEFINES "COMPILER_MSVC")
	list(APPEND SOURCESDK_DEFINES "COMPILER_MSVC64")
else()
	message(WARNING "Unknown compiler used: ${CMAKE_CXX_COMPILER_ID}")
endif()

if(WIN32)
	list(APPEND SOURCESDK_DEFINES "WIN64" "_WIN64" "_DLL_EXT=.dll" "WIN32")
	set(SOURCESDK_LIBDIRS "${CMAKE_CURRENT_SOURCE_DIR}/gmod_sdk/sourcesdk-minimal/lib/public/x64")
elseif(APPLE)
	list(APPEND SOURCESDK_DEFINES
		"_DLL_EXT=.dylib"
		"POSIX"
		"_POSIX"
		"OSX"
		"_OSX"
		"_DARWIN_UNLIMITED_SELECT"
		"FD_SETSIZE=10240"
		"OVERRIDE_V_DEFINES"
		"SWDS"
		"DX_TO_GL_ABSTRACTION"
	)
	set(SOURCESDK_LIBDIRS "${CMAKE_CURRENT_SOURCE_DIR}/gmod_sdk/sourcesdk-minimal/lib/public/osx64")
elseif(UNIX)
	list(APPEND SOURCESDK_DEFINES
		"_DLL_EXT=.so"
		"POSIX"
		"_POSIX"
		"LINUX"
		"_LINUX"
		"SWDS"
		"DX_TO_GL_ABSTRACTION"
	)
	set(SOURCESDK_LIBDIRS "${CMAKE_CURRENT_SOURCE_DIR}/gmod_sdk/sourcesdk-minimal/lib/public/linux64")
endif()

add_compile_definitions(${SOURCESDK_DEFINES})

link_directories("${SOURCESDK_LIBDIRS}")
link_libraries(tier0)
add_library (sourcesdkc MODULE "filesystem_c.cpp" "SourceSDK.CAPI.h" "iappsystem_c.cpp" "vgui/isurface_c.cpp"  "VGuiMatSurface/IMatSystemSurface_c.cpp" "materialsystem/imaterialsystem_c.cpp" "materialsystem/imaterialsystemhardwareconfig_c.cpp")

target_include_directories(sourcesdkc PUBLIC#SYSTEM INTERFACE
	#"${CMAKE_CURRENT_SOURCE_DIR}/gmod_sdk/sourcesdk-minimal/common"
	#"${CMAKE_CURRENT_SOURCE_DIR}/gmod_sdk/sourcesdk-minimal/game/shared"
	"${CMAKE_CURRENT_SOURCE_DIR}/gmod_sdk/sourcesdk-minimal/public"
)
#target_include_directories(sourcesdkc SYSTEM INTERFACE "${CMAKE_CURRENT_SOURCE_DIR}/gmod_sdk/sourcesdk-minimal/public/tier0")
