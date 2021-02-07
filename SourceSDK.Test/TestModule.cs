using GmodNET.API;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using GmodNET.SourceSDK;
using GmodNET.SourceSDK.Tier0;
using GmodNET.SourceSDK.Tier1;

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

		public void Load(ILua lua, bool is_serverside, ModuleAssemblyLoadContext assembly_context)
		{
			Test(() => Dbg.Msg("Msg(string)\n"));

			Test(() => Dbg.Warning("Warning(string)\n"));

			Test(() => Dbg.Warning_SpewCallStack(100, "Warning_SpewCallStack(int, string)\n"));

			Test(() => Dbg.DevMsg("DevMsg(string)\n"));
			Test(() => Dbg.DevWarning("DevWarning(string)\n"));

			Test(() => Dbg.ConColorMsg(new Color(255, 255, 0), "ConColorMsg(in Color, string)\n"));

			Test(() => Dbg.ConMsg("ConMsg(string)\n"));
			Test(() => Dbg.ConDMsg("ConDMsg(string)\n"));

			Test(() => Dbg.COM_TimestampedLog("%s", "COM_TimestampedLog"));

			Test(() =>
			{
				unsafe
				{
					string path;
					if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
					{
						path = "filesystem_stdio.dll";
					}
					else
					{
						path = "filesystem_stdio";
					}

					Console.WriteLine("Getting factory");
					interfaceh.CreateInterfaceFn factory = interfaceh.Sys_GetFactory(path);

					Console.WriteLine("factory()");

					IntPtr interfaceNamePointer = Marshal.StringToHGlobalAnsi("VFileSystem022");
					IntPtr iFileSystemPtr = factory(interfaceNamePointer, out interfaceh.IFACE returnCode);
					Marshal.FreeHGlobal(interfaceNamePointer);

					Console.WriteLine($"result is {returnCode}");

					if (returnCode == interfaceh.IFACE.OK)
					{
						IFileSystem fileSystem = new(iFileSystemPtr);

						Console.WriteLine("PrintSearchPaths");
						fileSystem.PrintSearchPaths();
						Console.WriteLine("IsSteam");
						Console.WriteLine(fileSystem.IsSteam());
					}
					else throw new EntryPointNotFoundException();
				}
			});

			Debug.Assert(!failed);
		}

		public void Unload(ILua lua)
		{

		}
	}
}
