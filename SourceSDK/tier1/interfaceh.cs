using System;
using System.Runtime.InteropServices;

namespace SourceSDK.Tier1
{
	public static class interfaceh
	{
		public const string CREATEINTERFACE_PROCNAME = "CreateInterface";
		public delegate IntPtr CreateInterfaceFn(IntPtr name, IntPtr returnCode);
		public static CreateInterfaceFn Sys_GetFactory(IntPtr module)
		{
			IntPtr createInterfaceFnPtr = NativeLibrary.GetExport(module, CREATEINTERFACE_PROCNAME);
			if (createInterfaceFnPtr == IntPtr.Zero)
			{
				throw new EntryPointNotFoundException("CreateInterface was not found");
			}
			return Marshal.GetDelegateForFunctionPointer<CreateInterfaceFn>(createInterfaceFnPtr);
		}
		public static CreateInterfaceFn Sys_GetFactory(string module)
		{
			return Sys_GetFactory(NativeLibrary.Load(module));
		}
	}
}
