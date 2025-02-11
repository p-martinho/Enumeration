namespace Enumeration.Generator.Tests.TestHelpers;

internal static class TestingSourceBuilder
{
    #region Generate Enumeration class Cases
    
    public static string BuildEnumerationWithPrefixValueFor() => BuildHeadSection() + BuildBodySection();
    
    public static string BuildEnumerationWithNamedMembers() => BuildHeadSection() +
        """
           [EnumerationMember("CodeAa")]
           private static readonly string ValueForCodeA = "CodeA";

           [EnumerationMember("CodeBb")]
           private static readonly string CodeB = "CodeB";
        }
        """;
    
    public static string BuildEnumerationDynamic() =>
        """
        using PMart.Enumeration.Generator.Attributes;

        namespace Enumeration.Generator.Tests.Source;

        [Enumeration(IsDynamic = true)]
        public partial class TestEnumeration
        {

        """ + BuildBodySection();
    
    public static string BuildEnumerationWithMembersToIgnore() => BuildHeadSection() +
    """
        [EnumerationIgnore]
        private static readonly string ValueForCodeA = "CodeA";

        [EnumerationIgnore]
        [EnumerationMember("CodeBb")]
        private static readonly string CodeB = "CodeB";
        
        [EnumerationMember("CodeCc")]
        [EnumerationIgnore]
        private static readonly string CodeC = "CodeC";
        
        private static readonly string ValueForCodeD = "CodeD";
    }
    """;
    
    public static string BuildInternalEnumeration() => BuildHeadSection().Replace("public", "internal") + BuildBodySection();

    public static string BuildEnumerationWithThreeMembers() => BuildHeadSection() + 
        """
            private static readonly string ValueForCodeA = "CodeA";
            private static readonly string ValueForCodeB = "CodeB";
            private static readonly string ValueForCodeC = "CodeC";
        }
        """;

    public static string BuildEnumerationWithValueDifferentFromMemberName() => BuildHeadSection() + 
        """
            private static readonly string ValueForCodeA = "DifferentCodeA";
        }
        """;
    
    public static string BuildEnumerationWithOtherNonEnumerationMembers() => BuildHeadSection() +
        """
            private static readonly string ValueForCodeA = "CodeA";
            private static readonly int ValueForCodeB = 1;

            public string DoSomething() => "Something done";
        }
        """;

    public static string BuildTwoEnumerationsInSameFile() => BuildHeadSection() + BuildBodySection() +
        """

        [Enumeration]
        public partial class SecondTestEnumeration
        {

        """ + BuildBodySection();

    public static string BuildTwoEnumerationsInSameFileOneWithoutAttribute() => BuildHeadSection() + BuildBodySection() +
        """

        public partial class SecondTestEnumerationWithoutAttribute
        {

        """ + BuildBodySection();
    
    public static string BuildEnumerationWithBlockScopedNamespace() =>
        """
        using PMart.Enumeration.Generator.Attributes;

        namespace Enumeration.Generator.Tests.Source
        {
            [Enumeration]
            public partial class TestEnumeration
            {
                private static readonly string ValueForCodeA = "CodeA";
            }
        }
        """;
    
    public static string BuildEnumerationWithNestedNamespaces() =>
        """
        using PMart.Enumeration.Generator.Attributes;
        
        namespace Enumeration.Generator.Tests.Source
        {
            namespace InnerNamespace
            {
                namespace MostInnerNamespace
                {
                    [Enumeration]
                    public partial class TestEnumeration
                    {
                        private static readonly string ValueForCodeA = "CodeA";
                    }
                }
            }
        }
        """;
    
    public static string BuildEnumerationWithoutNamespace() =>
        """
        using PMart.Enumeration.Generator.Attributes;

        [Enumeration]
        public partial class TestEnumeration
        {

        """ + BuildBodySection();
    
    public static string BuildEnumerationWithAttributeWithFullNameAndDynamic() =>
        """
        namespace Enumeration.Generator.Tests.Source;

        [PMart.Enumeration.Generator.Attributes.Enumeration(IsDynamic = true)]
        public partial class TestEnumeration
        {

        """ + BuildBodySection();
    
    public static string BuildEnumerationWithOtherAttributes() =>
        """
        using PMart.Enumeration.Generator.Attributes;

        namespace Enumeration.Generator.Tests.Source;

        [Serializable]
        [Enumeration]
        public partial class TestEnumeration
        {
            [NonSerialized]
            private static readonly string ValueForCodeA = "CodeA";

            [NonSerialized]
            [EnumerationMember("CodeB")]
            private static readonly string CodeBb = "CodeB";

            [NonSerialized]
            private static readonly string CodeC = "CodeC";
        }
        """;
    
    public static string BuildEnumerationWithAttributeAndInheritFromEnumeration() =>
        """
        using PMart.Enumeration.Generator.Attributes;

        namespace Enumeration.Generator.Tests.Source;

        [Enumeration]
        public partial class TestEnumeration : Enumeration<TestEnumeration>
        {

        """ + BuildBodySection();
    
    #endregion
    
    #region Do not generate Enumeration class (without reporting diagnostics) Cases
    
    public static string BuildEnumerationEmpty() => BuildHeadSection() + "}";
    
    public static string BuildEnumerationWithoutAttribute() =>
        """
        using PMart.Enumeration.Generator.Attributes;

        namespace Enumeration.Generator.Tests.Source;

        public partial class TestEnumeration
        {

        """ + BuildBodySection();
    
    public static string BuildEnumerationNotPartial() =>
        """
        using PMart.Enumeration.Generator.Attributes;

        namespace Enumeration.Generator.Tests.Source;

        [Enumeration]
        public class TestEnumeration
        {

        """ + BuildBodySection();
    
    public static string BuildEnumerationWithMemberNotString() => BuildHeadSection() +
       """
           public static readonly object ValueForCodeA = "CodeA";
       }
       """;

    public static string BuildEnumerationWithMemberNotPrivate() => BuildHeadSection() +
        """
            public static readonly string ValueForCodeA = "CodeA";
        }
        """;

    public static string BuildEnumerationWithMemberNotStatic() => BuildHeadSection() +
        """
            private readonly string ValueForCodeA = "CodeA";
        }
        """;

    public static string BuildEnumerationWithMemberConstant() => BuildHeadSection() +
        """
            private const string ValueForCodeA = "CodeA";
        }
        """;
    
    public static string BuildEnumerationWithMemberNamedJustValueFor() => BuildHeadSection() + 
        """
            private static readonly string ValueFor = "CodeA";
        }
        """;
    
    #endregion

    #region Report diagnostics Cases
    
    public static string BuildEnumerationWithMemberNameEqualsToFieldName() => BuildHeadSection() +
        """
            [EnumerationMember("CodeA")]
            private static readonly string CodeA = "CodeA";
        }
        """;
    
    public static string BuildEnumerationWithMemberNameEqualsToExistentMember() => BuildHeadSection() + 
        """
            [EnumerationMember("CodeA")]
            private static readonly string CodeAa = "CodeA";

            private static readonly string CodeA = "CodeA";
        }
        """;
    
    public static string BuildEnumerationWithMemberWithPrefixValueForEqualsToExistentMember() => BuildHeadSection() + 
        """
            private static readonly string ValueForCodeA = "CodeA";

            private static readonly string CodeA = "CodeA";
        }
        """;
    
    public static string BuildEnumerationWithMemberNameEqualsToMemberWithPrefixValueFor() => BuildHeadSection() + 
        """
            private static readonly string ValueForCodeA = "CodeA";

            [EnumerationMember("CodeA")]
            private static readonly string CodeAa = "CodeA";
        }
        """;
    
    public static string BuildEnumerationWithEmptyMemberName() => BuildHeadSection() + 
       """
           [EnumerationMember("")]
           private static readonly string CodeA = "CodeA";
       }
       """;
    
    public static string BuildEnumerationWithNullMemberName() => BuildHeadSection() + 
        """
            [EnumerationMember(null)]
            private static readonly string CodeA = "CodeA";
        }
        """;
    
    public static string BuildEnumerationWithInvalidMemberName() => BuildHeadSection() + 
        """
            [EnumerationMember("123")]
            private static readonly string CodeA = "CodeA";
        }
        """;
    
    #endregion

    private static string BuildHeadSection() =>
        """
        using PMart.Enumeration.Generator.Attributes;

        namespace Enumeration.Generator.Tests.Source;

        [Enumeration]
        public partial class TestEnumeration
        {

        """;

    private static string BuildBodySection() =>
        """
            private static readonly string ValueForCodeA = "CodeA";
        }
        """;
}
