﻿//HintName: TestEnumeration.g.cs
// <auto-generated>
//     This code was generated by the PMart.Enumeration.Generator source generator.
// </auto-generated>
#nullable enable

using PMart.Enumeration;

namespace Enumeration.Generator.Tests.Source
{
    public partial class TestEnumeration : EnumerationDynamic<TestEnumeration>
    {
        public static readonly TestEnumeration CodeA = new(ValueForCodeA);

        public TestEnumeration()
        {
        }

        private TestEnumeration(string value) : base(value)
        {
        }
    }
}