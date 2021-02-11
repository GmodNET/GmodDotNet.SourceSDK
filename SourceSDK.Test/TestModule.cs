using GmodNET.API;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using GmodNET.SourceSDK;
using GmodNET.SourceSDK.Tier0;
using GmodNET.SourceSDK.Tier1;
using System.IO;
using System.Text;

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

		private delegate IntPtr CreateInterfaceFn(IntPtr name, out IFACE returnCode);
		private static IntPtr GetSystem(string interfaceNoVersionName, string path)
		{
			Console.WriteLine($"GetSystem(): Searching for {interfaceNoVersionName} in {path}");

			CreateInterfaceFn createInterfaceFn = Marshal.GetDelegateForFunctionPointer<CreateInterfaceFn>(NativeLibrary.GetExport(NativeLibrary.Load(path), interfaceh.CREATEINTERFACE_PROCNAME));

			for (int i = 99; i >= 0; i--)
			{
				int last = i % 10;
				int middle = i / 10;

				string verString = $"0{middle}{last}";

				if (verString.Length > 3) throw new IndexOutOfRangeException(nameof(verString));

				Console.WriteLine($"GetSystem(): Trying {verString}");

				IntPtr namePtr = Marshal.StringToHGlobalAnsi(interfaceNoVersionName + verString);

				IntPtr systemPtr = createInterfaceFn(namePtr, out IFACE returnCode);

				Marshal.FreeHGlobal(namePtr);

				if (returnCode == IFACE.OK)
				{
					Console.WriteLine($"GetSystem(): Found {interfaceNoVersionName}{verString}");
					return systemPtr;
				}

			}

			Console.WriteLine($"GetSystem(): Not Found {interfaceNoVersionName}");

			return IntPtr.Zero;
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
					string path = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "filesystem_stdio.dll" : "filesystem_stdio.so";

					IntPtr fsPtr = GetSystem("VFileSystem", path);

					if (fsPtr == IntPtr.Zero) fsPtr = GetSystem("VBaseFileSystem", path);

					if (fsPtr != IntPtr.Zero)
					{
						FileSystem fileSystem = new(fsPtr);

						fileSystem.PrintSearchPaths();

						IntPtr fileHandle = fileSystem.Open("lua/autorun/test.lua", "r", "LUA");

						if (fileHandle != IntPtr.Zero)
						{
							uint size = fileSystem.Size(fileHandle);
							MemoryStream ms = new((int)size);
							byte[] buff = ms.GetBuffer();

							fixed (byte* buffPtr = buff)
							{
								IntPtr buffIntPtr = new(buffPtr);
								fileSystem.Read(buffIntPtr, (int)size, fileHandle);
								//byte* bufferResult = (byte*)buffIntPtr.ToPointer();
								Console.WriteLine("Printing test.lua");
								Console.WriteLine(Encoding.UTF8.GetChars(ms.ToArray()));
							}
						}
						else
						{
							Console.WriteLine("not found file");
						}
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
