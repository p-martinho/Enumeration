using PMart.Enumeration;

namespace Enumeration.Mappers.Tests.EnumerationClasses;

internal class TestEnumerationDynamicWithSubClasses : EnumerationDynamic<TestEnumerationDynamicWithSubClasses>
{
    public static readonly TestEnumerationDynamicWithSubClasses CodeA = new CodeAType();
    public static readonly TestEnumerationDynamicWithSubClasses CodeB = new CodeBType();

    public TestEnumerationDynamicWithSubClasses()
    {
    }
    
    protected TestEnumerationDynamicWithSubClasses(string value) : base(value)
    {
    }

    private class CodeAType : TestEnumerationDynamicWithSubClasses
    {
        public CodeAType() : base(nameof(CodeA))
        {
        }
    }

    private class CodeBType : TestEnumerationDynamicWithSubClasses
    {
        public CodeBType() : base(nameof(CodeB))
        {
        }
    }
}

internal class SubTypeWithEnumerationsDeclared : TestEnumerationDynamicWithSubClasses
{
    public static readonly SubTypeWithEnumerationsDeclared SubTypeCodeA = new(nameof(SubTypeCodeA));

    private SubTypeWithEnumerationsDeclared(string value) : base(value)
    {
    }
}