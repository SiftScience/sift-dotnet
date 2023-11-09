#l generate.cake

var ARTIFACTS_DIR = "./artifacts/";
var SOLUTION = "./Sift.sln";
var SIFT = "./Sift/Sift.csproj";
var TEST = "./Test/Test.csproj";
var TEST_NET7 = "./Test.Integration.Net7/Test.Integration.Net7.csproj";

Task("clean")
    .Does(() =>
    {
        CleanDirectories("Sift/obj");
        CleanDirectories("Sift/bin");
        CleanDirectories("Sift/Event");
        CleanDirectories("Test/obj");
        CleanDirectories("Test/bin");
        CleanDirectories("artifacts");
    });

Task("restore")
    .Does(() => DotNetCoreRestore(SOLUTION));

Task("generate")
    .IsDependentOn("clean")
    .IsDependentOn("restore")
    .Does(() =>
    {
      Information("Generating schemas...");
      Generate("Sift/Schema/ComplexTypes", "Sift/Event", false);
      Generate("Sift/Schema", "Sift/Event", true);
    });

Task("build")
    .Does(() => DotNetCoreBuild(SOLUTION));

Task("test")
    .Does(() => DotNetCoreTest(TEST));

Task("testNet7")
    .Does(() => DotNetCoreTest(TEST_NET7));

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
          NoRestore = true
      };

      DotNetCorePack(SIFT, settings);
    });

var target = Argument("target", "default");

RunTarget(target);
