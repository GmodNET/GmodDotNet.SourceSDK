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
				ConColorMsg_Color_string_delegate = Windows.ConColorMsg;
			}else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
			{
				ConColorMsg_Color_string_delegate = Linux.ConColorMsg;
			}
			else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
			{
				ConColorMsg_Color_string_delegate = OSX.ConColorMsg;
			}
		}

		internal class Windows
		{
			[DllImport("tier0", EntryPoint = "?ConColorMsg@@YAXAEBVColor@@PEBDZZ", CallingConvention = CallingConvention.Cdecl)]
			public static extern void ConColorMsg(in Color clr, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg);
		}
		internal class Linux
		{
			[DllImport("tier0", EntryPoint = "ConColorMsg", CallingConvention = CallingConvention.Cdecl)]
			public static extern void ConColorMsg(in Color clr, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg);
		}
		internal class OSX
		{
			[DllImport("tier0", EntryPoint = "empty", CallingConvention = CallingConvention.Cdecl)]
			public static extern void ConColorMsg(in Color clr, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg);
		}

		internal class Delegates
		{
			internal delegate void void_string(string str);
			internal delegate void void_inColor_string(in Color clr, string msg);
		}

		internal static Delegates.void_inColor_string ConColorMsg_Color_string_delegate;


		#region
		[DllImport("tier0", CallingConvention = CallingConvention.Cdecl)]
		public static extern void Msg([MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

		[DllImport("tier0", CallingConvention = CallingConvention.Cdecl)]
		public static extern void DMsg([MarshalAs(UnmanagedType.LPUTF8Str)] string groupName, int level, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

		[DllImport("tier0", CallingConvention = CallingConvention.Cdecl)]
		public static extern void MsgV([MarshalAs(UnmanagedType.LPUTF8Str)] string msg, System.ArgIterator arglist);
		#endregion
		#region
		[DllImport("tier0", CallingConvention = CallingConvention.Cdecl)]
		public static extern void Warning([MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

		[DllImport("tier0", CallingConvention = CallingConvention.Cdecl)]
		public static extern void DWarning([MarshalAs(UnmanagedType.LPUTF8Str)] string groupName, int level, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

		[DllImport("tier0", CallingConvention = CallingConvention.Cdecl)]
		public static extern void WarningV([MarshalAs(UnmanagedType.LPUTF8Str)] string msg, System.ArgIterator arglist);
		#endregion
		#region
		[DllImport("tier0", CallingConvention = CallingConvention.Cdecl)]
		public static extern void Log([MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

		[DllImport("tier0", CallingConvention = CallingConvention.Cdecl)]
		public static extern void DLog([MarshalAs(UnmanagedType.LPUTF8Str)] string groupName, int level, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

		[DllImport("tier0", CallingConvention = CallingConvention.Cdecl)]
		public static extern void LogV([MarshalAs(UnmanagedType.LPUTF8Str)] string msg, System.ArgIterator arglist);
		#endregion
		#region
		[DllImport("tier0", CallingConvention = CallingConvention.Cdecl)]
		public static extern void Error([MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

		[DllImport("tier0", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ErrorV([MarshalAs(UnmanagedType.LPUTF8Str)] string msg, System.ArgIterator arglist);
		#endregion
		#region

		[DllImport("tier0", CallingConvention = CallingConvention.Cdecl)]
		public static extern void DevMsg(int level, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

		[DllImport("tier0", CallingConvention = CallingConvention.Cdecl)]
		public static extern void DevWarning(int level, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

		[DllImport("tier0", CallingConvention = CallingConvention.Cdecl)]
		public static extern void DevLog(int level, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg);


		[DllImport("tier0", EntryPoint = "?DevMsg@@YAXPEBDZZ", CallingConvention = CallingConvention.Cdecl)]
		public static extern void DevMsg([MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

		[DllImport("tier0", EntryPoint = "?DevWarning@@YAXPEBDZZ", CallingConvention = CallingConvention.Cdecl)]
		public static extern void DevWarning([MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

		[DllImport("tier0", EntryPoint = "?DevLog@@YAXPEBDZZ", CallingConvention = CallingConvention.Cdecl)]
		public static extern void DevLog([MarshalAs(UnmanagedType.LPUTF8Str)] string msg);


		[DllImport("tier0", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ConColorMsg(int level, in Color clr, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

		[DllImport("tier0", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ConMsg(int level, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

		[DllImport("tier0", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ConWarning(int level, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

		[DllImport("tier0", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ConLog(int level, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ConColorMsg(in Color clr, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg)
		{
			ConColorMsg_Color_string_delegate(clr, msg);
		}

		[DllImport("tier0", EntryPoint = "?ConMsg@@YAXPBDZZ", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ConMsg([MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

		[DllImport("tier0", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ConWarning([MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

		[DllImport("tier0", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ConLog([MarshalAs(UnmanagedType.LPUTF8Str)] string msg);


		[DllImport("tier0", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ConDColorMsg(in Color clr, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

		[DllImport("tier0", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ConDMsg([MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

		[DllImport("tier0", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ConDWarning([MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

		[DllImport("tier0", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ConDLog([MarshalAs(UnmanagedType.LPUTF8Str)] string msg);


		[DllImport("tier0", CallingConvention = CallingConvention.Cdecl)]
		public static extern void NetMsg(int level, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

		[DllImport("tier0", CallingConvention = CallingConvention.Cdecl)]
		public static extern void NetWarning(int level, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

		[DllImport("tier0", CallingConvention = CallingConvention.Cdecl)]
		public static extern void NetLog(int level, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

		// TODO: ValidateSpew

		#endregion

		[DllImport("tier0", CallingConvention = CallingConvention.Cdecl)]
		public static extern void COM_TimestampedLog([MarshalAs(UnmanagedType.LPUTF8Str)] string fmt);
	}
}
