using System;
using System.Runtime.InteropServices;

namespace SourceSDK.tier1
{
	class interfaceh
	{
		public const string CREATEINTERFACE_PROCNAME = "CreateInterface";
		public delegate IntPtr CreateInterfaceFn(string name, int returnCode);

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
