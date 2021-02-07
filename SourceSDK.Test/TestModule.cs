using GmodNET.API;
using SourceSDK;
using SourceSDK.Tier0;
using SourceSDK.Tier1;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
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

		public unsafe struct IFileSystem1
		{
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			public delegate bool _IsSteam();

			public unsafe IntPtr* lpVtbl;
			//public extern bool IsSteam();
			public bool IsSteam()
			{
				IntPtr isSteamPtr = lpVtbl[22];
				if (isSteamPtr == IntPtr.Zero) throw new Exception("isSteamPtr");
				Console.WriteLine("getting delegate");
				_IsSteam isSteam = Marshal.GetDelegateForFunctionPointer<_IsSteam>(isSteamPtr);
				Console.WriteLine("isSteam");
				bool isSteamResult = isSteam();
				Console.WriteLine("return");
				return isSteamResult;
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
						path = "bin/linux64/filesystem_stdio.so";
					}

					Console.WriteLine("Getting lib handle");
					IntPtr handle = NativeLibrary.Load(path);
					Console.WriteLine(handle);
					if (handle == IntPtr.Zero) throw new DllNotFoundException();

					Console.WriteLine("Getting factory");
					interfaceh.CreateInterfaceFn factory = interfaceh.Sys_GetFactory(path);

					Console.WriteLine("Creating");

					IntPtr interfaceNamePointer = Marshal.StringToHGlobalAnsi("VFileSystem022");
					IntPtr* factoryResult = factory(interfaceNamePointer, out interfaceh.IFACE returnCode);
					Marshal.FreeHGlobal(interfaceNamePointer);

					Console.WriteLine($"result is {returnCode}");

					if (returnCode == interfaceh.IFACE.OK)
					{
						try
						{
							Console.WriteLine("PtrToStructure");
							IFileSystem1 fileSystem = Marshal.PtrToStructure<IFileSystem1>((IntPtr)factoryResult);
							Console.WriteLine("fileSystem.IsSteam");
							Console.WriteLine(fileSystem.IsSteam());
							Console.WriteLine("done");
						}
						catch (Exception e)
						{
							Console.WriteLine(e);
							try
							{
								IFileSystem1 fileSystem = new IFileSystem1() { lpVtbl = factoryResult };
								Console.WriteLine(fileSystem.IsSteam());
							}
							catch (Exception e2)
							{
								Console.WriteLine("SECOND EXCEPTION:");
								Console.WriteLine(e2);
							}
						}
					}
					else
					{
						Console.WriteLine("failed getting interface");
					}
				}
			});

			Debug.Assert(!failed);
		}

		public void Unload(ILua lua)
		{

		}
	}
}
