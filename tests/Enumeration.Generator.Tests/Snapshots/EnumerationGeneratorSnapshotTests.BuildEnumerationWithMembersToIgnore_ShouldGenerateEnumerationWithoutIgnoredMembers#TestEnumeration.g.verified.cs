﻿//HintName: TestEnumeration.g.cs
using PMart.Enumeration;

namespace Enumeration.Generator.Tests.Source;

public partial class TestEnumeration : Enumeration<TestEnumeration>
{
    public static readonly TestEnumeration CodeD = new(ValueForCodeD);

    private TestEnumeration(string value) : base(value)
    {
    }
}