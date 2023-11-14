using Enumeration.Mappers.Tests.EnumerationClasses;
using Enumeration.Mappers.Tests.ThirdPartyMappers.Models;
using Xunit;

namespace Enumeration.Mappers.Tests.ThirdPartyMappers.Mapperly;

public class MapperlyMappingTests
{
    private readonly Mappers.EnumerationModelMapper _enumerationMapper = new();
    private readonly Mappers.EnumerationDynamicModelMapper _enumerationDynamicMapper = new();
    private readonly Mappers.EnumerationNullableModelMapper _enumerationNullableMapper = new();
    private readonly Mappers.EnumerationDynamicNullableModelMapper _enumerationDynamicNullableMapper = new();

    [Fact]
    public void Map_WithNotDynamicEnumeration_ShouldSucceed()
    {
        // Arrange
        var sourceModel = new EnumerationSourceModel
        {
            TestEnumToEnumProperty = TestEnumeration.CodeA,
            TestEnumToStringProperty = TestEnumeration.CodeA,
            TestStringToEnumProperty = TestEnumeration.CodeA.Value,
            TestEnumToDifferentEnumProperty = TestEnumeration.CodeA
        };

        // Act
        var result = _enumerationMapper.SourceToDestination(sourceModel);

        // Assert
        Assert.Equal(TestEnumeration.CodeA, result.TestEnumToEnumProperty);
        Assert.Equal(TestEnumeration.CodeA.Value, result.TestEnumToStringProperty);
        Assert.Equal(TestEnumeration.CodeA, result.TestStringToEnumProperty);
        Assert.Equal(TestDifferentEnumeration.CodeA, result.TestEnumToDifferentEnumProperty);
    }

    [Fact]
    public void Map_WithDynamicEnumeration_ShouldSucceed()
    {
        // Arrange
        var sourceModel = new EnumerationDynamicSourceModel
        {
            TestEnumDynamicToEnumDynamicProperty = TestEnumerationDynamic.CodeA,
            TestEnumDynamicToStringProperty = TestEnumerationDynamic.CodeA,
            TestStringToEnumDynamicProperty = TestEnumerationDynamic.CodeA.Value,
            TestEnumDynamicToDifferentEnumDynamicProperty = TestEnumerationDynamic.CodeA
        };

        // Act
        var result = _enumerationDynamicMapper.SourceToDestination(sourceModel);

        // Assert
        Assert.Equal(TestEnumerationDynamic.CodeA, result.TestEnumDynamicToEnumDynamicProperty);
        Assert.Equal(TestEnumerationDynamic.CodeA.Value, result.TestEnumDynamicToStringProperty);
        Assert.Equal(TestEnumerationDynamic.CodeA, result.TestStringToEnumDynamicProperty);
        Assert.Equal(TestDifferentEnumerationDynamic.CodeA, result.TestEnumDynamicToDifferentEnumDynamicProperty);
    }

    [Fact]
    public void Map_WithNotDynamicEnumeration_AndWithNullableProperties_ShouldSucceed()
    {
        // Arrange
        var sourceModel = new EnumerationNullableSourceModel
        {
            TestEnumToNullableEnumProperty = TestEnumeration.CodeA,
            TestEnumToNullableStringProperty = TestEnumeration.CodeA,
            TestStringToNullableEnumProperty = TestEnumeration.CodeA.Value,
            TestEnumToDifferentNullableEnumProperty = TestEnumeration.CodeA,
            TestNullableEnumToEnumProperty = TestEnumeration.CodeA,
            TestNullableEnumToStringProperty = TestEnumeration.CodeA,
            TestNullableStringToEnumProperty = TestEnumeration.CodeA.Value,
            TestNullableEnumToDifferentEnumProperty = TestDifferentEnumeration.CodeA,
            TestNullableEnumToNullableEnumProperty = TestEnumeration.CodeA,
            TestNullableEnumToNullableStringProperty = TestEnumeration.CodeA,
            TestNullableStringToNullableEnumProperty = TestEnumeration.CodeA.Value,
            TestNullableEnumToDifferentNullableEnumProperty = TestDifferentEnumeration.CodeA
        };

        // Act
        var result = _enumerationNullableMapper.SourceToDestination(sourceModel);

        // Assert
        Assert.Equal(TestEnumeration.CodeA, result.TestEnumToNullableEnumProperty);
        Assert.Equal(TestEnumeration.CodeA.Value, result.TestEnumToNullableStringProperty);
        Assert.Equal(TestEnumeration.CodeA, result.TestStringToNullableEnumProperty);
        Assert.Equal(TestDifferentEnumeration.CodeA, result.TestEnumToDifferentNullableEnumProperty);
        Assert.Equal(TestEnumeration.CodeA, result.TestNullableEnumToEnumProperty);
        Assert.Equal(TestEnumeration.CodeA.Value, result.TestNullableEnumToStringProperty);
        Assert.Equal(TestEnumeration.CodeA, result.TestNullableStringToEnumProperty);
        Assert.Equal(TestDifferentEnumeration.CodeA, result.TestNullableEnumToDifferentEnumProperty);
        Assert.Equal(TestEnumeration.CodeA, result.TestNullableEnumToNullableEnumProperty);
        Assert.Equal(TestEnumeration.CodeA.Value, result.TestNullableEnumToNullableStringProperty);
        Assert.Equal(TestEnumeration.CodeA, result.TestNullableStringToNullableEnumProperty);
        Assert.Equal(TestDifferentEnumeration.CodeA, result.TestNullableEnumToDifferentNullableEnumProperty);
    }

    [Fact]
    public void Map_WithNotDynamicEnumeration_AndWithNullableProperties_AndWithNulls_ShouldSucceed()
    {
        // Arrange
        var sourceModel = new EnumerationNullableSourceModel
        {
            TestEnumToNullableEnumProperty = null!,
            TestEnumToNullableStringProperty = null!,
            TestStringToNullableEnumProperty = null!,
            TestEnumToDifferentNullableEnumProperty = null!,
            TestNullableEnumToEnumProperty = null,
            TestNullableEnumToStringProperty = null,
            TestNullableStringToEnumProperty = null,
            TestNullableEnumToDifferentEnumProperty = null,
            TestNullableEnumToNullableEnumProperty = null,
            TestNullableEnumToNullableStringProperty = null,
            TestNullableStringToNullableEnumProperty = null,
            TestNullableEnumToDifferentNullableEnumProperty = null
        };

        // Act
        var result = _enumerationNullableMapper.SourceToDestination(sourceModel);

        // Assert
        Assert.Null(result.TestNullableEnumToEnumProperty);
        Assert.Null(result.TestNullableEnumToStringProperty);
        Assert.Null(result.TestNullableStringToEnumProperty);
        Assert.Null(result.TestNullableEnumToDifferentEnumProperty);
        Assert.Null(result.TestEnumToNullableEnumProperty);
        Assert.Null(result.TestEnumToNullableStringProperty);
        Assert.Null(result.TestStringToNullableEnumProperty);
        Assert.Null(result.TestEnumToDifferentNullableEnumProperty);
        Assert.Null(result.TestNullableEnumToNullableEnumProperty);
        Assert.Null(result.TestNullableEnumToNullableStringProperty);
        Assert.Null(result.TestNullableStringToNullableEnumProperty);
        Assert.Null(result.TestNullableEnumToDifferentNullableEnumProperty);
    }

    [Fact]
    public void Map_WithDynamicEnumeration_AndWithNullableProperties_ShouldSucceed()
    {
        // Arrange
        var sourceModel = new EnumerationDynamicNullableSourceModel
        {
            TestEnumDynamicToNullableEnumDynamicProperty = TestEnumerationDynamic.CodeA,
            TestEnumDynamicToNullableStringProperty = TestEnumerationDynamic.CodeA,
            TestStringToNullableEnumDynamicProperty = TestEnumerationDynamic.CodeA.Value,
            TestEnumDynamicToDifferentNullableEnumDynamicProperty = TestEnumerationDynamic.CodeA,
            TestNullableEnumDynamicToEnumDynamicProperty = TestEnumerationDynamic.CodeA,
            TestNullableEnumDynamicToStringProperty = TestEnumerationDynamic.CodeA,
            TestNullableStringToEnumDynamicProperty = TestEnumerationDynamic.CodeA.Value,
            TestNullableEnumDynamicToDifferentEnumDynamicProperty = TestEnumerationDynamic.CodeA,
            TestNullableEnumDynamicToNullableEnumDynamicProperty = TestEnumerationDynamic.CodeA,
            TestNullableEnumDynamicToNullableStringProperty = TestEnumerationDynamic.CodeA,
            TestNullableStringToNullableEnumDynamicProperty = TestEnumerationDynamic.CodeA.Value,
            TestNullableEnumDynamicToDifferentNullableEnumDynamicProperty = TestEnumerationDynamic.CodeA
        };

        // Act
        var result = _enumerationDynamicNullableMapper.SourceToDestination(sourceModel);

        // Assert
        Assert.Equal(TestEnumerationDynamic.CodeA, result.TestEnumDynamicToNullableEnumDynamicProperty);
        Assert.Equal(TestEnumerationDynamic.CodeA.Value, result.TestEnumDynamicToNullableStringProperty);
        Assert.Equal(TestEnumerationDynamic.CodeA, result.TestStringToNullableEnumDynamicProperty);
        Assert.Equal(TestDifferentEnumerationDynamic.CodeA,
            result.TestEnumDynamicToDifferentNullableEnumDynamicProperty);
        Assert.Equal(TestEnumerationDynamic.CodeA, result.TestNullableEnumDynamicToEnumDynamicProperty);
        Assert.Equal(TestEnumerationDynamic.CodeA.Value, result.TestNullableEnumDynamicToStringProperty);
        Assert.Equal(TestEnumerationDynamic.CodeA, result.TestNullableStringToEnumDynamicProperty);
        Assert.Equal(TestDifferentEnumerationDynamic.CodeA,
            result.TestNullableEnumDynamicToDifferentEnumDynamicProperty);
        Assert.Equal(TestEnumerationDynamic.CodeA, result.TestNullableEnumDynamicToNullableEnumDynamicProperty);
        Assert.Equal(TestEnumerationDynamic.CodeA.Value, result.TestNullableEnumDynamicToNullableStringProperty);
        Assert.Equal(TestEnumerationDynamic.CodeA, result.TestNullableStringToNullableEnumDynamicProperty);
        Assert.Equal(TestDifferentEnumerationDynamic.CodeA,
            result.TestNullableEnumDynamicToDifferentNullableEnumDynamicProperty);
    }

    [Fact]
    public void Map_WithDynamicEnumeration_AndWithNullableProperties_AndWithNulls_ShouldSucceed()
    {
        // Arrange
        var sourceModel = new EnumerationDynamicNullableSourceModel
        {
            TestEnumDynamicToNullableEnumDynamicProperty = null!,
            TestEnumDynamicToNullableStringProperty = null!,
            TestStringToNullableEnumDynamicProperty = null!,
            TestEnumDynamicToDifferentNullableEnumDynamicProperty = null!,
            TestNullableEnumDynamicToEnumDynamicProperty = null,
            TestNullableEnumDynamicToStringProperty = null,
            TestNullableStringToEnumDynamicProperty = null,
            TestNullableEnumDynamicToDifferentEnumDynamicProperty = null,
            TestNullableEnumDynamicToNullableEnumDynamicProperty = null,
            TestNullableEnumDynamicToNullableStringProperty = null,
            TestNullableStringToNullableEnumDynamicProperty = null,
            TestNullableEnumDynamicToDifferentNullableEnumDynamicProperty = null
        };

        // Act
        var result = _enumerationDynamicNullableMapper.SourceToDestination(sourceModel);

        // Assert
        Assert.Null(result.TestEnumDynamicToNullableEnumDynamicProperty);
        Assert.Null(result.TestEnumDynamicToNullableStringProperty);
        Assert.Null(result.TestStringToNullableEnumDynamicProperty);
        Assert.Null(result.TestEnumDynamicToDifferentNullableEnumDynamicProperty);
        Assert.Null(result.TestNullableEnumDynamicToEnumDynamicProperty);
        Assert.Null(result.TestNullableEnumDynamicToStringProperty);
        Assert.Null(result.TestNullableStringToEnumDynamicProperty);
        Assert.Null(result.TestNullableEnumDynamicToDifferentEnumDynamicProperty);
        Assert.Null(result.TestNullableEnumDynamicToNullableEnumDynamicProperty);
        Assert.Null(result.TestNullableEnumDynamicToNullableStringProperty);
        Assert.Null(result.TestNullableStringToNullableEnumDynamicProperty);
        Assert.Null(result.TestNullableEnumDynamicToDifferentNullableEnumDynamicProperty);
    }
}