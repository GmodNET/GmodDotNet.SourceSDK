using GmodNET.SourceSDK.AppFramework;
using GmodNET.SourceSDK.bitmap;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace GmodNET.SourceSDK.vgui
{
	[StructLayout(LayoutKind.Sequential)]
	[BlittableType]
	public struct IntRect
	{
		public int x0;
		public int y0;
		public int x1;
		public int y1;
	};
	public partial class ISurface : IAppSystem
	{
		public const string VGUI_SURFACE_INTERFACE_VERSION = "VGUI_Surface030";

		public ISurface(IntPtr ptr) : base(ptr) { }

		public new void Shutdown() => Methods.ISurface_Shutdown(ptr);

		public void RunFrame() => Methods.ISurface_RunFrame(ptr);

		public uint GetEmbeddedPanel() => Methods.ISurface_GetEmbeddedPanel(ptr);
		public void SetEmbeddedPanel(uint panel) => Methods.ISurface_SetEmbeddedPanel(ptr, panel);

		public void PushMakeCurrent(uint panel, bool useInsets) => Methods.ISurface_PushMakeCurrent(ptr, panel, useInsets);
		public void PopMakeCurrent(uint panel) => Methods.ISurface_PopMakeCurrent(ptr, panel);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DrawSetColor(int r, int g, int b, int a) => Methods.ISurface_DrawSetColor(ptr, r, g, b, a);
		public void DrawSetColor(Color color) => Methods.ISurface_DrawSetColor(ptr, color);

		[MethodImpl(MethodImplOptions.AggressiveInlining)] // guess why ;D
		public void DrawFilledRect(int x0, int y0, int x1, int y1) => Methods.ISurface_DrawFilledRect(ptr, x0, y0, x1, y1);
		public void DrawFilledRectArray(IntRect[] rects) => Methods.ISurface_DrawFilledRectArray(ptr, rects, rects.Length);
		public void DrawFilledRectArray(IntRect[] rects, int numRects) => Methods.ISurface_DrawFilledRectArray(ptr, rects, numRects);
		public unsafe void DrawFilledRectArray(IntRect* rects, int numRects) => Methods.ISurface_DrawFilledRectArray(ptr, rects, numRects);
		public void DrawOutlinedRect(int x0, int y0, int x1, int y1) => Methods.ISurface_DrawOutlinedRect(ptr, x0, y0, x1, y1);

		public void DrawLine(int x0, int y0, int x1, int y1) => Methods.ISurface_DrawLine(ptr, x0, y0, x1, y1);
		public void DrawPolyLine(int[] px, int[] py, int numPoints) => Methods.ISurface_DrawPolyLine(ptr, px, py, numPoints);
		public void DrawPolyLine(int[] px, int[] py) => Methods.ISurface_DrawPolyLine(ptr, px, py, Math.Min(px.Length, py.Length));
		public unsafe void DrawPolyLine(int* px, int* py, int numPoints) => Methods.ISurface_DrawPolyLine(ptr, px, py, numPoints);

		internal static partial class Methods
		{
			[DllImport("sourcesdkc")]
			internal static extern void ISurface_Shutdown(IntPtr ptr);

			[DllImport("sourcesdkc")]
			internal static extern void ISurface_RunFrame(IntPtr ptr);

			[DllImport("sourcesdkc")]
			internal static extern uint ISurface_GetEmbeddedPanel(IntPtr ptr);
			[DllImport("sourcesdkc")]
			internal static extern void ISurface_SetEmbeddedPanel(IntPtr ptr, uint panel);

			[GeneratedDllImport("sourcesdkc")]
			internal static partial void ISurface_PushMakeCurrent(IntPtr ptr, uint panel, [MarshalAs(UnmanagedType.I1)] bool useInsets);
			[DllImport("sourcesdkc")]
			internal static extern void ISurface_PopMakeCurrent(IntPtr ptr, uint panel);

			[DllImport("sourcesdkc", EntryPoint = "ISurface_DrawSetColor_RGBA")]
			internal static extern void ISurface_DrawSetColor(IntPtr ptr, int r, int g, int b, int a);
			[DllImport("sourcesdkc", EntryPoint = "ISurface_DrawSetColor_COLOR")]
			internal static extern void ISurface_DrawSetColor(IntPtr ptr, Color color);

			[DllImport("sourcesdkc")]
			internal static extern void ISurface_DrawFilledRect(IntPtr ptr, int x0, int y0, int x1, int y1);
			[GeneratedDllImport("sourcesdkc")]
			internal static partial void ISurface_DrawFilledRectArray(IntPtr ptr, IntRect[] rects, int numRects);
			[DllImport("sourcesdkc")]
			internal static unsafe extern void ISurface_DrawFilledRectArray(IntPtr ptr, IntRect* rects, int numRects);
			[DllImport("sourcesdkc")]
			internal static extern void ISurface_DrawOutlinedRect(IntPtr ptr, int x0, int y0, int x1, int y1);

			[DllImport("sourcesdkc")]
			internal static extern void ISurface_DrawLine(IntPtr ptr, int x0, int y0, int x1, int y1);
			[GeneratedDllImport("sourcesdkc")]
			internal static unsafe partial void ISurface_DrawPolyLine(IntPtr ptr, int[] px, int[] py, int numPoints);
			[DllImport("sourcesdkc")]
			internal static unsafe extern void ISurface_DrawPolyLine(IntPtr ptr, int* px, int* py, int numPoints);

			[DllImport("sourcesdkc")]
			internal static extern void ISurface_DrawSetTextureRGBAex(IntPtr ptr, int id, IntPtr rgba, int wide, int tall, ImageFormat imageFormat);
		}
	}
}
