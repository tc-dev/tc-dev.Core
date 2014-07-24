using System;
using NUnit.Framework;
using tc_dev.Core.Common.Utilities;

namespace tc_dev.Core.Common.UnitTests.Utilities
{
	[TestFixture]
    public class ExceptionUtilsTests
    {
        [TestCase(null, null)]
        [TestCase("paramName", "message")]
        public void ThrowIfNull_NullClass_ThrowsException(string paramName, string message) {
            string nullThing = null;

            Assert.Throws<ArgumentNullException>(() => nullThing.ThrowIfNull(paramName, message));
        }

        [TestCase(null, null)]
        [TestCase("paramName", "message")]
        public void ThrowIfNull_NotNullClass_DoesNotThrowException(string paramName, string message) {
            string notNullThing = "imNotNull";

            Assert.DoesNotThrow(() => notNullThing.ThrowIfNull(paramName, message));
        }

        [TestCase(null, null)]
        [TestCase("paramName", "message")]
        public void ThrowIfNull_NullStruct_ThrowsException(string paramName, string message) {
            Nullable<int> nullThing = null;

            Assert.Throws<ArgumentNullException>(() => nullThing.ThrowIfNull(paramName, message));
        }

        [TestCase(null, null)]
        [TestCase("paramName", "message")]
        public void ThrowIfNull_NotNullStruct_DoesNotThrowException(string paramName, string message) {
            Nullable<int> notNullThing = 42;

            Assert.DoesNotThrow(() => notNullThing.ThrowIfNull(paramName, message));
        }
    }
}
