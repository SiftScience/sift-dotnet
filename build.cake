#l generate.cake

var ARTIFACTS_DIR = "./artifacts/";
var SOLUTION = "./Sift.sln";
var PROJECT = "./Sift/Sift.csproj";

Task("clean")
    .Does(() =>
    {
        CleanDirectories("obj");
        CleanDirectories("bin");
        CleanDirectories("Test/obj");
        CleanDirectories("Test/bin");
        CleanDirectories("artifacts");
    });

Task("restore")
    .Does(() => DotNetCoreRestore(SOLUTION));

Task("build")
    .Does(() => DotNetCoreBuild(SOLUTION));

Task("test")
    .Does(() => DotNetCoreTest("Test/Test.csproj"));

Task("default")
    .IsDependentOn("clean")
    .IsDependentOn("restore")
    .IsDependentOn("generate")
    .IsDependentOn("build")
    .IsDependentOn("test");

Task("pack")
    .IsDependentOn("default")
    .Does(() =>
    {
      var settings = new DotNetCorePackSettings
      {
          OutputDirectory = ARTIFACTS_DIR,
          NoBuild = true,
          NoRestore = true,
          VersionSuffix = "1010"
      };

      DotNetCorePack(PROJECT, settings);
    });

var target = Argument("target", "default");

RunTarget(target);