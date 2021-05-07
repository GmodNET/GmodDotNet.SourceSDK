using System;
using System.Numerics;
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

		public void DrawColoredCircle(int centerx, int centery, float radius, int r, int g, int b, int a) => Methods.IMatSystemSurface_DrawColoredCircle(ptr, centerx, centery, radius, r, g, b, a);
		public int DrawColoredText(ulong font, int x, int y, int r, int g, int b, int a, string fmt) => Methods.IMatSystemSurface_DrawColoredText(ptr, font, x, y, r, g, b, a, fmt);

		public void DrawColoredTextRect(ulong font, int x, int y, int w, int h, int r, int g, int b, int a, string fmt) => Methods.IMatSystemSurface_DrawColoredTextRect(ptr, font, x, y, w, h, r, g, b, a, fmt);
		public void DrawTextHeight(ulong font, int w, ref int h, string fmt) => Methods.IMatSystemSurface_DrawTextHeight(ptr, font, w, ref h, fmt);

		public int DrawTextLen(ulong font, string fmt) => Methods.IMatSystemSurface_DrawTextLen(ptr, font, fmt);
		public void DrawPanelIn3DSpace(uint pRootPanel, ref Matrix4x4 panelCenterToWorld, int nPixelWidth, int nPixelHeight, float flWorldWidth, float flWorldHeight) => Methods.IMatSystemSurface_DrawPanelIn3DSpace(ptr, pRootPanel, ref panelCenterToWorld, nPixelWidth, nPixelHeight, flWorldWidth, flWorldHeight);

		// todo: ITexture bindings
		public void DrawSetTextureMaterial(int id, IntPtr texture) => Methods.IMatSystemSurface_DrawSetTextureMaterial(ptr, id, texture);

		public void Set3DPaintTempRenderTarget(string name) => Methods.IMatSystemSurface_Set3DPaintTempRenderTarget(ptr, name);
		public void Reset3DPaintTempRenderTarget() => Methods.IMatSystemSurface_Reset3DPaintTempRenderTarget(ptr);

		// todo: ITexture bindings
		public IntPtr DrawGetTextureMaterial(int id) => Methods.IMatSystemSurface_DrawGetTextureMaterial(ptr, id);

		public void GetFullscreenViewportAndRenderTarget(ref int x, ref int y, ref int w, ref int h, out IntPtr texture) => Methods.IMatSystemSurface_GetFullscreenViewportAndRenderTarget(ptr, ref x, ref y, ref w, ref h, out texture);
		public void SetFullscreenViewportAndRenderTarget(int x, int y, int w, int h, IntPtr texture) => Methods.IMatSystemSurface_SetFullscreenViewportAndRenderTarget(ptr, x, y, w, h, texture);

		public int DrawGetTextureId(IntPtr texture) => Methods.IMatSystemSurface_DrawGetTextureId(ptr, texture);

		public void BeginSkinCompositionPainting() => Methods.IMatSystemSurface_BeginSkinCompositionPainting(ptr);
		public void EndSkinCompositionPainting() => Methods.IMatSystemSurface_EndSkinCompositionPainting(ptr);


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

			[DllImport("sourcesdkc")]
			internal static extern void IMatSystemSurface_DrawColoredCircle(IntPtr s, int centerx, int centery, float radius, int r, int g, int b, int a);
			[GeneratedDllImport("sourcesdkc")]
			internal static partial int IMatSystemSurface_DrawColoredText(IntPtr s, ulong font, int x, int y, int r, int g, int b, int a, [MarshalAs(UnmanagedType.LPUTF8Str)] string fmt);

			[GeneratedDllImport("sourcesdkc")]
			internal static partial void IMatSystemSurface_DrawColoredTextRect(IntPtr s, ulong font, int x, int y, int w, int h, int r, int g, int b, int a, [MarshalAs(UnmanagedType.LPUTF8Str)] string fmt);
			[GeneratedDllImport("sourcesdkc")]
			internal static partial void IMatSystemSurface_DrawTextHeight(IntPtr s, ulong font, int w, ref int h, [MarshalAs(UnmanagedType.LPUTF8Str)] string fmt);

			[GeneratedDllImport("sourcesdkc")]
			internal static partial int IMatSystemSurface_DrawTextLen(IntPtr s, ulong font, [MarshalAs(UnmanagedType.LPUTF8Str)] string fmt);

			[DllImport("sourcesdkc")]
			internal static extern void IMatSystemSurface_DrawPanelIn3DSpace(IntPtr s, uint pRootPanel, ref Matrix4x4 panelCenterToWorld, int nPixelWidth, int nPixelHeight, float flWorldWidth, float flWorldHeight);

			[DllImport("sourcesdkc")]
			internal static extern void IMatSystemSurface_DrawSetTextureMaterial(IntPtr s, int id, IntPtr material);

			[GeneratedDllImport("sourcesdkc")]
			internal static partial void IMatSystemSurface_Set3DPaintTempRenderTarget(IntPtr s, [MarshalAs(UnmanagedType.LPUTF8Str)] string renderTargetName);
			[GeneratedDllImport("sourcesdkc")]
			internal static partial void IMatSystemSurface_Reset3DPaintTempRenderTarget(IntPtr s);

			[DllImport("sourcesdkc")]
			internal static extern IntPtr IMatSystemSurface_DrawGetTextureMaterial(IntPtr s, int id);

			[GeneratedDllImport("sourcesdkc")]
			internal static partial void IMatSystemSurface_GetFullscreenViewportAndRenderTarget(IntPtr s, ref int x, ref int y, ref int w, ref int h, out IntPtr texture);
			[DllImport("sourcesdkc")]
			internal static extern void IMatSystemSurface_SetFullscreenViewportAndRenderTarget(IntPtr s, int x, int y, int w, int h, IntPtr texture);

			[DllImport("sourcesdkc")]
			internal static extern int IMatSystemSurface_DrawGetTextureId(IntPtr s, IntPtr texture);

			[DllImport("sourcesdkc")]
			internal static extern void IMatSystemSurface_BeginSkinCompositionPainting(IntPtr s);
			[DllImport("sourcesdkc")]
			internal static extern void IMatSystemSurface_EndSkinCompositionPainting(IntPtr s);
		}
	}
}
