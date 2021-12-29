using System;
using PM.Enumeration;

namespace Enumeration.EFCore.Tests.DbContext;

public class TestEntity
{
    public Guid Id { get; set; }

    public TestEnumeration? Test { get; set; }

    public TestEnumerationDynamic? TestDynamic { get; set; }
}

public class TestEnumeration : Enumeration<TestEnumeration>
{
    public static readonly TestEnumeration CodeA = new(nameof(CodeA));

    private TestEnumeration(string value) : base(value)
    {
    }
}

public class TestEnumerationDynamic : EnumerationDynamic<TestEnumerationDynamic>
{
    public static readonly TestEnumerationDynamic CodeA = new(nameof(CodeA));

    public TestEnumerationDynamic()
    {
    }

    private TestEnumerationDynamic(string value) : base(value)
    {
    }
}