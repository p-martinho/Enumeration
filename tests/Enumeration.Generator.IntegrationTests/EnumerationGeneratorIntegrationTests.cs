using Enumeration.Generator.IntegrationTests.EnumerationClasses;

namespace Enumeration.Generator.IntegrationTests;

public class EnumerationGeneratorIntegrationTests
{
    [Fact]
    public void EnumerationWithValueFor_ShouldGenerateMemberFromValueFor()
    {
        // Act
        var enumeration = TestEnumerationWithValueFor.CodeA;
    
        // Assert
        Assert.Equal("CodeA", enumeration.Value);
    }
    
    [Fact]
    public void EnumerationWithMemberAttribute_ShouldGenerateMemberFromAttribute()
    {
        // Act
        var enumerationA = TestEnumerationWithMemberAttribute.MemberCodeA;
        var enumerationB = TestEnumerationWithMemberAttribute.MemberCodeB;
    
        // Assert
        Assert.Equal("CodeA", enumerationA.Value);
        Assert.Equal("CodeB", enumerationB.Value);
    }
    
    [Fact]
    public void EnumerationWithIgnoreAttribute_ShouldNotGenerateMembers()
    {
        // Act
        var enumerationA = TestEnumerationWithIgnoreAttribute.CodeA;
        // Compile error, members where not added:
        // var enumerationB = TestEnumerationWithIgnoreAttribute.CodeB;
        // var enumerationC = TestEnumerationWithIgnoreAttribute.CodeC;
        // var enumerationD = TestEnumerationWithIgnoreAttribute.CodeD;
        
        // Assert
        Assert.Equal("CodeA", enumerationA.Value);
    }
    
    [Fact]
    public void EnumerationWithMembersToIgnore_ShouldNotGenerateMembers()
    {
        // Act
        var enumerationA = TestEnumerationWithMembersToIgnore.CodeA;
        // Compile error, members where not added:
        // var enumerationB = TestEnumerationWithMembersToIgnore.CodeB;
        // var enumerationC = TestEnumerationWithMembersToIgnore.CodeC;
        // var enumerationD = TestEnumerationWithMembersToIgnore.CodeD;
        // var enumerationE = TestEnumerationWithMembersToIgnore.CodeE;
        // var enumerationF = TestEnumerationWithMembersToIgnore.CodeF;
        
        // Assert
        Assert.Equal("CodeA", enumerationA.Value);
    }
    
    [Fact]
    public void EnumerationWithSeveralMembers_ShouldGenerateAllMembers()
    {
        // Act
        var enumerationA = TestEnumerationWithSeveralMembers.CodeA;
        var enumerationB = TestEnumerationWithSeveralMembers.CodeB;
        var enumerationC = TestEnumerationWithSeveralMembers.CodeC;
        // Compile error, members where not added:
        //var enumerationD = TestEnumerationWithSeveralMembers.CodeD;
        
        // Assert
        Assert.Equal("CodeA", enumerationA.Value);
        Assert.Equal("CodeB", enumerationB.Value);
        Assert.Equal("CodeC", enumerationC.Value);
    }
    
    [Fact]
    public void EnumerationWithIsDynamic_ShouldGenerateEnumerationDynamic()
    {
        // Act
        var enumeration = TestEnumerationDynamic.CodeA;
        var enumerationDynamic = TestEnumerationDynamic.GetFromValueOrNew("CodeB");
    
        // Assert
        Assert.Equal("CodeA", enumeration.Value);
        Assert.NotNull(enumerationDynamic);
        Assert.Equal("CodeB", enumerationDynamic.Value);
    }
}