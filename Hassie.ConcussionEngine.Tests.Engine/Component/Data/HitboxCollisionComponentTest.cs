using Hassie.ConcussionEngine.Engine.Component.Data;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Tests.Engine.Component.Data
{
    /// <summary>
    /// Tests for the hitbox collision component.
    /// </summary>
    [TestFixture]
    public class HitboxCollisionComponentTest
    {
        /// <summary>
        /// Tests the initialisation of the component.
        /// </summary>
        [TestCase(101)]
        public void InitComponent(int entityID)
        {
            // Arrange.
            HitboxCollisionComponent component;

            // Act.
            component = new HitboxCollisionComponent(entityID);

            // Assert.
            Assert.AreEqual(entityID, component.EntityID);
        }

        /// <summary>
        /// Tests struct equality.
        /// Expected result is true.
        /// </summary>
        [TestCase(843)]
        public void Equals_ShouldBeEqual(int entityID)
        {
            // Arrange.
            HitboxCollisionComponent component1;
            HitboxCollisionComponent component2;

            // Act.
            component1 = new HitboxCollisionComponent(entityID);
            component2 = new HitboxCollisionComponent(entityID);

            // Assert.
            Assert.IsTrue(component1 == component2);
        }

        /// <summary>
        /// Tests struct equality.
        /// Expected result is false.
        /// </summary>
        [TestCase(6543, 122)]
        public void Equals_ShouldNotBeEqual(int entity1, int entity2)
        {
            // Arrange.
            HitboxCollisionComponent component1;
            HitboxCollisionComponent component2;

            // Act.
            component1 = new HitboxCollisionComponent(entity1);
            component2 = new HitboxCollisionComponent(entity2);

            // Assert.
            Assert.IsFalse(component1 == component2);
        }
    }
}
