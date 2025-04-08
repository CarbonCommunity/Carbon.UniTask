var key = GetArg(1);
var version = GetArg(2);

Warn($"Key: {key.Length}");
Warn($"Version: {version}");

DotNet.SetQuiet(true);
DotNet.Run("nuget", "push", PathEnquotes(Home, "Carbon.Core", ".nugets", $"Carbon.UniTask.{version}.nupkg"),
	"--api-key", key, "--source", "https://api.nuget.org/v3/index.json");
