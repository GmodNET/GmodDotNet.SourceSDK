using GmodNET.API;
using SourceSDK;
using SourceSDK.Tier0;
using SourceSDK.Tier1;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SourceSDKTest
{
	public class TestModule : IModule
	{
		public string ModuleName => "SourceSDKTest";

		public string ModuleVersion => "0.0.1";

		private bool failed = false;
		internal void Test(Action action)
		{
			try
			{
				action();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				failed = true;
			}
		}

		struct CSysModule
		{
			public IntPtr ptr;
		}

		public void Load(ILua lua, bool is_serverside, ModuleAssemblyLoadContext assembly_context)
		{
			Test(() => Dbg.Msg("Msg(string)\n"));

			Test(() => Dbg.Warning("Warning(string)\n"));

			Test(() => Dbg.Warning_SpewCallStack(100, "Warning_SpewCallStack(int, string)"));

			// Error() kills gmod
			// Test(() => Dbg.Error("Error(string)\n"));

			Test(() => { Dbg.DevMsg("DevMsg(string)\n"); });
			Test(() => { Dbg.DevWarning("DevWarning(string)\n"); });

			Test(() => Dbg.ConColorMsg(new Color(255, 255, 0), "ConColorMsg(in Color, string)\n"));

			Test(() => { Dbg.ConMsg("ConMsg(string)\n"); });
			Test(() => { Dbg.ConDMsg("ConDMsg(string)\n"); });

			Test(() => { Dbg.COM_TimestampedLog("%s", "COM_TimestampedLog"); });

			Test(() =>
			{
				string path;
				if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
				{
					path = "filesystem_stdio.dll";
				}
				else
				{
					path = "filesystem_stdio.so";
				}

				Console.WriteLine("Getting lib handle");
				IntPtr handle = NativeLibrary.Load(path);
				Console.WriteLine(handle);

				Console.WriteLine("Getting factory");
				IntPtr createInterfaceFnPtr = NativeLibrary.GetExport(handle, interfaceh.CREATEINTERFACE_PROCNAME);
				interfaceh.CreateInterfaceFn factory = interfaceh.Sys_GetFactory(handle);

				Console.WriteLine("Creating");
				IntPtr resultPtr = new IntPtr(0);
				IntPtr factoryResult = factory(Marshal.StringToHGlobalAnsi("VFileSystem022"), resultPtr);
				Console.WriteLine($"factoryResult = {factoryResult}\nresult = {resultPtr}");
				Debug.Assert(resultPtr == IntPtr.Zero);

				Console.WriteLine("Marshal.PtrToStructure<CSysModule>");
				CSysModule cSysModule = Marshal.PtrToStructure<CSysModule>(factoryResult);

				Console.WriteLine($"cSysModule = {cSysModule}\ncSysModule.ptr = {cSysModule.ptr}");

				Console.WriteLine("Marshal.PtrToStructure");
				IFileSystem fsys = Marshal.PtrToStructure<IFileSystem>(cSysModule.ptr);

				Console.WriteLine("fsys.IsSteam()");
				Console.WriteLine(fsys.IsSteam());
			});

			Debug.Assert(!failed);
		}

		public void Unload(ILua lua)
		{

		}
	}
}
