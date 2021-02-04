using GmodNET.API;
using SourceSDK;
using SourceSDK.Tier0;
using System;
using System.Diagnostics;

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

			Test(() => Dbg.Warning_SpewCallStack(100, "Warning_SpewCallStack(int, string)"));

			// Error() kills gmod
			// Test(() => Dbg.Error("Error(string)\n"));

			Test(() => { Dbg.DevMsg("DevMsg(string)\n"); });
			Test(() => { Dbg.DevWarning("DevWarning(string)\n"); });

			Test(() => Dbg.ConColorMsg(new Color(255, 255, 0), "ConColorMsg(in Color, string)\n"));

			Test(() => { Dbg.ConMsg("ConMsg(string)\n"); });
			Test(() => { Dbg.ConDMsg("ConDMsg(string)\n"); });

			Test(() => { Dbg.COM_TimestampedLog("%s", "COM_TimestampedLog"); });

			Debug.Assert(!failed);
		}

		public void Unload(ILua lua)
		{

		}
	}
}
