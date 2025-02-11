﻿using System.Diagnostics.CodeAnalysis;
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