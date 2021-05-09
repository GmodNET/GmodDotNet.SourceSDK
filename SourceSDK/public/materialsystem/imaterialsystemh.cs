using GmodNET.SourceSDK.Tier1;
using GmodNET.SourceSDK.vgui;
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
		}
	}
}
