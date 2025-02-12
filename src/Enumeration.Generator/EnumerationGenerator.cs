using System.Collections.Immutable;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using PMart.Enumeration.Generator.Attributes;
using PMart.Enumeration.Generator.Helpers;
using PMart.Enumeration.Generator.Models;

namespace PMart.Enumeration.Generator;

/// <summary>
/// The Enumeration incremental generator.
/// </summary>
/// <seealso cref="IIncrementalGenerator"/>
[Generator]
public class EnumerationGenerator : IIncrementalGenerator
{
    private const string MemberNameConstPrefix = "ValueFor";

    public const string InitialExtractionTrackingName = "InitialExtraction";

    /// <inheritdoc />
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        // Do a filter for Enumeration classes
        var enumerationsToGenerate = context.SyntaxProvider
            .ForAttributeWithMetadataName(
                $"{typeof(EnumerationAttribute).FullName}",
                predicate: IsPartialClass,
                transform: static (ctx, _) => GetEnumerationToGenerate(ctx.SemanticModel, ctx.TargetNode))
            .Where(static m => m is not null) // Filter out errors that we don't care about
            .WithTrackingName(InitialExtractionTrackingName);

        // Generate source code for each Enumeration class found
        context.RegisterSourceOutput(enumerationsToGenerate, Execute);
    }

    private static bool IsPartialClass(SyntaxNode syntaxNode, CancellationToken cancellationToken)
    {
        return syntaxNode is ClassDeclarationSyntax classDeclaration &&
               IsPartial(classDeclaration);
    }

    private static bool IsPartial(ClassDeclarationSyntax classDeclaration)
    {
        return classDeclaration.Modifiers.Any(m => m.IsKind(SyntaxKind.PartialKeyword));
    }

    private static EnumerationToGenerate? GetEnumerationToGenerate(SemanticModel semanticModel,
        SyntaxNode enumerationDeclarationSyntax)
    {
        if (enumerationDeclarationSyntax is not ClassDeclarationSyntax classDeclarationSyntax ||
            semanticModel.GetDeclaredSymbol(enumerationDeclarationSyntax) is not INamedTypeSymbol enumerationSymbol)
        {
            return null;
        }

        var symbolMembers = enumerationSymbol.GetMembers();

        return ProcessEnumerationToGenerate(classDeclarationSyntax, enumerationSymbol, symbolMembers);
    }

    private static EnumerationToGenerate? ProcessEnumerationToGenerate(ClassDeclarationSyntax classDeclarationSyntax,
        INamedTypeSymbol enumerationSymbol, ImmutableArray<ISymbol> symbolMembers)
    {
        var enumerationMembersDic = new EquatableStringDictionary();

        foreach (var member in symbolMembers)
        {
            var error = ProcessMemberAndAddToDictionaryIfApplicableOrReturnError(member, symbolMembers,
                enumerationMembersDic);

            if (error is not null)
            {
                return BuildEnumerationToGenerateWithError(error.Value);
            }
        }

        if (!enumerationMembersDic.Any())
        {
            return null;
        }

        return BuildEnumerationToGenerate(classDeclarationSyntax, enumerationSymbol, enumerationMembersDic);
    }

    private static ErrorToReport? ProcessMemberAndAddToDictionaryIfApplicableOrReturnError(ISymbol member,
        ImmutableArray<ISymbol> symbolMembers, EquatableStringDictionary enumerationMemberDic)
    {
        // Check if it is a field eligible to be processed
        if (member is not IFieldSymbol field || !IsPrivateStaticReadonlyString(field))
        {
            return null;
        }

        // Check if the field has the attribute to ignore it
        if (IsToIgnoreFieldByAttribute(field))
        {
            return null;
        }

        var (hasAttribute, memberName) = GetMemberNameFromAttribute(field);

        // Check error getting member name from attribute
        if (hasAttribute && memberName is null)
        {
            return new ErrorToReport(field.Locations.FirstOrDefault(), ErrorIds.InvalidMemberName);
        }

        memberName ??= GetMemberNameFromField(field);

        // Ignore it, if no member name at this point
        if (memberName is null)
        {
            return null;
        }

        // Check member name is the same as the field name
        if (memberName == field.Name)
        {
            return new ErrorToReport(field.Locations.FirstOrDefault(), ErrorIds.MemberHasSameNameAsConstant,
                memberName);
        }

        // Check if there is any other member with same name
        if (symbolMembers.Any(s => s.Name == memberName))
        {
            return new ErrorToReport(field.Locations.FirstOrDefault(), ErrorIds.MemberWithSameNameAlreadyDeclared,
                memberName);
        }

        // Check member name does not exist already
        if (enumerationMemberDic.ContainsKey(memberName))
        {
            return new ErrorToReport(field.Locations.FirstOrDefault(), ErrorIds.MemberNameDuplicated, memberName);
        }

        enumerationMemberDic.Add(memberName, field.Name);

        // return no error
        return null;
    }

    private static bool IsPrivateStaticReadonlyString(IFieldSymbol field)
    {
        return field.DeclaredAccessibility is Accessibility.Private &&
               field.IsStatic &&
               field.IsReadOnly &&
               field.Type.SpecialType == SpecialType.System_String;
    }

    private static bool IsToIgnoreFieldByAttribute(IFieldSymbol field)
    {
        return field.GetAttributes()
            .Any(a => a.AttributeClass?.Name == nameof(EnumerationIgnoreAttribute));
    }

    private static (bool HasAttribute, string? MemberNameFromAttribute) GetMemberNameFromAttribute(IFieldSymbol field)
    {
        foreach (var attribute in field.GetAttributes())
        {
            if (attribute.AttributeClass?.Name == nameof(EnumerationMemberAttribute))
            {
                return (true, GetMemberNameFromAttribute(attribute));
            }
        }

        return (false, null);
    }

    private static string? GetMemberNameFromAttribute(AttributeData attributeData)
    {
        var constructorArgument = attributeData.ConstructorArguments.FirstOrDefault();

        return constructorArgument.Kind != TypedConstantKind.Error &&
               constructorArgument.Value is string attributeValue &&
               IsValidNameForProperty(attributeValue)
            ? attributeValue
            : null;
    }

    private static bool IsValidNameForProperty(string? name)
    {
        return !string.IsNullOrWhiteSpace(name) && SyntaxFacts.IsValidIdentifier(name);
    }

    private static string? GetMemberNameFromField(IFieldSymbol field)
    {
        var prefixLength = MemberNameConstPrefix.Length;

        var fieldName = field.Name;
        var fieldNameAsSpan = fieldName.AsSpan();

        if (!fieldNameAsSpan.StartsWith(MemberNameConstPrefix.AsSpan()) || fieldName.Length == prefixLength)
        {
            return null;
        }

        return fieldNameAsSpan.Slice(prefixLength).ToString();
    }

    private static EnumerationToGenerate BuildEnumerationToGenerateWithError(ErrorToReport errorToReport)
    {
        return new EnumerationToGenerate(errorToReport);
    }

    private static EnumerationToGenerate BuildEnumerationToGenerate(ClassDeclarationSyntax classDeclarationSyntax,
        INamedTypeSymbol enumerationSymbol, EquatableStringDictionary enumerationMembersDic)
    {
        var enumerationName = enumerationSymbol.Name;
        var enumerationNamespace = GetNamespace(enumerationSymbol);
        var accessibilityLevel = GetAccessibilityLevel(enumerationSymbol);
        var isDynamic = IsEnumerationDynamic(classDeclarationSyntax);

        return new EnumerationToGenerate(enumerationName, enumerationNamespace, accessibilityLevel, isDynamic,
            enumerationMembersDic);
    }

    private static string? GetNamespace(INamedTypeSymbol enumerationSymbol)
    {
        return enumerationSymbol.ContainingNamespace.IsGlobalNamespace
            ? null
            : enumerationSymbol.ContainingNamespace.ToString();
    }

    private static string GetAccessibilityLevel(INamedTypeSymbol enumerationSymbol)
    {
        return enumerationSymbol.DeclaredAccessibility.ToString().ToLowerInvariant();
    }

    private static bool IsEnumerationDynamic(ClassDeclarationSyntax classDeclarationSyntax)
    {
        var classAttributes = classDeclarationSyntax.AttributeLists.SelectMany(a => a.Attributes);

        foreach (var attribute in classAttributes)
        {
            if (IsEnumerationAttribute(attribute))
            {
                return GetIsDynamicFromAttribute(attribute);
            }
        }

        return false;
    }

    private static bool IsEnumerationAttribute(AttributeSyntax attributeSyntax)
    {
        return attributeSyntax.Name.ToString() == GetEnumerationAttributeNameWithoutSuffix() ||
               attributeSyntax.Name.ToString() == GetEnumerationAttributeFullNameWithoutSuffix();
    }

    private static string? GetEnumerationAttributeNameWithoutSuffix()
    {
        return RemoveAttributeSuffix(nameof(EnumerationAttribute));
    }

    private static string? RemoveAttributeSuffix(string? attributeName)
    {
        const string suffix = "Attribute";
        
        var attributeNameAsSpan = attributeName.AsSpan();

        if (attributeName is null || !attributeNameAsSpan.EndsWith(suffix.AsSpan()) || attributeName.Length == suffix.Length)
        {
            return attributeName;
        }

        return attributeNameAsSpan.Slice(0, attributeName.Length - suffix.Length).ToString();
    }

    private static string? GetEnumerationAttributeFullNameWithoutSuffix()
    {
        return RemoveAttributeSuffix(typeof(EnumerationAttribute).FullName);
    }

    private static bool GetIsDynamicFromAttribute(AttributeSyntax attribute)
    {
        foreach (var argument in attribute.ArgumentList?.Arguments ?? [])
        {
            if (IsArgumentForIsDynamic(argument))
            {
                return GetArgumentBoolValue(argument);
            }
        }

        return false;
    }

    private static bool IsArgumentForIsDynamic(AttributeArgumentSyntax argumentSyntax)
    {
        return argumentSyntax.NameEquals?.Name.Identifier.Text ==
               nameof(EnumerationAttribute.IsDynamic);
    }

    private static bool GetArgumentBoolValue(AttributeArgumentSyntax argumentSyntax)
    {
        return argumentSyntax.Expression is LiteralExpressionSyntax literal &&
               literal.Token.Value is bool boolValue &&
               boolValue;
    }

    private static void Execute(SourceProductionContext context, EnumerationToGenerate? enumerationToGenerate)
    {
        if (enumerationToGenerate is null)
        {
            return;
        }

        var errorToReport = enumerationToGenerate.Value.ErrorToReport;

        // If error, report it and return, do not add source code.
        if (errorToReport is not null)
        {
            context.ReportDiagnostic(CreateDiagnostic(errorToReport.Value));

            return;
        }

        // Generate the source code and add it to the output
        var result = SourceGenerationBuilder.GenerateEnumerationClass(enumerationToGenerate.Value);

        context.AddSource($"{enumerationToGenerate.Value.Name}.g.cs", SourceText.From(result, Encoding.UTF8));
    }

    private static Diagnostic CreateDiagnostic(ErrorToReport errorToReport)
    {
        var descriptor = new DiagnosticDescriptor(
            id: errorToReport.ErrorId,
            title: "An error generating an Enumeration class",
            messageFormat: errorToReport.Message,
            category: "EnumerationGeneratorAnalyzer",
            defaultSeverity: DiagnosticSeverity.Error,
            isEnabledByDefault: true);

        return Diagnostic.Create(descriptor, errorToReport.Location, errorToReport.MemberName);
    }
}