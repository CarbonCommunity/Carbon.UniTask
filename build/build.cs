var target = GetArg(1, "Debug");
var version = GetVariable("VERSION") ?? "1.0.0";

SetHome(Path(Home, ".."));

DotNet.ExitOnError(true);
DotNet.Run("restore", PathEnquotes(Home));
DotNet.Run("clean", PathEnquotes(Home), "--configuration", target);
DotNet.Run("build", PathEnquotes(Home), "--configuration", target, "--no-restore", $"/p:Version=\"{version}\"");