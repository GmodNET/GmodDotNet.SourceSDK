using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SourceSDK.Tier0
{
	/// <remarks>
	/// "public/tier0/dbg.h"
	/// </remarks>
	public static class Dbg
	{
		static Dbg()
		{
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
			{
				DevMsg = Windows.DevMsg;
				DevWarning = Windows.DevWarning;
				ConColorMsg = Windows.ConColorMsg;
				ConMsg = Windows.ConMsg;
			}
			else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
			{
				DevMsg = Linux.DevMsg;
				DevWarning = Linux.DevWarning;
				ConColorMsg = Linux.ConColorMsg;
				ConMsg = Linux.ConMsg;
			}
			else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
			{
				DevMsg = OSX.DevMsg;
				DevWarning = OSX.DevWarning;
				ConColorMsg = OSX.ConColorMsg;
				ConMsg = OSX.ConMsg;
			}
			else
			{
				throw new PlatformNotSupportedException();
			}
		}

		internal class Windows
		{
			[DllImport("tier0", EntryPoint = "?DevMsg@@YAXPEBDZZ", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DevMsg([MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

			[DllImport("tier0", EntryPoint = "?DevWarning@@YAXPEBDZZ", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DevWarning([MarshalAs(UnmanagedType.LPUTF8Str)] string msg);


			[DllImport("tier0", EntryPoint = "?ConColorMsg@@YAXAEBVColor@@PEBDZZ", CallingConvention = CallingConvention.Cdecl)]
			public static extern void ConColorMsg(in Color clr, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

			[DllImport("tier0", EntryPoint = "?ConMsg@@YAXPEBDZZ", CallingConvention = CallingConvention.Cdecl)]
			public static extern void ConMsg([MarshalAs(UnmanagedType.LPUTF8Str)] string msg);
		}
		internal class Linux
		{
			[DllImport("tier0", EntryPoint = "_Z6DevMsgPKcz", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DevMsg([MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

			[DllImport("tier0", EntryPoint = "_Z10DevWarningPKcz", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DevWarning([MarshalAs(UnmanagedType.LPUTF8Str)] string msg);


			[DllImport("tier0", EntryPoint = "_Z11ConColorMsgRK5ColorPKcz", CallingConvention = CallingConvention.Cdecl)]
			public static extern void ConColorMsg(in Color clr, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

			[DllImport("tier0", EntryPoint = "_Z6ConMsgPKcz", CallingConvention = CallingConvention.Cdecl)]
			public static extern void ConMsg([MarshalAs(UnmanagedType.LPUTF8Str)] string msg);
		}
		internal class OSX
		{
			[DllImport("tier0", EntryPoint = "__Z6DevMsgPKcz", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DevMsg([MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

			[DllImport("tier0", EntryPoint = "__Z10DevWarningPKcz", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DevWarning([MarshalAs(UnmanagedType.LPUTF8Str)] string msg);


			[DllImport("tier0", EntryPoint = "__Z11ConColorMsgRK5ColorPKcz", CallingConvention = CallingConvention.Cdecl)]
			public static extern void ConColorMsg(in Color clr, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

			[DllImport("tier0", EntryPoint = "__Z6ConMsgPKcz", CallingConvention = CallingConvention.Cdecl)]
			public static extern void ConMsg([MarshalAs(UnmanagedType.LPUTF8Str)] string msg);
		}

		public static class Delegates
		{
			public delegate void void_string(string str);
			public delegate void void_inColor_string(in Color clr, string msg);
		}

		[DllImport("tier0", CallingConvention = CallingConvention.Cdecl)]
		public static extern void Msg([MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

		[DllImport("tier0", CallingConvention = CallingConvention.Cdecl)]
		public static extern void Warning([MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

		[DllImport("tier0", CallingConvention = CallingConvention.Cdecl)]
		public static extern void Error([MarshalAs(UnmanagedType.LPUTF8Str)] string msg);


		public static Delegates.void_string DevMsg;
		public static Delegates.void_string DevWarning;


		public static Delegates.void_inColor_string ConColorMsg;
		public static Delegates.void_string ConMsg;

		[DllImport("tier0", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ConDMsg([MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

		[DllImport("tier0", CallingConvention = CallingConvention.Cdecl)]
		public static extern void COM_TimestampedLog([MarshalAs(UnmanagedType.LPUTF8Str)] string fmt, params string[] dotdotdot);
	}
}
