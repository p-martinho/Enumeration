using System.Diagnostics.CodeAnalysis;
using System.Text;
using PMart.Enumeration.Generator.Models;

namespace PMart.Enumeration.Generator.Helpers;

/// <summary>
/// The source code builder.
/// </summary>
[ExcludeFromCodeCoverage]
internal static class SourceGenerationBuilder
{
    /// <summary>
    /// The namespace for the generator code.
    /// </summary>
    public const string GeneratorNamespace = "PMart.Enumeration.Generator";
    
    /// <summary>
    /// The name of the Enumeration attribute.
    /// </summary>
    public const string EnumerationAttributeNameWithoutSuffix = "Enumeration";
    
    /// <summary>
    /// The name of the Enumeration attribute.
    /// </summary>
    public const string EnumerationAttributeName = $"{EnumerationAttributeNameWithoutSuffix}Attribute";
    
    /// <summary>
    /// The name of the EnumerationMember attribute.
    /// </summary>
    public const string EnumerationMemberAttributeName = "EnumerationMemberAttribute";
    
    /// <summary>
    /// The name of the EnumerationIgnore attribute.
    /// </summary>
    public const string EnumerationIgnoreAttributeName = "EnumerationIgnoreAttribute";
    
    /// <summary>
    /// The name of the argument IsDynamic of the EnumerationAttribute.
    /// </summary>
    public const string EnumerationAttributeIsDynamicArgumentName = "IsDynamic";

    /// <summary>
    /// Generates the source code for the EnumerationAttribute.
    /// </summary>
    /// <returns>The source code.</returns>
    public static string GenerateEnumerationAttribute() => $$"""
        namespace {{GeneratorNamespace}};
        
        [System.AttributeUsage(System.AttributeTargets.Class)]
        internal class {{EnumerationAttributeName}} : System.Attribute
        {
            public bool {{EnumerationAttributeIsDynamicArgumentName}} { get; set; }
        }
        """;

    /// <summary>
    /// Generates the source code for the EnumerationMemberAttribute.
    /// </summary>
    /// <returns>The source code.</returns>
    public static string GenerateEnumerationMemberAttribute() => $$"""
        namespace {{GeneratorNamespace}};

        [System.AttributeUsage(System.AttributeTargets.Field)]
        internal class {{EnumerationMemberAttributeName}} : System.Attribute
        {
            public string Name { get; }

            public {{EnumerationMemberAttributeName}}(string memberName)
            {
                Name = memberName;
            }
        }
        """;

    /// <summary>
    /// Generates the source code for the EnumerationIgnoreAttribute.
    /// </summary>
    /// <returns>The source code.</returns>
    public static string GenerateEnumerationIgnoreAttribute() => $$"""
        namespace {{GeneratorNamespace}};

        [System.AttributeUsage(System.AttributeTargets.Field)]
        internal class {{EnumerationIgnoreAttributeName}} : System.Attribute
        {
        }
        """;

    /// <summary>
    /// Generates the source code for the Enumeration class.
    /// </summary>
    /// <param name="enumerationToGenerate">The Enumeration to generate.</param>
    /// <returns>The source code.</returns>
    public static string GenerateEnumerationClass(EnumerationToGenerate enumerationToGenerate)
    {
        var sb = new StringBuilder();
        
        sb.Append(
            """
            using PMart.Enumeration;


            """);

        if (!string.IsNullOrEmpty(enumerationToGenerate.Namespace))
        {
            sb.Append("namespace ").Append(enumerationToGenerate.Namespace).Append(
                """
                ;


                """);
        }

        sb.Append(enumerationToGenerate.AccessibilityLevel).Append(" partial class ").Append(enumerationToGenerate.Name).Append(enumerationToGenerate.IsDynamic ? " : EnumerationDynamic<" : " : Enumeration<").Append(enumerationToGenerate.Name).Append(">").Append(
            """

            {
            """);

        foreach (var member in enumerationToGenerate.Members ?? [])
        {

            sb.Append(
                """

                    public static readonly 
                """).Append(enumerationToGenerate.Name).Append(" ").Append(member.Key).Append(" = new(").Append(member.Value).Append(");");
        }

        if (enumerationToGenerate.IsDynamic)
        {
            sb.Append(
                """


                    public 
                """).Append(enumerationToGenerate.Name).Append("()").Append(
                """
                
                    {
                    }
                """);
        }

        sb.Append(
            """


                private 
            """).Append(enumerationToGenerate.Name).Append("(string value) : base(value)").Append(
            """

                {
                }
            }
            """);

        return sb.ToString();
    }
}