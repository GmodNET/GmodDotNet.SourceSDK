using System;
using System.Runtime.InteropServices;

namespace GmodNET.SourceSDK.VGuiMatSurface
{
	public unsafe delegate void GetMouseCallback_t(int* x, int* y);
	public delegate void SetMouseCallback_t(int x, int y);
	public delegate void PlaySoundFunc_t([MarshalAs(UnmanagedType.LPUTF8Str)] string fileName);

	public partial class IMatSystemSurface : vgui.ISurface
	{
		public const string MAT_SYSTEM_SURFACE_INTERFACE_VERSION = "MatSystemSurface008";
		public IMatSystemSurface(IntPtr ptr) : base(ptr)
		{ }

		public void AttachToWindow(IntPtr hwnd, bool bLetAppDriveInput = false) => Methods.IMatSystemSurface_AttachToWindow(ptr, hwnd, bLetAppDriveInput);
		public void EnableWindowsMessages(bool enable) => Methods.IMatSystemSurface_EnableWindowsMessages(ptr, enable);

		public void Begin3DPaint(int left, int top, int right, int bottom, bool renderToTexture) => Methods.IMatSystemSurface_Begin3DPaint(ptr, left, top, right, bottom, renderToTexture);
		public void End3DPaint() => Methods.IMatSystemSurface_End3DPaint(ptr);

		public void DisableClipping(bool disable) => Methods.IMatSystemSurface_DisableClipping(ptr, disable);

		public void GetClippingRect(ref int left, ref int top, ref int right, ref int bottom, ref bool clippingDisabled) => Methods.IMatSystemSurface_GetClippingRect(ptr, ref left, ref top, ref right, ref bottom, ref clippingDisabled);
		public void SetClippingRect(int left, int top, int right, int bottom) => Methods.IMatSystemSurface_SetClippingRect(ptr, left, top, right, bottom);

		public bool IsCursorLocked => Methods.IMatSystemSurface_IsCursorLocked(ptr);

		public void SetMouseCallbacks(GetMouseCallback_t get, SetMouseCallback_t set) => Methods.IMatSystemSurface_SetMouseCallbacks(ptr, get, set);
		public void InstallPlaySoundFunc(PlaySoundFunc_t func) => Methods.IMatSystemSurface_InstallPlaySoundFunc(ptr, func);

		new internal static partial class Methods
		{
			[GeneratedDllImport("sourcesdkc")]
			internal static partial void IMatSystemSurface_AttachToWindow(IntPtr s, IntPtr hwnd, [MarshalAs(UnmanagedType.I1)] bool bLetAppDriveInput);

			[GeneratedDllImport("sourcesdkc")]
			internal static partial void IMatSystemSurface_EnableWindowsMessages(IntPtr s, [MarshalAs(UnmanagedType.I1)] bool enable);

			[GeneratedDllImport("sourcesdkc")]
			internal static partial void IMatSystemSurface_Begin3DPaint(IntPtr s, int iLeft, int iTop, int iRight, int iBottom, [MarshalAs(UnmanagedType.I1)] bool bRenderToTexture);
			[DllImport("sourcesdkc")]
			internal static extern void IMatSystemSurface_End3DPaint(IntPtr s);

			[GeneratedDllImport("sourcesdkc")]
			internal static partial void IMatSystemSurface_DisableClipping(IntPtr s, [MarshalAs(UnmanagedType.I1)] bool disable);

			[GeneratedDllImport("sourcesdkc")]
			internal static partial void IMatSystemSurface_GetClippingRect(IntPtr s, ref int left, ref int top, ref int right, ref int bottom, [MarshalAs(UnmanagedType.I1)] ref bool clippingDisabled);
			[DllImport("sourcesdkc")]
			internal static extern void IMatSystemSurface_SetClippingRect(IntPtr s, int left, int top, int right, int bottom);

			[GeneratedDllImport("sourcesdkc")]
			[return: MarshalAs(UnmanagedType.I1)]
			internal static partial bool IMatSystemSurface_IsCursorLocked(IntPtr s);

			[DllImport("sourcesdkc")]
			internal static extern void IMatSystemSurface_SetMouseCallbacks(IntPtr s, GetMouseCallback_t get, SetMouseCallback_t set);
			[DllImport("sourcesdkc")]
			internal static extern void IMatSystemSurface_InstallPlaySoundFunc(IntPtr s, PlaySoundFunc_t func);
		}
	}
}
