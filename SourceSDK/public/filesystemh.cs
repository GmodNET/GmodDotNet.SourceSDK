using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SourceSDK
{
	public struct IFileSystem
	{
		public static class Delegates
		{
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public delegate bool rBool();
		}

		public Delegates.rBool IsSteam;
	}
}
