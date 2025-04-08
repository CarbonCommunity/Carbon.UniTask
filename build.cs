var version = "2.5.7";
var target = "Release";

SetHome(Path(Home, ".."));

DotNet.ExitOnError(true);
DotNet.Run("restore", PathEnquotes(Home));
DotNet.Run("clean", PathEnquotes(Home), "--configuration", target);
DotNet.Run("build", PathEnquotes(Home), "--configuration", target, "--no-restore", $"/p:Version=\"{version}\"");