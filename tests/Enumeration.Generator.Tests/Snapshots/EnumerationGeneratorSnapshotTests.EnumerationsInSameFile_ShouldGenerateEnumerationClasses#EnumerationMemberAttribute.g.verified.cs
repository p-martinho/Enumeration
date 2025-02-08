//HintName: EnumerationMemberAttribute.g.cs
namespace PMart.Enumeration.Generator;

[System.AttributeUsage(System.AttributeTargets.Field)]
internal class EnumerationMemberAttribute : System.Attribute
{
    public string Name { get; }

    public EnumerationMemberAttribute(string memberName)
    {
        Name = memberName;
    }
}