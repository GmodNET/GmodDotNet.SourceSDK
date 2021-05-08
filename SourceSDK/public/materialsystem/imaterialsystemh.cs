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
