using Enumeration.Generator.Tests.TestHelpers;
using PMart.Enumeration.Generator;

namespace Enumeration.Generator.Tests;

public class EnumerationGeneratorTests
{
    [Fact]
    public void EnumerationGenerator_ShouldBeCacheable()
    {
        // Arrange
        var source = TestingSourceBuilder.BuildEnumerationWithPrefixValueFor();

        // Act
        // run the generator, passing in the inputs and the tracking names
        // It includes asserts inside
        var (diagnostics, output)
            = GeneratorOptimizationTester.GetGeneratedTreesAndRunAssertions<EnumerationGenerator>([source],
                [EnumerationGenerator.InitialExtractionTrackingName]);

        // Assert
        Assert.Empty(diagnostics);
        Assert.NotEmpty(output);
    }
}