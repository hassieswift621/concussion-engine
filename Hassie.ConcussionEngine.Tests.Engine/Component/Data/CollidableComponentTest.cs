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
    /// Tests for the collidable component.
    /// </summary>
    [TestFixture]
    public class CollidableComponentTest
    {
        /// <summary>
        /// Tests the initialisation of the component.
        /// </summary>
        [TestCase(12)]
        public void InitComponent(int entityID)
        {
            // Arrange.
            CollidableComponent component;

            // Act.
            component = new CollidableComponent(entityID);

            // Assert.
            Assert.AreEqual(entityID, component.EntityID);
        }

        /// <summary>
        /// Tests struct equality.
        /// Expected result is true.
        /// </summary>
        [TestCase(202)]
        public void Equals_ShouldBeEqual(int entityID)
        {
            // Arrange.
            CollidableComponent component1;
            CollidableComponent component2;

            // Act.
            component1 = new CollidableComponent(entityID);
            component2 = new CollidableComponent(entityID);

            // Assert.
            Assert.IsTrue(component1 == component2);
        }

        /// <summary>
        /// Tests struct equality.
        /// Expected result is false.
        /// </summary>
        [TestCase(23, 54)]
        public void Equals_ShouldNotBeEqual(int entity1, int entity2)
        {
            // Arrange.
            CollidableComponent component1;
            CollidableComponent component2;

            // Act.
            component1 = new CollidableComponent(entity1);
            component2 = new CollidableComponent(entity2);

            // Assert.
            Assert.IsFalse(component1 == component2);
        }
    }
}
