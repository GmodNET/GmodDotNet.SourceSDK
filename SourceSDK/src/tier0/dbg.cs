using System.Runtime.InteropServices;

namespace SourceSDK.Tier0
{
	/// <remarks>
	/// "public/tier0/dbg.h"
	/// </remarks>
	class Dbg
	{
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


		[DllImport("tier0", EntryPoint = "?ConColorMsg@@YAXAEBVColor@@PEBDZZ", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ConColorMsg(in Color clr, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

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
