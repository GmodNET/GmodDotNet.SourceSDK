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

		public unsafe void** lpVtbl;
		//public extern bool IsSteam();
		public bool IsSteam()
		{
			return Marshal.GetDelegateForFunctionPointer<_IsSteam>((IntPtr)(lpVtbl[22]))((IFileSystem*)Unsafe.AsPointer(ref this)) != 0;
		}
	}
}
