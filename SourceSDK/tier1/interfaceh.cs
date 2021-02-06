using System;
using System.Runtime.InteropServices;

namespace SourceSDK.Tier1
{
	public delegate IntPtr CreateInterfaceFn(string name, IntPtr returnCode);
	public static class interfaceh
	{
		public const string CREATEINTERFACE_PROCNAME = "CreateInterface";
		public static CreateInterfaceFn Sys_GetFactory(IntPtr module)
		{
			IntPtr createInterfaceFnPtr = NativeLibrary.GetExport(module, CREATEINTERFACE_PROCNAME);
			return Marshal.GetDelegateForFunctionPointer<CreateInterfaceFn>(createInterfaceFnPtr);
		}
		public static CreateInterfaceFn Sys_GetFactory(string module)
		{
			return Sys_GetFactory(NativeLibrary.Load(module));
		}
	}
}
