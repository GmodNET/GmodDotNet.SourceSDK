using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SourceSDK
{
	public unsafe struct IFileSystem
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate byte _IsSteam(IFileSystem* pThis);

		public unsafe IntPtr* lpVtbl;
		//public extern bool IsSteam();
		public bool IsSteam()
		{
			IntPtr isSteamPtr = lpVtbl[22];
			if (isSteamPtr == IntPtr.Zero) throw new KeyNotFoundException("isSteamPtr");
			_IsSteam isSteam = Marshal.GetDelegateForFunctionPointer<_IsSteam>(isSteamPtr);
			IFileSystem* fs = (IFileSystem*)Unsafe.AsPointer(ref this);
			return isSteam(fs) != 0;
		}
	}
}
