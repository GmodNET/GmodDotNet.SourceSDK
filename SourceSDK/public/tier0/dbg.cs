using System;
using System.Runtime.InteropServices;

namespace GmodNET.SourceSDK.Tier0
{
	/// <remarks>
	/// "public/tier0/dbg.h"
	/// </remarks>
	public static class Dbg
	{
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
		public static extern void Warning_SpewCallStack(int maxCallStackLength, [MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

		[DllImport("tier0", CallingConvention = CallingConvention.Cdecl)]
		public static extern void Error([MarshalAs(UnmanagedType.LPUTF8Str)] string msg);


		public static readonly Delegates.void_string DevMsg = SymbolResolver.GetSymbol<Delegates.void_string>("tier0", EntryPoints.DevMsg_win64, EntryPoints.DevMsg_linux64);
		public static readonly Delegates.void_string DevWarning = SymbolResolver.GetSymbol<Delegates.void_string>("tier0", EntryPoints.DevWarning_win64, EntryPoints.DevWarning_linux64);

		public static readonly Delegates.void_inColor_string ConColorMsg = SymbolResolver.GetSymbol<Delegates.void_inColor_string>("tier0", EntryPoints.ConColorMsg_win64, EntryPoints.ConColorMsg_linux64);
		public static readonly Delegates.void_string ConMsg = SymbolResolver.GetSymbol<Delegates.void_string>("tier0", EntryPoints.ConMsg_win64, EntryPoints.ConMsg_linux64);

		[DllImport("tier0", CallingConvention = CallingConvention.Cdecl)]
		public static extern void ConDMsg([MarshalAs(UnmanagedType.LPUTF8Str)] string msg);

		/// <summary>
		/// </summary>
		/// <param name="fmt"></param>
		/// <param name="dotdotdot"></param>
		/// <remarks>
		/// SupinePandora43: doesn't work, i don't know how it supposed to work
		/// </remarks>
		[DllImport("tier0", CallingConvention = CallingConvention.Cdecl)]
		public static extern void COM_TimestampedLog([MarshalAs(UnmanagedType.LPUTF8Str)] string fmt, string dotdotdot);
	}

	public static class CDbgFmtMsg
	{
#nullable enable
		public static string Format(string format, params object?[]? args)
		{
			if (args is null || args.Length < 1)
			{
				return format;
			}
			foreach (var obj in args)
			{
				if (obj is int)
				{

				}
			}
			throw new NotImplementedException("todo");
		}
#nullable restore
	}
}
