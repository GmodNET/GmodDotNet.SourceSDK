using GmodNET.API;
using SourceSDK;
using SourceSDK.Tier0;

namespace SourceSDKTest
{
	public class TestModule : IModule
	{
		public string ModuleName => "SourceSDKTest";

		public string ModuleVersion => "0.0.1";

		public void Load(ILua lua, bool is_serverside, ModuleAssemblyLoadContext assembly_context)
		{
			Dbg.ConColorMsg(new Color(255, 255, 0), "ConColorMsg(in Color, string)\n");
			Dbg.ConColorMsg(0, new Color(255, 0, 0), "ConColorMsg(int, in Color, string)\n");
		}

		public void Unload(ILua lua)
		{

		}
	}
}
