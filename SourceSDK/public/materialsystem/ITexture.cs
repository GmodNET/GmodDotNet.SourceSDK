using System;
using System.Runtime.InteropServices;

namespace GmodNET.SourceSDK.materialsystem
{
	public partial class ITexture
	{
		private readonly IntPtr t;

		public ITexture(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero) throw new ArgumentNullException(nameof(ptr), "Passing invalid pointer will cause crash");

			t = ptr;
		}

		public string Name => Methods.ITexture_GetName(t);
		public int MappingWidth => Methods.ITexture_GetMappingWidth(t);
		public int MappingHeight => Methods.ITexture_GetMappingHeight(t);
		public int ActualWidth => Methods.ITexture_GetActualWidth(t);
		public int ActualHeight => Methods.ITexture_GetActualHeight(t);
		public int NumAnimationFrames => Methods.ITexture_GetNumAnimationFrames(t);
		public bool IsTranslucent => Methods.ITexture_IsTranslucent(t);
		public bool IsMipmapped => Methods.ITexture_IsMipmapped(t);

		private static partial class Methods
		{
			[GeneratedDllImport("sourcesdkc")]
			[return: MarshalAs(UnmanagedType.LPUTF8Str)]
			public static partial string ITexture_GetName(IntPtr t);
			[DllImport("sourcesdkc")]
			public static extern int ITexture_GetMappingWidth(IntPtr t);
			[DllImport("sourcesdkc")]
			public static extern int ITexture_GetMappingHeight(IntPtr t);
			[DllImport("sourcesdkc")]
			public static extern int ITexture_GetActualWidth(IntPtr t);
			[DllImport("sourcesdkc")]
			public static extern int ITexture_GetActualHeight(IntPtr t);
			[DllImport("sourcesdkc")]
			public static extern int ITexture_GetNumAnimationFrames(IntPtr t);
			[GeneratedDllImport("sourcesdkc")]
			[return: MarshalAs(UnmanagedType.I1)]
			public static partial bool ITexture_IsTranslucent(IntPtr t);
			[GeneratedDllImport("sourcesdkc")]
			[return: MarshalAs(UnmanagedType.I1)]
			public static partial bool ITexture_IsMipmapped(IntPtr t);
		}
	}
}
