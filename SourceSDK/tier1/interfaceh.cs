using System;
using System.Diagnostics.CodeAnalysis;
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
			if (module == IntPtr.Zero)
				throw new ArgumentNullException(nameof(module));

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

			CreateInterfaceFn factory = null;
			Exception exception = null;

			try
			{
				factory = Sys_GetFactory(handle);
			}
			catch (Exception e)
			{
				exception = e;
			}

			if (exception is not null) throw exception;
			return factory;
		}

		/// <summary>
		/// loads module
		/// </summary>
		/// <param name="moduleName">Module name</param>
		/// <returns></returns>
		/// <remarks>uses NativeLibrary.Load</remarks>
		/// <seealso cref="Sys_UnloadModule(IntPtr)"/>
		public static IntPtr Sys_LoadModule(string moduleName)
		{
			return NativeLibrary.Load(moduleName);
		}

		/// <summary>
		/// unloads module
		/// </summary>
		/// <param name="module">module handle</param>
		/// <remarks>uses NativeLibrary.Free</remarks>
		/// <seealso cref="Sys_LoadModule(string)"/>
		public static void Sys_UnloadModule(IntPtr module)
		{
			NativeLibrary.Free(module);
		}

		/// <summary>
		/// get interface
		/// </summary>
		/// <param name="moduleName">module name</param>
		/// <param name="interfaceVersionName">interface version</param>
		/// <param name="outModule">loaded module handle</param>
		/// <param name="outInterface">loaded module's interface</param>
		/// <returns>successful</returns>
		/// <seealso cref="Sys_GetFactory(string)"/>
		/// <seealso cref="Sys_GetFactory(IntPtr)"/>
		public static bool Sys_LoadInterface(string moduleName, string interfaceVersionName, out IntPtr outModule, out IntPtr outInterface)
		{
			Console.WriteLine("Sys_LoadModule");
			outModule = Sys_LoadModule(moduleName);
			outInterface = IntPtr.Zero;

			if (outModule == IntPtr.Zero) return false;

			CreateInterfaceFn factory;

			try
			{
				Console.WriteLine("Sys_GetFactory");
				factory = Sys_GetFactory(outModule);
			}
			catch (EntryPointNotFoundException)
			{
				Console.WriteLine("Sys_UnloadModule");
				Sys_UnloadModule(outModule);
				return false;
			}

			Console.WriteLine("factory()");
			outInterface = factory(interfaceVersionName, out IFACE returnCode);

			if (returnCode != IFACE.OK || outInterface == IntPtr.Zero)
			{
				Console.WriteLine("Sys_UnloadModule");
				Sys_UnloadModule(outModule);
				return false;
			}

			return true;
		}
	}
}
