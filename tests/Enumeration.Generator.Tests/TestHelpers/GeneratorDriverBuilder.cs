using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using PMart.Enumeration.Generator;
using PMart.Enumeration.Generator.Attributes;

namespace Enumeration.Generator.Tests.TestHelpers;

internal static class GeneratorDriverBuilder
{
    public static GeneratorDriver GenerateDriver(string? source)
    {
        var compilation = BuildCompilation(source is null ? null : [source]);

        var generator = new EnumerationGenerator();

        var driver = CSharpGeneratorDriver.Create(generator);

        return driver.RunGenerators(compilation);
    }

    public static CSharpCompilation BuildCompilation(string[]? sources)
    {
        var syntaxTrees = sources?.Select(static x => CSharpSyntaxTree.ParseText(x));

        var references = AppDomain
            .CurrentDomain.GetAssemblies()
            .Where(a => !a.IsDynamic && !string.IsNullOrWhiteSpace(a.Location))
            .Select(a => MetadataReference.CreateFromFile(a.Location))
            .Concat([
                MetadataReference.CreateFromFile(typeof(EnumerationAttribute).Assembly.Location)
            ]);

        return CSharpCompilation.Create(
            assemblyName: "GeneratorTests",
            syntaxTrees: syntaxTrees,
            references: references);
    }
}