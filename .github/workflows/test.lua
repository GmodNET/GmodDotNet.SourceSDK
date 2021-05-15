hook.Add("Tick", "CloseServer", engine.CloseServer)
require("dotnet")

local function run_test()
	print("loading")
	local module_loaded = dotnet.load("SourceSDKTest")
	assert(module_loaded)

	-- uhm

	print("unloading")
	local module_unloaded = dotnet.unload("SourceSDKTest")
	assert(module_unloaded)
end

run_test()
print("tests are successful!")
file.Write("success.txt", "done")
