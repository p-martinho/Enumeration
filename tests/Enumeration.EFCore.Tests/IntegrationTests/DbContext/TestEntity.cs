using System;
using PMart.Enumeration;

namespace Enumeration.EFCore.Tests.IntegrationTests.DbContext;

public class TestEntity
{
    public Guid Id { get; set; }

    public TestEnumeration? Test { get; set; }

    public TestEnumerationDynamic? TestDynamic { get; set; }
}

public class TestEnumeration : Enumeration<TestEnumeration>
{
    public static readonly TestEnumeration CodeA = new(nameof(CodeA));
    
    public static readonly TestEnumeration CodeB = new(nameof(CodeB));

    private TestEnumeration(string value) : base(value)
    {
    }
}

public class TestEnumerationDynamic : EnumerationDynamic<TestEnumerationDynamic>
{
    public static readonly TestEnumerationDynamic CodeA = new(nameof(CodeA));
    
    public static readonly TestEnumerationDynamic CodeB = new(nameof(CodeB));

    public TestEnumerationDynamic()
    {
    }

    private TestEnumerationDynamic(string value) : base(value)
    {
    }
}