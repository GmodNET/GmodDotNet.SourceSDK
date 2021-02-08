using System;
using System.Runtime.InteropServices;

namespace GmodNET.SourceSDK.Tier1
{
	public enum IFACE
	{
		OK = 0,
		FAILED = 1
	}

	public delegate IntPtr CreateInterfaceFn(string name, out IFACE returnCode);
	public static class interfaceh
	{
		public const string CREATEINTERFACE_PROCNAME = "CreateInterface";

		public static CreateInterfaceFn Sys_GetFactory(IntPtr module)
		{
			IntPtr createInterfaceFnPtr = NativeLibrary.GetExport(module, CREATEINTERFACE_PROCNAME);

			if (createInterfaceFnPtr == IntPtr.Zero)
				throw new EntryPointNotFoundException("CreateInterface was not found");

			return Marshal.GetDelegateForFunctionPointer<CreateInterfaceFn>(createInterfaceFnPtr);
		}

		public static CreateInterfaceFn Sys_GetFactory(string module)
		{
			IntPtr handle = NativeLibrary.Load(module);

			if (handle == IntPtr.Zero)
				throw new DllNotFoundException(module);

			return Sys_GetFactory(handle);
		}

		public static void Sys_LoadInterface(string moduleName, string interfaceVersionName, IntPtr outModule, IntPtr outInterface)
		{
			//todo?
		}
	}
}
