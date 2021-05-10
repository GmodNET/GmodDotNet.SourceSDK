using GmodNET.API;
using GmodNET.SourceSDK.materialsystem;
using GmodNET.SourceSDK.Tier1;
using GmodNET.SourceSDK.vgui;
using System;
using System.Runtime.InteropServices;

namespace GetRenderTargetExample
{
	public class GetRenderTargetExampleModule : IModule
	{
		string IModule.ModuleName => "GetRenderTargetExample";

		string IModule.ModuleVersion => "1.0.0";

		private ISurface surface;
		private IMaterialSystem materialSystem;

		private IntPtr sourcesdkc = IntPtr.Zero;

		private IntPtr rt;
		private IntPtr mat;

		void IModule.Load(ILua lua, bool is_serverside, ModuleAssemblyLoadContext assembly_context)
		{
			if (is_serverside) throw new Exception("Must be loaded from client");

			string platformIdentifier = OperatingSystem.IsWindows() ? "win-x64" : "linux-x64";
			assembly_context.SetCustomNativeLibraryResolver((ctx, str) =>
			{
				if (str.Contains("sourcesdkc"))
				{
					if (sourcesdkc == IntPtr.Zero)
					{
						Console.WriteLine("loading sourcesdkc");
						sourcesdkc = NativeLibrary.Load($"./garrysmod/lua/bin/Modules/SourceSDKTest/runtimes/{platformIdentifier}/native/sourcesdkc");
						Console.WriteLine($"loaded sourcesdkc: {sourcesdkc != IntPtr.Zero}");
					}
					return sourcesdkc;
				}
				return IntPtr.Zero;
			});

			if (interfaceh.Sys_LoadInterface("vguimatsurface", ISurface.VGUI_SURFACE_INTERFACE_VERSION, out _, out IntPtr isurfacePtr))
				surface = new(isurfacePtr);
			else
				throw new Exception("failed loading vguimatsurface");

			if (interfaceh.Sys_LoadInterface("materialsystem", IMaterialSystem.MATERIAL_SYSTEM_INTERFACE_VERSION, out _, out IntPtr materialSystemPtr))
				materialSystem = new(materialSystemPtr);
			else
				Console.WriteLine("failed loading materialsystem");

			lua.PushSpecial(SPECIAL_TABLES.SPECIAL_GLOB);
			lua.GetField(-1, "GetRenderTarget");
			lua.PushString("ExampleRTwithAlpha");
			lua.PushNumber(512);
			lua.PushNumber(512);
			lua.MCall(3, 1);
			rt = lua.GetUserType(-1, (int)TYPES.TEXTURE);
			lua.Pop();

			lua.PushSpecial(SPECIAL_TABLES.SPECIAL_GLOB);
			lua.GetField(-1, "CreateMaterial");
			lua.PushString("ExampleRTwithAlpha_Mat");
			lua.PushString("UnlitGeneric");
			lua.CreateTable();
			{
				lua.PushString("$basetexture");
				lua.PushString("ExampleRTwithAlpha");
				lua.SetTable(-4);

				lua.PushString("$translucent");
				lua.PushString("1");
				lua.SetTable(-4);
			}
			lua.MCall(3, 1);
			mat = lua.GetUserType(-1, (int)TYPES.MATERIAL);
			lua.Pop();

			lua.PushSpecial(SPECIAL_TABLES.SPECIAL_GLOB);
			lua.GetField(-1, "hook");
			lua.GetField(-1, "Add");
			lua.PushString("HUDPaint");
			lua.PushString("ExampleRTwithAlpha_Render");
			lua.PushManagedFunction(Render);
			lua.MCall(3, 0);
			lua.Pop();
		}

		public int Render(ILua lua)
		{
			//render.PushRenderTarget(textureRT)
			//cam.Start2D()
			// render.Clear(0, 0, 0, 0)

			lua.PushSpecial(SPECIAL_TABLES.SPECIAL_GLOB);
			lua.GetField(-1, "CurTime");
			lua.MCall(0, 1);
			int CurTime = (int)lua.GetNumber(1);
			lua.Pop();

			// PushRenderTarget
			{
				lua.PushSpecial(SPECIAL_TABLES.SPECIAL_GLOB);
				lua.GetField(-1, "render");
				lua.GetField(-1, "PushRenderTarget");
				lua.PushUserType(rt, (int)TYPES.TEXTURE);
				lua.MCall(1, 0);
				lua.Pop();
			}

			// Start 2D
			{
				lua.PushSpecial(SPECIAL_TABLES.SPECIAL_GLOB);
				lua.GetField(-1, "cam");
				lua.GetField(-1, "Start2D");
				lua.MCall(0, 0);
				lua.Pop();
			}

			// Clear
			{
				lua.PushSpecial(SPECIAL_TABLES.SPECIAL_GLOB);
				lua.GetField(-1, "render");
				lua.GetField(-1, "Clear");
				lua.PushNumber(0);
				lua.PushNumber(0);
				lua.PushNumber(0);
				lua.PushNumber(0);
				lua.MCall(4, 0);
				lua.Pop();
			}
			// Draw Rects
			{
				if (surface is not null)
				{
					surface.DrawSetColor(255, 255, 255, 255);
					surface.DrawFilledRect(20, (100 + (((int)Math.Sin(CurTime)) * 50)), 50, 50);
					surface.DrawSetColor(255, 0, 0, 100);
					surface.DrawFilledRect(120, (100 + (((int)Math.Sin(CurTime)) * 50)), 50, 50);
				}
				else
				{
					lua.PushSpecial(SPECIAL_TABLES.SPECIAL_GLOB);
					lua.GetField(-1, "surface");
					lua.GetField(-1, "SetDrawColor");
					lua.PushNumber(255);
					lua.PushNumber(255);
					lua.PushNumber(255);
					lua.PushNumber(255);
					lua.MCall(4, 0);
					lua.Pop(2);

					lua.PushSpecial(SPECIAL_TABLES.SPECIAL_GLOB);
					lua.GetField(-1, "surface");
					lua.GetField(-1, "DrawRect");
					lua.PushNumber(20);
					lua.PushNumber((100 + (((int)Math.Sin(CurTime)) * 50)));
					lua.PushNumber(50);
					lua.PushNumber(50);
					lua.MCall(4, 0);
					lua.Pop(2);

					lua.PushSpecial(SPECIAL_TABLES.SPECIAL_GLOB);
					lua.GetField(-1, "surface");
					lua.GetField(-1, "SetDrawColor");
					lua.PushNumber(255);
					lua.PushNumber(0);
					lua.PushNumber(0);
					lua.PushNumber(100);
					lua.MCall(4, 0);
					lua.Pop(2);

					lua.PushSpecial(SPECIAL_TABLES.SPECIAL_GLOB);
					lua.GetField(-1, "surface");
					lua.GetField(-1, "DrawRect");
					lua.PushNumber(120);
					lua.PushNumber((100 + (((int)Math.Sin(CurTime)) * 50)));
					lua.PushNumber(50);
					lua.PushNumber(50);
					lua.MCall(4, 0);
					lua.Pop(2);
				}
			}

			// End2D
			{
				lua.PushSpecial(SPECIAL_TABLES.SPECIAL_GLOB);
				lua.GetField(-1, "cam");
				lua.GetField(-1, "End2D");
				lua.MCall(0, 0);
				lua.Pop();
			}

			// Pop
			{
				lua.PushSpecial(SPECIAL_TABLES.SPECIAL_GLOB);
				lua.GetField(-1, "render");
				lua.GetField(-1, "PopRenderTarget");
				lua.MCall(0, 0);
				lua.Pop();
			}

			// Draw it on screen
			{
				if(surface is not null)
				{
					surface.DrawSetColor(255, 255, 255, 255);
				}
				else
				{
					lua.PushSpecial(SPECIAL_TABLES.SPECIAL_GLOB);
					lua.GetField(-1, "surface");
					lua.GetField(-1, "SetDrawColor");
					lua.PushNumber(255);
					lua.PushNumber(255);
					lua.PushNumber(255);
					lua.PushNumber(255);
					lua.MCall(4, 0);
					lua.Pop();
				}

				lua.PushSpecial(SPECIAL_TABLES.SPECIAL_GLOB);
				lua.GetField(-1, "surface");
				lua.GetField(-1, "SetMaterial");
				lua.PushUserType(mat, (int)TYPES.MATERIAL);
				lua.MCall(1, 0);
				lua.Pop();

				lua.PushSpecial(SPECIAL_TABLES.SPECIAL_GLOB);
				lua.GetField(-1, "surface");
				lua.GetField(-1, "DrawTexturedRect");
				lua.PushNumber(50);
				lua.PushNumber(50);
				lua.PushNumber(512);
				lua.PushNumber(512);
				lua.MCall(4, 0);
				lua.Pop();
			}

			return 0;
		}

		void IModule.Unload(ILua lua)
		{
			surface = null;
			materialSystem = null;

			if (sourcesdkc != IntPtr.Zero)
				NativeLibrary.Free(sourcesdkc);
		}
	}
}
