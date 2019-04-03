var Target = Argument("target", "default");
var Configuration = Argument("configuration", "release");

FilePath Solution = null;
var Version = GitVersion();
var NuSpecs = new List<FilePath>();
var Tests = new List<FilePath>();
 
var BuildVerbosity = Verbosity.Minimal;

Task("build")
    .WithCriteria(() => 
    {
        var canBuild = Solution != null && FileExists(Solution);
        
        if(!canBuild)
            Information("Build skipped. To run a build set Solution variable before.");
        
        return canBuild;
    })
    .Does(() =>
    {
        if(IsRunningOnWindows())
            MSBuild(Solution, cfg => 
            {
                cfg.Configuration = Configuration;
                cfg.Verbosity = BuildVerbosity;
            });
        else
            MDToolBuild(Solution, cfg => 
            {
                cfg.Configuration = Configuration;
                cfg.IncreaseVerbosity = BuildVerbosity == Verbosity.Verbose;
            });
    });

Task("clean")
    .Does(() =>
    {
        CleanDirectories("./output");
        CleanDirectories(string.Format("./src/**/obj/{0}", Configuration));
        CleanDirectories(string.Format("./src/**/bin/{0}", Configuration));
        CleanDirectories(string.Format("./tests/**/obj/{0}", Configuration));
        CleanDirectories(string.Format("./tests/**/bin/{0}", Configuration));
    });

Task("default")
    .IsDependentOn("clean")
    .IsDependentOn("restore")
    .IsDependentOn("update-version")    
    .IsDependentOn("build")
    .IsDependentOn("test")
    .IsDependentOn("pack");

Task("pack")
    .WithCriteria(() =>
    {
        var canPack = NuSpecs != null && NuSpecs.Any();
        
        if(!canPack)
        {
            Information("Pack skipped. To run a NuGet pack add some specs to NuSpecs variable.");
            return false;
        }
            
        if(string.Compare(Configuration, "release", StringComparison.OrdinalIgnoreCase) != 0)
            throw new Exception(string.Format("{0} is not allowed since a nuget package has to be compiled with release configuration.", Configuration));

        return true;
    })
    .Does(() =>
    {
        CreateDirectory("./output/artifacts");
        
        NuGetPack(NuSpecs, new NuGetPackSettings
        {
            Version             = Version.NuGetVersion,
            OutputDirectory     = "./output/artifacts"
        } );
    });
    
Task("rebuild")
    .IsDependentOn("clean")
    .IsDependentOn("build");

Task("restore")
    .WithCriteria(() => 
    {
        var canRestore = Solution != null && FileExists(Solution);
        
        if(!canRestore)
            Information("Restore skipped. To restore packages set Solution variable.");
        
        return canRestore;
    })
    .Does(() => NuGetRestore(Solution));
    
Task("test")
    .WithCriteria(() => 
    {
        var canTest = Tests != null && Tests.Any();
        
        if(!canTest)
            Information("Test skipped. To run tests add some dlls to Tests variable.");
        
        return canTest;
    })
    .Does(() => 
    {
        XUnit2(Tests, new XUnit2Settings
        {
            OutputDirectory = "./output/xunit",
            HtmlReport = true,
            Parallelism = ParallelismOption.All
        });
    });