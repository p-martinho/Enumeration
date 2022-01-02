using PM.Enumeration;

namespace Enumeration.Tests.EnumerationClasses;

internal abstract class TestEnumerationWithSubClasses : Enumeration<TestEnumerationWithSubClasses>
{
    public static readonly TestEnumerationWithSubClasses CodeA = new CodeAType();
    public static readonly TestEnumerationWithSubClasses CodeB = new CodeBType();

    public abstract bool IsCodeB { get; }

    private TestEnumerationWithSubClasses(string value) : base(value)
    {
    }

    private class CodeAType : TestEnumerationWithSubClasses
    {
        public CodeAType() : base(nameof(CodeA))
        {
        }

        public override bool IsCodeB => false;
    }

    private class CodeBType : TestEnumerationWithSubClasses
    {
        public CodeBType() : base(nameof(CodeB))
        {
        }

        public override bool IsCodeB => true;
    }
}