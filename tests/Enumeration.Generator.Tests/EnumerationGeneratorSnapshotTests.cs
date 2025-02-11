using Enumeration.Generator.Tests.TestHelpers;
using Microsoft.CodeAnalysis;

namespace Enumeration.Generator.Tests;

public class EnumerationGeneratorSnapshotTests
{
    private const string SnapshotsDirectoryName = "Snapshots";

    #region Generate Enumeration class Tests

    [Fact]
    public Task EnumerationWithPrefixValueFor_ShouldGenerateEnumerationClassWithMember()
    {
        // Arrange
        var source = TestingSourceBuilder.BuildEnumerationWithPrefixValueFor();

        // Act
        var driver = GeneratorDriverBuilder.GenerateDriver(source);

        // Assert
        return Verify(driver);
    }
    
    [Fact]
    public Task EnumerationWithNamedMembers_ShouldGenerateMembersWithCorrectName()
    {
        // Arrange
        var source = TestingSourceBuilder.BuildEnumerationWithNamedMembers();

        // Act
        var driver = GeneratorDriverBuilder.GenerateDriver(source);

        // Assert
        return Verify(driver);
    }
    
    [Fact]
    public Task EnumerationDynamic_ShouldGenerateEnumerationDynamicClass()
    {
        // Arrange
        var source = TestingSourceBuilder.BuildEnumerationDynamic();

        // Act
        var driver = GeneratorDriverBuilder.GenerateDriver(source);

        // Assert
        return Verify(driver);
    }
    
    [Fact]
    public Task BuildEnumerationWithMembersToIgnore_ShouldGenerateEnumerationWithoutIgnoredMembers()
    {
        // Arrange
        var source = TestingSourceBuilder.BuildEnumerationWithMembersToIgnore();

        // Act
        var driver = GeneratorDriverBuilder.GenerateDriver(source);

        // Assert
        return Verify(driver);
    }
    
    [Fact]
    public Task InternalEnumeration_ShouldGenerateEnumerationClassInternal()
    {
        // Arrange
        var source = TestingSourceBuilder.BuildInternalEnumeration();

        // Act
        var driver = GeneratorDriverBuilder.GenerateDriver(source);

        // Assert
        return Verify(driver);
    }

    [Fact]
    public Task EnumerationWithThreeMembers_ShouldGenerateEnumerationClassWithThreeMembers()
    {
        // Arrange
        var source = TestingSourceBuilder.BuildEnumerationWithThreeMembers();

        // Act
        var driver = GeneratorDriverBuilder.GenerateDriver(source);

        // Assert
        return Verify(driver);
    }
    
    [Fact]
    public Task EnumerationWithValueDifferentFromMemberName_ShouldGenerateMemberWithCorrectName()
    {
        // Arrange
        var source = TestingSourceBuilder.BuildEnumerationWithValueDifferentFromMemberName();

        // Act
        var driver = GeneratorDriverBuilder.GenerateDriver(source);

        // Assert
        return Verify(driver);
    }
    
    [Fact]
    public Task EnumerationWithOtherNonEnumerationMembers_ShouldGenerateEnumerationClass()
    {
        // Arrange
        var source = TestingSourceBuilder.BuildEnumerationWithOtherNonEnumerationMembers();

        // Act
        var driver = GeneratorDriverBuilder.GenerateDriver(source);

        // Assert
        return Verify(driver);
    }
    
    [Fact]
    public Task EnumerationsInSameFile_ShouldGenerateEnumerationClasses()
    {
        // Arrange
        var source = TestingSourceBuilder.BuildTwoEnumerationsInSameFile();

        // Act
        var driver = GeneratorDriverBuilder.GenerateDriver(source);

        // Assert
        return Verify(driver);
    }
    
    [Fact]
    public Task TwoEnumerationsInSameFileOneWithoutAttribute_ShouldGenerateOnlyOneEnumerationClass()
    {
        // Arrange
        var source = TestingSourceBuilder.BuildTwoEnumerationsInSameFileOneWithoutAttribute();

        // Act
        var driver = GeneratorDriverBuilder.GenerateDriver(source);

        // Assert
        return Verify(driver);
    }
    
    [Fact]
    public Task EnumerationWithBlockScopedNamespace_ShouldGenerateEnumerationClassWithCorrectNamespace()
    {
        // Arrange
        var source = TestingSourceBuilder.BuildEnumerationWithBlockScopedNamespace();

        // Act
        var driver = GeneratorDriverBuilder.GenerateDriver(source);

        // Assert
        return Verify(driver);
    }
    
    [Fact]
    public Task EnumerationWithNestedNamespaces_ShouldGenerateEnumerationClassWithFullNamespace()
    {
        // Arrange
        var source = TestingSourceBuilder.BuildEnumerationWithNestedNamespaces();

        // Act
        var driver = GeneratorDriverBuilder.GenerateDriver(source);

        // Assert
        return Verify(driver);
    }
    
    [Fact]
    public Task EnumerationWithoutNamespace_ShouldGenerateEnumerationClassWithoutNamespace()
    {
        // Arrange
        var source = TestingSourceBuilder.BuildEnumerationWithoutNamespace();

        // Act
        var driver = GeneratorDriverBuilder.GenerateDriver(source);

        // Assert
        return Verify(driver);
    }
    
    [Fact]
    public Task EnumerationWithAttributeWithFullNameAndDynamic_ShouldGenerateEnumerationDynamicClass()
    {
        // Arrange
        var source = TestingSourceBuilder.BuildEnumerationWithAttributeWithFullNameAndDynamic();

        // Act
        var driver = GeneratorDriverBuilder.GenerateDriver(source);

        // Assert
        return Verify(driver);
    }
    
    [Fact]
    public Task EnumerationWithOtherAttributes_ShouldGenerateEnumerationClass()
    {
        // Arrange
        var source = TestingSourceBuilder.BuildEnumerationWithOtherAttributes();

        // Act
        var driver = GeneratorDriverBuilder.GenerateDriver(source);

        // Assert
        return Verify(driver);
    }
    
    [Fact]
    public Task EnumerationWithAttributeAndInheritFromEnumeration_ShouldGenerateEnumerationClass()
    {
        // Arrange
        var source = TestingSourceBuilder.BuildEnumerationWithAttributeAndInheritFromEnumeration();

        // Act
        var driver = GeneratorDriverBuilder.GenerateDriver(source);

        // Assert
        return Verify(driver);
    }
    
    #endregion

    #region Do not generate Enumeration class (without reporting diagnostics) Tests

    [Fact]
    public Task NoUsages_ShouldNotGenerateEnumerationClass()
    {
        // Arrange
        string? source = null;

        // Act
        var driver = GeneratorDriverBuilder.GenerateDriver(source);

        // Assert
        return Verify(driver);
    }
    
    [Fact]
    public Task EnumerationEmpty_ShouldNotGenerateEnumerationClass()
    {
        // Arrange
        var source = TestingSourceBuilder.BuildEnumerationEmpty();

        // Act
        var driver = GeneratorDriverBuilder.GenerateDriver(source);

        // Assert
        return Verify(driver);
    }
    
    [Fact]
    public Task EnumerationWithoutAttribute_ShouldNotGenerateEnumerationClass()
    {
        // Arrange
        var source = TestingSourceBuilder.BuildEnumerationWithoutAttribute();

        // Act
        var driver = GeneratorDriverBuilder.GenerateDriver(source);

        // Assert
        return Verify(driver);
    }
    
    [Fact]
    public Task EnumerationNotPartial_ShouldNotGenerateEnumerationClass()
    {
        // Arrange
        var source = TestingSourceBuilder.BuildEnumerationNotPartial();

        // Act
        var driver = GeneratorDriverBuilder.GenerateDriver(source);

        // Assert
        return Verify(driver);
    }
    
    [Fact]
    public Task EnumerationWithMemberNotString_ShouldNotGenerateEnumerationClass()
    {
        // Arrange
        var source = TestingSourceBuilder.BuildEnumerationWithMemberNotString();

        // Act
        var driver = GeneratorDriverBuilder.GenerateDriver(source);

        // Assert
        return Verify(driver);
    }
    
    [Fact]
    public Task EnumerationWithMemberNotPrivate_ShouldNotGenerateEnumerationClass()
    {
        // Arrange
        var source = TestingSourceBuilder.BuildEnumerationWithMemberNotPrivate();

        // Act
        var driver = GeneratorDriverBuilder.GenerateDriver(source);

        // Assert
        return Verify(driver);
    }
    
    [Fact]
    public Task EnumerationWithMemberNotStatic_ShouldNotGenerateEnumerationClass()
    {
        // Arrange
        var source = TestingSourceBuilder.BuildEnumerationWithMemberNotStatic();

        // Act
        var driver = GeneratorDriverBuilder.GenerateDriver(source);

        // Assert
        return Verify(driver);
    }
    
    [Fact]
    public Task EnumerationWithMemberConstant_ShouldNotGenerateEnumerationClass()
    {
        // Arrange
        var source = TestingSourceBuilder.BuildEnumerationWithMemberConstant();

        // Act
        var driver = GeneratorDriverBuilder.GenerateDriver(source);

        // Assert
        return Verify(driver);
    }
    
    [Fact]
    public Task EnumerationWithMemberNamedJustValueFor_ShouldNotGenerateEnumerationClass()
    {
        // Arrange
        var source = TestingSourceBuilder.BuildEnumerationWithMemberNamedJustValueFor();

        // Act
        var driver = GeneratorDriverBuilder.GenerateDriver(source);

        // Assert
        return Verify(driver);
    }
    
    #endregion

    #region Report diagnostics Tests
    
    [Fact]
    public Task EnumerationWithMemberNameEqualsToFieldName_ShouldReportError()
    {
        // Arrange
        var source = TestingSourceBuilder.BuildEnumerationWithMemberNameEqualsToFieldName();

        // Act
        var driver = GeneratorDriverBuilder.GenerateDriver(source);

        // Assert
        return Verify(driver);
    }
    
    [Fact]
    public Task EnumerationWithMemberNameEqualsToExistentMember_ShouldReportError()
    {
        // Arrange
        var source = TestingSourceBuilder.BuildEnumerationWithMemberNameEqualsToExistentMember();

        // Act
        var driver = GeneratorDriverBuilder.GenerateDriver(source);

        // Assert
        return Verify(driver);
    }
    
    [Fact]
    public Task EnumerationWithMemberWithPrefixValueForEqualsToExistentMember_ShouldReportError()
    {
        // Arrange
        var source = TestingSourceBuilder.BuildEnumerationWithMemberWithPrefixValueForEqualsToExistentMember();

        // Act
        var driver = GeneratorDriverBuilder.GenerateDriver(source);

        // Assert
        return Verify(driver);
    }
    
    [Fact]
    public Task EnumerationWithMemberNameEqualsToMemberWithPrefixValueFor_ShouldReportError()
    {
        // Arrange
        var source = TestingSourceBuilder.BuildEnumerationWithMemberNameEqualsToMemberWithPrefixValueFor();

        // Act
        var driver = GeneratorDriverBuilder.GenerateDriver(source);

        // Assert
        return Verify(driver);
    }
    
    [Fact]
    public Task EnumerationWithEmptyMemberName_ShouldReportError()
    {
        // Arrange
        var source = TestingSourceBuilder.BuildEnumerationWithEmptyMemberName();

        // Act
        var driver = GeneratorDriverBuilder.GenerateDriver(source);

        // Assert
        return Verify(driver);
    }
    
    [Fact]
    public Task EnumerationWithNullMemberName_ShouldReportError()
    {
        // Arrange
        var source = TestingSourceBuilder.BuildEnumerationWithNullMemberName();

        // Act
        var driver = GeneratorDriverBuilder.GenerateDriver(source);

        // Assert
        return Verify(driver);
    }
    
    [Fact]
    public Task EnumerationWithInvalidMemberName_ShouldReportError()
    {
        // Arrange
        var source = TestingSourceBuilder.BuildEnumerationWithInvalidMemberName();

        // Act
        var driver = GeneratorDriverBuilder.GenerateDriver(source);

        // Assert
        return Verify(driver);
    }
    
    #endregion

    private static Task Verify(GeneratorDriver driver)
    {
        return Verifier.Verify(driver)
            .UseDirectory(SnapshotsDirectoryName);
    }
}