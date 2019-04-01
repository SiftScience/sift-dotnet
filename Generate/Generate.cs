using System.IO;
using System.Threading.Tasks;
using NJsonSchema;
using NJsonSchema.CodeGeneration.CSharp;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Reflection;
using Microsoft.CSharp;
using System.Globalization;
using NJsonSchema.CodeGeneration;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Sift
{
    class Generate
    {
        class SiftPropertyNameGenerator : IPropertyNameGenerator
        {
            public string Generate(JsonProperty property)
            {
                return property.Name.Replace("$", string.Empty);
            }
        }

        class SiftTypeNameGenerator : ITypeNameGenerator
        {
            public string Generate(JsonSchema4 schema, string typeNameHint, IEnumerable<string> reservedTypeNames)
            {
                return ToPascal(typeNameHint);
            }
        }

        class SiftCSharpGenerator : CSharpGenerator
        {
            public SiftCSharpGenerator(object rootObject)
                : base(rootObject)
            {
            }

            public SiftCSharpGenerator(object rootObject, CSharpGeneratorSettings settings)
                : base(rootObject, settings)
            {
            }

            public SiftCSharpGenerator(object rootObject, CSharpGeneratorSettings settings, CSharpTypeResolver resolver)
                : base(rootObject, settings, resolver)
            {
            }

            protected override string GenerateFile(CodeArtifactCollection artifactCollection)
            {
                CodeArtifact[] artifacts = { artifactCollection.Artifacts.Last() };
                return base.GenerateFile(new CodeArtifactCollection(artifacts, artifactCollection.ExtensionCode));
            }
        }

        public static string ToPascal(string input)
        {
            if (!input.Contains("_"))
            {
                if (!Char.IsUpper(input[0]))
                {
                    return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input);   
                }
                return input;
            }
            return CultureInfo.CurrentCulture.TextInfo
                              .ToTitleCase(input.ToLower().Replace("_", " "))
                              .Replace(" ", string.Empty);
        }

        static async Task Main(string[] args)
        {
            await GenerateSchemas("Schema/ComplexTypes", false);
            await GenerateSchemas("Schema");
        }

        static async Task GenerateSchemas(string root, bool isEvent = true)
        {
            string[] schemaDir = Directory.GetFiles(root);
            foreach (string schemaFile in schemaDir)
            {
                var name = ToPascal(Path.GetFileNameWithoutExtension(schemaFile));

                var config = new CSharpGeneratorSettings 
                { 
                    Namespace = "Sift", 
                    ClassStyle = CSharpClassStyle.Poco, 
                    PropertyNameGenerator = new SiftPropertyNameGenerator(),
                    TypeNameGenerator = new SiftTypeNameGenerator()
                };
                var schema = await JsonSchema4.FromFileAsync(schemaFile);
                var generator = new SiftCSharpGenerator(schema, config);
                var generated = generator.GenerateFile(name);

                var targetUnit = new CodeCompileUnit();
                var targetNamespace = new CodeNamespace("Sift");
                var targetClass = new CodeTypeDeclaration(name);
                targetClass.IsClass = true;
                targetClass.IsPartial = true;
                targetClass.TypeAttributes = TypeAttributes.Public;
                targetClass.BaseTypes.Add(isEvent ? "SiftEvent" : "SiftEntity");
                targetNamespace.Types.Add(targetClass);
                targetUnit.Namespaces.Add(targetNamespace);
                targetUnit.ToString();

                CSharpCodeProvider provider = new CSharpCodeProvider();
                CodeGeneratorOptions options = new CodeGeneratorOptions { BracingStyle = "C" };

                if (!Directory.Exists("Event")) {
                    Directory.CreateDirectory("Event");   
                }

                string output = Path.Combine("Event", name + ".cs");

                using (StreamWriter sw = new StreamWriter(output, false))
                {
                    IndentedTextWriter tw = new IndentedTextWriter(sw, "    ");
                    provider.GenerateCodeFromCompileUnit(targetUnit, tw, options);
                    tw.Write(generated);
                    tw.Close();
                }
            }
        }
    }
}
