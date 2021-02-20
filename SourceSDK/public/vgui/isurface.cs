using GmodNET.SourceSDK.AppFramework;
using GmodNET.SourceSDK.bitmap;
using System;
using System.Runtime.InteropServices;

namespace GmodNET.SourceSDK.vgui
{
	public class ISurface : IAppSystem
	{
		public ISurface(IntPtr ptr) : base(ptr) { }

		public void DrawFilledRect(int x0, int y0, int x1, int y1) => Methods.ISurface_DrawFilledRect(ptr, x0, y0, x1, y1);

		internal static class Methods
		{
			[DllImport("sourcesdkc")]
			internal static extern void ISurface_DrawFilledRect(IntPtr ptr, int x0, int y0, int x1, int y1);


			[DllImport("sourcesdkc")]
			internal static extern void ISurface_DrawSetTextureRGBAex(IntPtr ptr, int id, IntPtr rgba, int wide, int tall, ImageFormat imageFormat);
		}
	}
}
