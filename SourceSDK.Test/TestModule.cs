using GmodNET.API;
using GmodNET.SourceSDK;
using GmodNET.SourceSDK.Tier0;
using GmodNET.SourceSDK.Tier1;
using GmodNET.SourceSDK.vgui;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace SourceSDKTest
{
	public class TestModule : IModule
	{
		public string ModuleName => "SourceSDKTest";

		public string ModuleVersion => "0.0.1";

		private bool failed = false;

		private IntPtr sourcesdkc = IntPtr.Zero;

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

		private static IntPtr GetSystem(string interfaceNoVersionName, string path)
		{
			Console.WriteLine($"GetSystem(): Searching for {interfaceNoVersionName} in {path}");

			CreateInterfaceFn createInterfaceFn = interfaceh.Sys_GetFactory(path);

			for (int i = 99; i >= 0; i--)
			{
				int last = i % 10;
				int middle = i / 10;

				string verString = $"0{middle}{last}";

				if (verString.Length > 3) throw new IndexOutOfRangeException(nameof(verString));

				Console.WriteLine($"GetSystem(): Trying {verString}");

				IntPtr systemPtr = createInterfaceFn(interfaceNoVersionName + verString, out IFACE returnCode);

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
			string platformIdentifier = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "win-x64" : "linux-x64";
			assembly_context.SetCustomNativeLibraryResolver((ctx, str) =>
			{
				if (str.Contains("sourcesdkc"))
				{
					Console.WriteLine("loading sourcesdkc");
					sourcesdkc = NativeLibrary.Load($"./garrysmod/lua/bin/Modules/SourceSDKTest/runtimes/{platformIdentifier}/native/sourcesdkc");
					Console.WriteLine($"loaded sourcesdkc: {sourcesdkc != IntPtr.Zero}");
					return sourcesdkc;
				}
				return IntPtr.Zero;
			});

			Test(() => Dbg.Msg("Msg(string)\n"));

			Test(() => Dbg.Warning("Warning(string)\n"));

			Test(() => Dbg.Warning_SpewCallStack(100, "Warning_SpewCallStack(int, string)\n"));

			Test(() => Dbg.DevMsg("DevMsg(string)\n"));
			Test(() => Dbg.DevWarning("DevWarning(string)\n"));

			Test(() => Dbg.ConColorMsg(new Color(255, 255, 0), "ConColorMsg(in Color, string)\n"));

			Test(() => Dbg.ConMsg("ConMsg(string)\n"));
			Test(() => Dbg.ConDMsg("ConDMsg(string)\n"));

			// Test(() => Dbg.COM_TimestampedLog("COM_TimestampedLog(format = %s)", "COM_TimestampedLog"));

			Test(() =>
			{
				unsafe
				{
					string path = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "filesystem_stdio.dll" : "filesystem_stdio.so";

					if (!interfaceh.Sys_LoadInterface(path, FileSystem.FILESYSTEM_INTERFACE_VERSION, out IntPtr module, out IntPtr fSPtr))
					{
						Console.WriteLine("failed loading FS");
					}
					if (!interfaceh.Sys_LoadInterface(path, BaseFileSystem.BASEFILESYSTEM_INTERFACE_VERSION, out module, out IntPtr baseFSPtr))
					{
						Console.WriteLine("failed loading BFS");
					}

					if (fSPtr == IntPtr.Zero || baseFSPtr == IntPtr.Zero)
					{
						Console.WriteLine("unloading it");
						NativeLibrary.Free(module);
						Console.WriteLine("unloaded ???");
						return;
					}

					FileSystem fileSystem = new(fSPtr);
					BaseFileSystem baseFileSystem = new(baseFSPtr);

					Console.WriteLine("get tier");

					Console.WriteLine(fileSystem.GetTier());

					if (interfaceh.Sys_LoadInterface("vguimatsurface", ISurface.VGUI_SURFACE_INTERFACE_VERSION, out IntPtr isurfaceModule, out IntPtr isurfaceInterface))
					{
						ISurface surface = new(isurfaceInterface);
						Console.WriteLine(surface.GetTier());
					}

					fileSystem.PrintSearchPaths();

					Console.WriteLine("add new path");

					fileSystem.AddSearchPath("garrysmod", "GAME", SearchPathAdd_t.PATH_ADD_TO_HEAD);

					fileSystem.PrintSearchPaths();

					IntPtr fileHandle = baseFileSystem.Open("resource/GameMenu.res", "rb", "GAME");

					if (fileHandle != IntPtr.Zero)
					{
						uint size = baseFileSystem.Size(fileHandle);
						byte[] buff = new byte[size];

						fixed (byte* buffPtr = buff)
						{
							IntPtr buffIntPtr = new(buffPtr);
							baseFileSystem.Read(buffIntPtr, (int)size, fileHandle);
							//byte* bufferResult = (byte*)buffIntPtr.ToPointer();
							Console.WriteLine("Printing file contents");
							Console.WriteLine(Encoding.UTF8.GetChars(buff));
						}
						baseFileSystem.Close(fileHandle);
					}
					else
					{
						Console.WriteLine("not found file");
					}
				}
			});

			assembly_context.SetCustomNativeLibraryResolver(null);

			Debug.Assert(!failed);
		}

		public void Unload(ILua lua)
		{
			if (sourcesdkc != IntPtr.Zero)
			{
				NativeLibrary.Free(sourcesdkc);
			}
		}
	}
}
