#l generate.cake

Task("clean")
    .Does(() =>
    {
        CleanDirectories("obj");
        CleanDirectories("bin");
        CleanDirectories("Test/obj");
        CleanDirectories("Test/bin");
    });

Task("restore")
    .Does(() => DotNetCoreRestore("Sift.sln"));

Task("build")
    .Does(() => MSBuild("Sift.sln"));

Task("test")
    .Does(() => DotNetCoreTest("Test/Test.csproj"));

Task("default")
    .IsDependentOn("clean")
    .IsDependentOn("restore")
    .IsDependentOn("generate")
    .IsDependentOn("build")
    .IsDependentOn("test");

var target = Argument("target", "default");

RunTarget(target);