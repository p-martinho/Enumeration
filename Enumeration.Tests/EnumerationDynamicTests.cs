using System.Collections.Immutable;
using System.Linq;
using PM.Enumeration;
using Xunit;

namespace Enumeration.Tests
{
    public class EnumerationDynamicTests
    {
        #region GetFromValueOrNew Tests

        [Fact]
        public void GetFromValueOrNew_WhenNewValue_ShouldReturnNewInstance()
        {
            // ARRANGE
            var newTestType = "newTestType";

            // ACT
            var instance = TestEnumerationDynamic.GetFromValueOrNew(newTestType);

            // ASSERT
            Assert.NotNull(instance);
            Assert.Equal(newTestType, instance.Value);
        }

        [Fact]
        public void GetFromValueOrNew_WhenExistentValue_ShouldReturnInstanceWithValue()
        {
            // ARRANGE
            var existentValue = TestEnumerationDynamic.CodeA.Value;

            // ACT
            var instance = TestEnumerationDynamic.GetFromValueOrNew(existentValue);

            // ASSERT
            Assert.NotNull(instance);
            Assert.Same(TestEnumerationDynamic.CodeA, instance);
        }

        [Fact]
        public void GetFromValueOrDefault_ShouldBeCaseInsensitive()
        {
            // ARRANGE
            var existentValue = TestEnumerationDynamic.CodeA.Value;
            var existentValueInDifferentCase = existentValue.ToUpper();

            // ACT
            var instance = TestEnumerationDynamic.GetFromValueOrNew(existentValueInDifferentCase);

            // ASSERT
            Assert.Same(TestEnumerationDynamic.CodeA, instance);
        }

        [Fact]
        public void GetFromValueOrDefault_WhenValueIsNull_ShouldReturnNewInstanceWithNullValue()
        {
            // ARRANGE
            string? nullValue = null;

            // ACT
            var instance = TestEnumerationDynamic.GetFromValueOrNew(nullValue!);

            // ASSERT
            Assert.NotNull(instance);
            Assert.Null(instance.Value);
        }

        #endregion

        #region GetMembers Tests

        [Fact]
        public void GetMembers_ShouldReturnOnlyTheDefaults()
        {
            // ARRANGE
            var newTestType = "newTestType";
            var instanceWithDynamicValue = TestEnumerationDynamic.GetFromValueOrNew(newTestType);

            // ACT
            var members = TestEnumerationDynamic.GetMembers().ToList();

            // ASSERT
            Assert.Single(members);
            Assert.DoesNotContain(instanceWithDynamicValue, members);
        }

        [Fact]
        public void GetMembers_ShouldNotBePossibleToChangeMembersList()
        {
            // ARRANGE
            var newMember = TestEnumerationDynamic.GetFromValueOrNew("newCode");

            // ACT
            var membersList = (ImmutableHashSet<TestEnumerationDynamic>) TestEnumerationDynamic.GetMembers();
            membersList = membersList.Add(newMember);
            var originalMembersList = TestEnumerationDynamic.GetMembers();

            // ASSERT
            Assert.Contains(newMember, membersList);
            Assert.DoesNotContain(newMember, originalMembersList);
        }

        #endregion

        #region HasValue Tests

        [Fact]
        public void HasValue_WithDynamicValue_ShouldReturnFalse()
        {
            // ARRANGE
            var newTestType = "newTestType";
            var instanceWithDynamicValue = TestEnumerationDynamic.GetFromValueOrNew(newTestType);

            // ACT
            var result = TestEnumerationDynamic.HasValue(newTestType);

            // ASSERT
            Assert.False(result);
            Assert.Equal(newTestType, instanceWithDynamicValue.Value);
        }

        #endregion

        #region Equals Tests

        [Fact]
        public void Equals_WhenBothValuesAreNull_ShouldReturnTrue()
        {
            // ARRANGE
            var instance1 = TestEnumerationDynamic.GetFromValueOrNew(null!);
            var instance2 = TestEnumerationDynamic.GetFromValueOrNew(null!);

            // ACT
            var result = Equals(instance1, instance2);

            // ASSERT
            Assert.True(result);
        }

        [Fact]
        public void Equals_WhenDifferentInstanceButSameValue_ShouldReturnTrue()
        {
            // ARRANGE
            var newTestType = "newTestType";
            var instance1 = TestEnumerationDynamic.GetFromValueOrNew(newTestType);
            var instance2 = TestEnumerationDynamic.GetFromValueOrNew(newTestType);

            // ACT
            var result = Equals(instance1, instance2);

            // ASSERT
            Assert.True(result);
        }

        #endregion

        #region Private EnumerationDynamic classes for testing

        private class TestEnumerationDynamic : EnumerationDynamic<TestEnumerationDynamic>
        {
            public static readonly TestEnumerationDynamic CodeA = new(nameof(CodeA));

            public TestEnumerationDynamic()
            {
            }

            private TestEnumerationDynamic(string value) : base(value)
            {
            }
        }

        #endregion
    }
}