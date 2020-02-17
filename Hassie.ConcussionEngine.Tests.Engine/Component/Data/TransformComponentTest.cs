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
    /// Tests for the transform component.
    /// </summary>
    [TestFixture]
    public class TransformComponentTest
    {
        /// <summary>
        /// Tests the initialisation of the component.
        /// </summary>
        [TestCase(45, 100, 90f, 1f, 100)]
        public void InitComponent(int entityID, int height, float rotation, float scale, int width)
        {
            // Arrange.
            TransformComponent component;

            // Act.
            component = new TransformComponent(entityID, height, rotation, scale, width);

            // Assert.
            Assert.IsTrue(entityID == component.EntityID &&
                height == component.Height &&
                Math.Abs(rotation - component.Rotation) < float.Epsilon &&
                Math.Abs(scale - component.Scale) < float.Epsilon &&
                width == component.Width);
        }

        /// <summary>
        /// Tests struct equality.
        /// Expected result is true.
        /// </summary>
        [TestCase(340, 56, 0f, 1.5f, 28)]
        public void Equals_ShouldBeEqual(int entityID, int height, float rotation, float scale, int width)
        {
            // Arrange.
            TransformComponent component1;
            TransformComponent component2;

            // Act.
            component1 = new TransformComponent(entityID, height, rotation, scale, width);
            component2 = new TransformComponent(entityID, height, rotation, scale, width);

            // Assert.
            Assert.IsTrue(component1 == component2);
        }

        /// <summary>
        /// Tests struct equality.
        /// Expected result is false.
        /// </summary>
        [TestCase(754, 60, 0f, 1.77f, 60, 478, 1200, 40f, 0.99f, 800)]

        public void Equals_ShouldNotBeEqual(int id1, int height1, float rotation1, float scale1, int width1, int id2,
                                            int height2, float rotation2, float scale2, int width2)
        {
            // Arrange.
            TransformComponent component1;
            TransformComponent component2;

            // Act.
            component1 = new TransformComponent(id1, height1, rotation1, scale1, width1);
            component2 = new TransformComponent(id2, height2, rotation2, scale2, width2);

            // Assert.
            Assert.IsFalse(component1 == component2);
        }
    }
}
