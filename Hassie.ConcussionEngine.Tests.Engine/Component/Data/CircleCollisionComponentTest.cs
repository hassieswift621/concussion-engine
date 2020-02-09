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
    /// Tests for the circle collision component.
    /// </summary>
    [TestFixture]
    public class CircleCollisionComponentTest
    {
        /// <summary>
        /// Tests the initialisation of the component.
        /// </summary>
        [TestCase(1)]
        public void InitComponent(int entityID)
        {
            // Arrange.
            CircleCollisionComponent component;

            // Act.
            component = new CircleCollisionComponent(entityID);

            // Assert.
            Assert.AreEqual(entityID, component.EntityID);
        }

        /// <summary>
        /// Tests struct equality.
        /// Expected result is true.
        /// </summary>
        [TestCase(5)]
        public void Equals_ShouldBeEqual(int entityID)
        {
            // Arrange.
            CircleCollisionComponent component1;
            CircleCollisionComponent component2;

            // Act.
            component1 = new CircleCollisionComponent(entityID);
            component2 = new CircleCollisionComponent(entityID);

            // Assert.
            Assert.IsTrue(component1 == component2);
        }

        /// <summary>
        /// Tests struct equality.
        /// Expected result is false.
        /// </summary>
        [TestCase(10, 121)]
        public void Equals_ShouldNotBeEqual(int entity1, int entity2)
        {
            // Arrange.
            CircleCollisionComponent component1;
            CircleCollisionComponent component2;

            // Act.
            component1 = new CircleCollisionComponent(entity1);
            component2 = new CircleCollisionComponent(entity2);

            // Assert.
            Assert.IsFalse(component1 == component2);
        }
    }
}
