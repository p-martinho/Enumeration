using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using PMart.Enumeration.Generator;

namespace Enumeration.Generator.Tests.TestHelpers;

internal static class GeneratorDriverBuilder
{
    public static GeneratorDriver Generate(string? source)
    {
        var syntaxTree = source is null ? null : CSharpSyntaxTree.ParseText(source);

        var references = AppDomain
            .CurrentDomain.GetAssemblies()
            .Where(a => !a.IsDynamic && !string.IsNullOrWhiteSpace(a.Location))
            .Select(a => MetadataReference.CreateFromFile(a.Location));

        var compilation = CSharpCompilation.Create(
           assemblyName: "GeneratorTests",
           syntaxTrees: syntaxTree is null ? null : [syntaxTree],
           references: references);

        var generator = new EnumerationGenerator();

        var driver = CSharpGeneratorDriver.Create(generator);

        return driver.RunGenerators(compilation);
    }
}
