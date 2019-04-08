#addin "nuget:?package=System.CodeDom&version=4.5.0"
#addin "nuget:?package=NJsonSchema&version=9.13.28"
#addin "nuget:?package=NJsonSchema.CodeGeneration&version=9.13.28"
#addin "nuget:?package=NJsonSchema.CodeGeneration.CSharp&version=9.13.28"
#addin "nuget:?package=DotLiquid&version=2.0.254.0"

class SiftPropertyNameGenerator : NJsonSchema.CodeGeneration.IPropertyNameGenerator
{
    public string Generate(NJsonSchema.JsonProperty property)
    {
        return property.Name.Replace("$", string.Empty);
    }
}

class SiftTypeNameGenerator : NJsonSchema.ITypeNameGenerator
{
    public string Generate(NJsonSchema.JsonSchema4 schema, string typeNameHint, IEnumerable<string> reservedTypeNames)
    {
        return ToPascal(typeNameHint);
    }
}

class SiftCSharpGenerator : NJsonSchema.CodeGeneration.CSharp.CSharpGenerator
{
    public SiftCSharpGenerator(object rootObject)
        : base(rootObject)
    {
    }

    public SiftCSharpGenerator(object rootObject, NJsonSchema.CodeGeneration.CSharp.CSharpGeneratorSettings settings)
        : base(rootObject, settings)
    {
    }

    public SiftCSharpGenerator(object rootObject, NJsonSchema.CodeGeneration.CSharp.CSharpGeneratorSettings settings, 
        NJsonSchema.CodeGeneration.CSharp.CSharpTypeResolver resolver) : base(rootObject, settings, resolver)
    {
    }

    protected override string GenerateFile(NJsonSchema.CodeGeneration.CodeArtifactCollection artifactCollection)
    {
        NJsonSchema.CodeGeneration.CodeArtifact[] artifacts = { artifactCollection.Artifacts.Last() };
        return base.GenerateFile(new NJsonSchema.CodeGeneration.CodeArtifactCollection(artifacts, artifactCollection.ExtensionCode));
    }
}

public static string ToPascal(string input)
{
    if (!input.Contains("_"))
    {
        if (!Char.IsUpper(input[0]))
        {
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input);
        }
        return input;
    }
    return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower().Replace("_", " ")).Replace(" ", string.Empty);
}

void Generate(string inputDir, string outputDir, bool isEvent = true) {
    string[] schemaDir = System.IO.Directory.GetFiles(inputDir);

    foreach (string schemaFile in schemaDir) {
        Information(schemaFile);

        var name = ToPascal(System.IO.Path.GetFileNameWithoutExtension(schemaFile));

        var config = new NJsonSchema.CodeGeneration.CSharp.CSharpGeneratorSettings
        {
            Namespace = "Sift",
            ClassStyle = NJsonSchema.CodeGeneration.CSharp.CSharpClassStyle.Poco,
            PropertyNameGenerator = new SiftPropertyNameGenerator(),
            TypeNameGenerator = new SiftTypeNameGenerator()
        };

        var schema = NJsonSchema.JsonSchema4.FromFileAsync(schemaFile).Result;
        var generator = new SiftCSharpGenerator(schema, config);
        var generated = generator.GenerateFile(name);

        var targetUnit = new System.CodeDom.CodeCompileUnit();
        var targetNamespace = new System.CodeDom.CodeNamespace("Sift");
        var targetClass = new System.CodeDom.CodeTypeDeclaration(name);
        targetClass.IsClass = true;
        targetClass.IsPartial = true;
        targetClass.TypeAttributes = System.Reflection.TypeAttributes.Public;
        targetClass.BaseTypes.Add(isEvent ? "SiftEvent" : "SiftEntity");
        targetNamespace.Types.Add(targetClass);
        targetUnit.Namespaces.Add(targetNamespace);
        targetUnit.ToString();

        Microsoft.CSharp.CSharpCodeProvider provider = new Microsoft.CSharp.CSharpCodeProvider();
        System.CodeDom.Compiler.CodeGeneratorOptions options = new System.CodeDom.Compiler.CodeGeneratorOptions { BracingStyle = "C" };

        if (!System.IO.Directory.Exists(outputDir))
        {
            System.IO.Directory.CreateDirectory(outputDir);
        }

        string output = System.IO.Path.Combine(outputDir, name + ".cs");

        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(output, false))
        {
            System.CodeDom.Compiler.IndentedTextWriter tw = new System.CodeDom.Compiler.IndentedTextWriter(sw, "    ");
            provider.GenerateCodeFromCompileUnit(targetUnit, tw, options);
            tw.Write(generated);
            tw.Close();
        }
    }
}
