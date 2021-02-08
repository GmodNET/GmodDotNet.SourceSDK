using GmodNET.API;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using GmodNET.SourceSDK;
using GmodNET.SourceSDK.Tier0;
using GmodNET.SourceSDK.Tier1;
using System.IO;

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
						path = "filesystem_stdio.so";
					}

					Console.WriteLine("Getting factory");
					CreateInterfaceFn factory = interfaceh.Sys_GetFactory(path);

					Console.WriteLine("factory()");

					IntPtr iFileSystemPtr = factory(FileSystem.FILESYSTEM_INTERFACE_VERSION, out IFACE returnCode);

					Console.WriteLine($"result is {returnCode}");

					if (returnCode == IFACE.OK)
					{
						FileSystem fileSystem = new(iFileSystemPtr);

						Console.WriteLine("PrintSearchPaths");
						fileSystem.PrintSearchPaths();
						Console.WriteLine("IsSteam");
						Console.WriteLine(fileSystem.IsSteam());

						IntPtr fileHandle = fileSystem.Open("materials/brick/brick_model.vmt", "r", "GAME");
						if (fileHandle != IntPtr.Zero)
						{
							uint size = fileSystem.Size(fileHandle);
							MemoryStream ms = new((int)size);
							byte[] buff = ms.GetBuffer();


							fixed(byte* buffPtr = buff)
							{
								IntPtr buffIntPtr = new(buffPtr);
								fileSystem.Read(buffIntPtr, (int)size, fileHandle);
								//byte* bufferResult = (byte*)buffIntPtr.ToPointer();
								Console.WriteLine(ms.ToArray());
							}
						}
						else
						{
							Console.WriteLine("not found vmt");
						}
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
