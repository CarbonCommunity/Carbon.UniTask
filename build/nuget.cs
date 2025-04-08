var key = GetArg(1);
var target = GetArg(2, "Debug");
var version = GetVariable("VERSION");

Warn($"Key: {key.Length}");
Warn($"Version: {version}");
Warn($"Target: {target}");

SetHome(Path(Home, ".."));

DotNet.SetQuiet(true);
DotNet.Run("nuget", "push", PathEnquotes(Home, "src", "UniTask.NetCore", "bin", target, $"Carbon.UniTask.{version}.nupkg"),
	"--api-key", key, "--source", "https://api.nuget.org/v3/index.json");
