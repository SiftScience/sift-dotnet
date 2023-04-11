#l generate.cake

var ARTIFACTS_DIR = "./artifacts/";

var target = Argument("target", "default");
var configuration = Argument("configuration", "Release");

var solutionFile = "./Sift.sln";
var sift = "./Sift/Sift.csproj";
var testProjects = new string[] {
    "./Sift.Test.Framework4.8/Sift.Test.Framework4.8.csproj",
    "./Sift.Test.Core2.1/Sift.Test.Core2.1.csproj",
    "./Sift.Test.Core3.1/Sift.Test.Core3.1.csproj",
    "./Sift.Test.Net6/Sift.Test.Net6.csproj"
};

Task("clean")
    .Does(() =>
    {
        CleanDirectories("Sift/obj");
        CleanDirectories("Sift/bin");
        CleanDirectories("Sift/Event");
        CleanDirectories("Sift.Test.Core2.1/obj");
        CleanDirectories("Sift.Test.Core2.1/bin");
        CleanDirectories("Sift.Test.Core3.1/obj");
        CleanDirectories("Sift.Test.Core3.1/bin");
        CleanDirectories("Sift.Test.Net6/obj");
        CleanDirectories("Sift.Test.Net6/bin");
        CleanDirectories("Sift.Test.Framework4.8/obj");
        CleanDirectories("Sift.Test.Framework4.8/bin");
        CleanDirectories("artifacts");
    });

Task("restore")
.Does(() => {
    var nugetSourceList = new List<string> { "https://api.nuget.org/v3/index.json" };

    NuGetRestore(solutionFile, new NuGetRestoreSettings {
        Source = nugetSourceList
    });
});

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
    .IsDependentOn("restore")
    .Does(() =>
{
    var dotnetCoreProjects = new string[] {
        "./Sift/Sift.csproj",
        "./Sift.Test.Core2.1/Sift.Test.Core2.1.csproj",
        "./Sift.Test.Core3.1/Sift.Test.Core3.1.csproj",
        "./Sift.Test.Net6/Sift.Test.Net6.csproj"
    };

    foreach (var project in dotnetCoreProjects)
    {
        DotNetCoreBuild(project, new DotNetCoreBuildSettings
        {
            Configuration = configuration,
            NoRestore = true
        });
    }

    var dotNetFramework4_8TestProject = "./Sift.Test.Framework4.8/Sift.Test.Framework4.8.csproj";

    MSBuild(dotNetFramework4_8TestProject, new MSBuildSettings
    {
        Configuration = configuration,
        PlatformTarget = PlatformTarget.MSIL,
        Verbosity = Verbosity.Minimal,
        MSBuildPlatform = MSBuildPlatform.Automatic,
        ToolVersion = MSBuildToolVersion.VS2017,
        ToolPath = EnvironmentVariable("MSBUILD_TOOL_PATH") ?? "C:/Program Files (x86)/Microsoft Visual Studio/2019/Community/MSBuild/Current/Bin/MSBuild.exe"
    });
});

Task("test")
    .IsDependentOn("build")
    .DoesForEach(testProjects, (project) =>
{
    var testAdapterPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(solutionFile), "packages");
    if (project.Contains("Sift.Test.Framework4.8.csproj"))
    {
        var testAssembly = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(project), "bin", configuration, "Sift.Test.Framework4.8.dll");

        VSTest(testAssembly, new VSTestSettings
        {
            ToolPath = EnvironmentVariable("VSTEST_TOOL_PATH") ?? "C:\\Program Files (x86)\\Microsoft Visual Studio\\2019\\Community\\Common7\\IDE\\CommonExtensions\\Microsoft\\TestWindow\\vstest.console.exe",
            TestAdapterPath = testAdapterPath,
             ArgumentCustomization = args => args.Append("/logger:trx")
        });
    }
    else
    {
        DotNetCoreTest(project, new DotNetCoreTestSettings
        {
            Configuration = configuration,
            NoBuild = true,
            TestAdapterPath = testAdapterPath
        });
    }
});

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
            Configuration = configuration,
            OutputDirectory = ARTIFACTS_DIR,
            NoBuild = true,
            NoRestore = true
        };

        DotNetCorePack(sift, settings);
    });

RunTarget(target);
