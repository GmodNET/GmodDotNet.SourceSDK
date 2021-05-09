using GmodNET.SourceSDK.bitmap;
using GmodNET.SourceSDK.Tier1;
using GmodNET.SourceSDK.vgui;
using GmodNET.SourceSDK.vtf;
using System;
using System.Runtime.InteropServices;

namespace GmodNET.SourceSDK.materialsystem
{
	public enum MaterialThreadMode_t
	{
		MATERIAL_SINGLE_THREADED,
		MATERIAL_QUEUED_SINGLE_THREADED,
		MATERIAL_QUEUED_THREADED
	}
	public enum MaterialRenderTargetDepth_t
	{
		MATERIAL_RT_DEPTH_SHARED = 0x0,
		MATERIAL_RT_DEPTH_SEPARATE = 0x1,
		MATERIAL_RT_DEPTH_NONE = 0x2,
		MATERIAL_RT_DEPTH_ONLY = 0x3,
	}
	public enum RenderTargetSizeMode_t
	{
		RT_SIZE_NO_CHANGE = 0,          // Only allowed for render targets that don't want a depth buffer
										// (because if they have a depth buffer, the render target must be less than or equal to the size of the framebuffer).
		RT_SIZE_DEFAULT = 1,                // Don't play with the specified width and height other than making sure it fits in the framebuffer.
		RT_SIZE_PICMIP = 2,             // Apply picmip to the render target's width and height.
		RT_SIZE_HDR = 3,                    // frame_buffer_width / 4
		RT_SIZE_FULL_FRAME_BUFFER = 4,  // Same size as frame buffer, or next lower power of 2 if we can't do that.
		RT_SIZE_OFFSCREEN = 5,          // Target of specified size, don't mess with dimensions
		RT_SIZE_FULL_FRAME_BUFFER_ROUNDED_UP = 6 // Same size as the frame buffer, rounded up if necessary for systems that can't do non-power of two textures.
	}
	/// <summary>
	/// CREATERENDERTARGETFLAGS_ defines
	/// </summary>
	public enum CREATERENDERTARGETFLAGS: uint
	{
		HDR = 0x00000001,
		AUTOMIPMAP = 0x00000002,
		UNFILTERABLE_OK = 0x00000004,

		// XBOX ONLY
		// NOEDRAM = 0x00000008,
		// TEMP = 0x00000010,
		// ALIASCOLORANDDEPTHSURFACES = 0x00000020
	}

	public partial class IMaterialSystem : ISurface
	{
		public IMaterialSystem(IntPtr ptr) : base(ptr) { }

		public void Init(string shaderAPIDLL, IntPtr materialProxyFactory, CreateInterfaceFn fileSystemFactory, CreateInterfaceFn cvarFactory = null) => Methods.IMaterialSystem_Init(ptr, shaderAPIDLL, materialProxyFactory, fileSystemFactory, cvarFactory);

		public void SetShaderApi(string shaderApiDll) => Methods.IMaterialSystem_SetShaderAPI(ptr, shaderApiDll);

		public void SetAdapter(int adapter, int flags) => Methods.IMaterialSystem_SetAdapter(ptr, adapter, flags);

		public void ModInit() => Methods.IMaterialSystem_ModInit(ptr);
		public void ModShutdown() => Methods.IMaterialSystem_ModShutdown(ptr);

		public void SetThreadMode(MaterialThreadMode_t mode, int nServiceThread = -1) => Methods.IMaterialSystem_SetThreadMode(ptr, mode, nServiceThread);
		public MaterialThreadMode_t GetThreadMode() => Methods.IMaterialSystem_GetThreadMode(ptr);

		public bool IsRenderThreadSafe => Methods.IMaterialSystem_IsRenderThreadSafe(ptr);
		public void ExecuteQueued() => Methods.IMaterialSystem_ExecuteQueued(ptr);
		public void OnDebugEvent(string pEvent = "") => Methods.IMaterialSystem_OnDebugEvent(ptr, pEvent);

		public IMaterialSystemHardwareConfig GetHardwareConfig(string version, out int returnCode) => new(Methods.IMaterialSystem_GetHardwareConfig(ptr, version, out returnCode));











		public void BeginRenderTargetAllocation() => Methods.IMaterialSystem_BeginRenderTargetAllocation(ptr);
		public void EndRenderTargetAllocation() => Methods.IMaterialSystem_EndRenderTargetAllocation(ptr);

		public ITexture CreateRenderTargetTexture(int w, int h, RenderTargetSizeMode_t sizeMode, ImageFormat format, MaterialRenderTargetDepth_t depth = MaterialRenderTargetDepth_t.MATERIAL_RT_DEPTH_SHARED) => new(Methods.IMaterialSystem_CreateRenderTargetTexture(ptr, w, h, sizeMode, format, depth));
		public ITexture CreateNamedRenderTargetTextureEx(string RTName, int w, int h, RenderTargetSizeMode_t sizeMode, ImageFormat format, MaterialRenderTargetDepth_t depth = MaterialRenderTargetDepth_t.MATERIAL_RT_DEPTH_SHARED, CompiledVtfFlags textureFlags = CompiledVtfFlags.TEXTUREFLAGS_CLAMPS | CompiledVtfFlags.TEXTUREFLAGS_CLAMPT, CREATERENDERTARGETFLAGS renderTargetFlags = 0) => new(Methods.IMaterialSystem_CreateNamedRenderTargetTextureEx(ptr, RTName, w, h, sizeMode, format, depth, textureFlags, renderTargetFlags));
		public ITexture CreateNamedRenderTargetTexture(string RTName, int w, int h, RenderTargetSizeMode_t sizeMode, ImageFormat format, MaterialRenderTargetDepth_t depth = MaterialRenderTargetDepth_t.MATERIAL_RT_DEPTH_SHARED, bool clampTexCoords = true, bool autoMipmap = false) => new(Methods.IMaterialSystem_CreateNamedRenderTargetTexture(ptr, RTName, w, h, sizeMode, format, depth, clampTexCoords, autoMipmap));
		public ITexture CreateNamedRenderTargetTextureEx2(string RTName, int w, int h, RenderTargetSizeMode_t sizeMode, ImageFormat format, MaterialRenderTargetDepth_t depth = MaterialRenderTargetDepth_t.MATERIAL_RT_DEPTH_SHARED, CompiledVtfFlags textureFlags = CompiledVtfFlags.TEXTUREFLAGS_CLAMPS | CompiledVtfFlags.TEXTUREFLAGS_CLAMPT, CREATERENDERTARGETFLAGS renderTargetFlags = 0) => new(Methods.IMaterialSystem_CreateNamedRenderTargetTextureEx2(ptr, RTName, w, h, sizeMode, format, depth, textureFlags, renderTargetFlags));



		new internal static partial class Methods
		{
			[GeneratedDllImport("sourcesdkc")]
			internal static partial void IMaterialSystem_Init(IntPtr m, [MarshalAs(UnmanagedType.LPUTF8Str)] string shaderAPIDLL, IntPtr materialProxyFactory, CreateInterfaceFn fileSystemFactory, CreateInterfaceFn cvarFactory = null);

			[GeneratedDllImport("sourcesdkc")]
			internal static partial void IMaterialSystem_SetShaderAPI(IntPtr m, [MarshalAs(UnmanagedType.LPUTF8Str)] string shaderAPIDLL);

			[DllImport("sourcesdkc")]
			internal static extern void IMaterialSystem_SetAdapter(IntPtr m, int adapter, int flags);

			[DllImport("sourcesdkc")]
			internal static extern void IMaterialSystem_ModInit(IntPtr m);
			[DllImport("sourcesdkc")]
			internal static extern void IMaterialSystem_ModShutdown(IntPtr m);

			[DllImport("sourcesdkc")]
			internal static extern void IMaterialSystem_SetThreadMode(IntPtr m, MaterialThreadMode_t mode, int nServiceThread = -1);
			[DllImport("sourcesdkc")]
			internal static extern MaterialThreadMode_t IMaterialSystem_GetThreadMode(IntPtr m);
			[GeneratedDllImport("sourcesdkc")]
			[return: MarshalAs(UnmanagedType.I1)]
			internal static partial bool IMaterialSystem_IsRenderThreadSafe(IntPtr m);
			[DllImport("sourcesdkc")]
			internal static extern void IMaterialSystem_ExecuteQueued(IntPtr m);
			[GeneratedDllImport("sourcesdkc")]
			internal static partial void IMaterialSystem_OnDebugEvent(IntPtr m, [MarshalAs(UnmanagedType.LPUTF8Str)] string pEvent = "");

			[GeneratedDllImport("sourcesdkc")]
			internal static partial IntPtr IMaterialSystem_GetHardwareConfig(IntPtr m, [MarshalAs(UnmanagedType.LPUTF8Str)] string version, out int returnCode);











			[DllImport("sourcesdkc")]
			internal static extern void IMaterialSystem_BeginRenderTargetAllocation(IntPtr m);
			[DllImport("sourcesdkc")]
			internal static extern void IMaterialSystem_EndRenderTargetAllocation(IntPtr m);

			[DllImport("sourcesdkc")]
			internal static extern IntPtr IMaterialSystem_CreateRenderTargetTexture(IntPtr m, int w, int h, RenderTargetSizeMode_t sizeMode, ImageFormat format, MaterialRenderTargetDepth_t depth = MaterialRenderTargetDepth_t.MATERIAL_RT_DEPTH_SHARED);
			[GeneratedDllImport("sourcesdkc")]
			internal static partial IntPtr IMaterialSystem_CreateNamedRenderTargetTextureEx(IntPtr m, [MarshalAs(UnmanagedType.LPUTF8Str)] string pRTName, int w, int h, RenderTargetSizeMode_t sizeMode, ImageFormat format, MaterialRenderTargetDepth_t depth, CompiledVtfFlags textureFlags = CompiledVtfFlags.TEXTUREFLAGS_CLAMPS | CompiledVtfFlags.TEXTUREFLAGS_CLAMPT, CREATERENDERTARGETFLAGS renderTargetFlags = 0);
			[GeneratedDllImport("sourcesdkc")]
			internal static partial IntPtr IMaterialSystem_CreateNamedRenderTargetTexture(IntPtr m, [MarshalAs(UnmanagedType.LPUTF8Str)] string pRTName, int w, int h, RenderTargetSizeMode_t sizeMode, ImageFormat format, MaterialRenderTargetDepth_t depth, [MarshalAs(UnmanagedType.I1)] bool bClampTexCoords, [MarshalAs(UnmanagedType.I1)] bool bAutoMipMap);
			[GeneratedDllImport("sourcesdkc")]
			internal static partial IntPtr IMaterialSystem_CreateNamedRenderTargetTextureEx2(IntPtr m, [MarshalAs(UnmanagedType.LPUTF8Str)] string pRTName, int w, int h, RenderTargetSizeMode_t sizeMode, ImageFormat format, MaterialRenderTargetDepth_t depth, CompiledVtfFlags textureFlags, CREATERENDERTARGETFLAGS renderTargetFlags);
		}
	}
}
