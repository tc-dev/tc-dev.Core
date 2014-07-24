using System;
using NUnit.Framework;
using tc_dev.Core.Domain.Extensions;

namespace tc_dev.Core.UnitTests.Domain.Extensions
{
    [TestFixture]
    public class IdentifiableUtilsTests
    {
        [Test]
        public void IsNew_NullEntity_ThrowsException() {
            FakeEntity nullEntity = null;

            Assert.Throws<ArgumentNullException>(() => nullEntity.IsNew());
        }

        [Test]
        public void IsNew_NewEntity_ReturnsTrue() {
            FakeEntity newEntity = new FakeEntity();

            var result = newEntity.IsNew();

            Assert.That(result, Is.True);
        }

        [Test]
        public void IsNew_OldEntity_ReturnsTrue() {
            FakeEntity oldEntity = new FakeEntity {
                Id = 42,
                DateCreated = DateTime.Now.AddDays(-42)
            };

            var result = oldEntity.IsNew();

            Assert.That(result, Is.False);
        }
    }
}
