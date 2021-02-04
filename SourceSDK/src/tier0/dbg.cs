using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SourceSDK.Tier0
{
	/// <remarks>
	/// "public/tier0/dbg.h"
	/// </remarks>
	public class Dbg
	{
		static Dbg()
		{
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
			{
				ConColorMsg = Windows.ConColorMsg;
			}
			else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
			{
				ConColorMsg = Linux.ConColorMsg;
			}
			else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
			{
				ConColorMsg = OSX.ConColorMsg;
			}
		}

		internal class Windows
		{
			[DllImport("tier0", EntryPoint = "?ConColorMsg@@YAXAEBVColor@@PEBDZZ", CallingConvention = CallingConvention.Cdecl)]
			public static extern void ConColorMsg(in Color clr, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg);
		}
		internal class Linux
		{
			[DllImport("tier0", EntryPoint = "_Z11ConColorMsgRK5ColorPKcz", CallingConvention = CallingConvention.Cdecl)]
			public static extern void ConColorMsg(in Color clr, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg);
		}
		internal class OSX
		{
			[DllImport("tier0", EntryPoint = "todo", CallingConvention = CallingConvention.Cdecl)]
			public static extern void ConColorMsg(in Color clr, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg);
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



		[DllImport("tier0", EntryPoint = "?DevMsg@@YAXPEBDZZ", CallingConvention = CallingConvention.Cdecl)]
		public static extern void DevMsg([MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

		[DllImport("tier0", EntryPoint = "?DevWarning@@YAXPEBDZZ", CallingConvention = CallingConvention.Cdecl)]
		public static extern void DevWarning([MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

		[DllImport("tier0", EntryPoint = "?DevLog@@YAXPBDZZ", CallingConvention = CallingConvention.Cdecl)]
		public static extern void DevLog([MarshalAs(UnmanagedType.LPUTF8Str)] string msg);


		public static Delegates.void_inColor_string ConColorMsg;


		[DllImport("tier0", EntryPoint = "?ConMsg@@YAXPEBDZZ", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ConMsg([MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

		[DllImport("tier0", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ConDMsg([MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

		// TODO: ValidateSpew


		[DllImport("tier0", CallingConvention = CallingConvention.Cdecl)]
		public static extern void COM_TimestampedLog([MarshalAs(UnmanagedType.LPUTF8Str)] string fmt, params string[] dotdotdot);
	}
}
