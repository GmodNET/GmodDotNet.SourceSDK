using GmodNET.API;
using SourceSDK;
using SourceSDK.Tier0;
using System;

namespace SourceSDKTest
{
	public class TestModule : IModule
	{
		public string ModuleName => "SourceSDKTest";

		public string ModuleVersion => "0.0.1";

		internal void Test(Action action)
		{
			try
			{
				action();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}

		public void Load(ILua lua, bool is_serverside, ModuleAssemblyLoadContext assembly_context)
		{
			Test(() => Dbg.Msg("Msg(string)\n"));
			Test(() => Dbg.DMsg("group", 0, "DMsg(string, int, string)\n"));

			Test(() => Dbg.Warning("Warning(string)\n"));
			Test(() => Dbg.DWarning("group", 0, "DWarning(string, int, string)\n"));

			Test(() => Dbg.Error("Error(string)\n"));

			Test(() => { Dbg.DevMsg("DevMsg(string)\n"); });
			Test(() => { Dbg.DevWarning("DevWarning(string)\n"); });
			Test(() => { Dbg.DevLog("DevLog(string)\n"); });

			Test(() => Dbg.ConColorMsg(new Color(255, 255, 0), "ConColorMsg(in Color, string)\n"));

			Test(() => { Dbg.ConMsg("ConMsg(string)\n"); });
			Test(() => { Dbg.ConDMsg("ConDMsg(string)\n"); });

			Test(() => { Dbg.COM_TimestampedLog("%s", "COM_TimestampedLog"); });
		}

		public void Unload(ILua lua)
		{

		}
	}
}
