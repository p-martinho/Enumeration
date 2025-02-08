//HintName: EnumerationAttribute.g.cs
namespace PMart.Enumeration.Generator;

[System.AttributeUsage(System.AttributeTargets.Class)]
internal class EnumerationAttribute : System.Attribute
{
    public bool IsDynamic { get; set; }
}