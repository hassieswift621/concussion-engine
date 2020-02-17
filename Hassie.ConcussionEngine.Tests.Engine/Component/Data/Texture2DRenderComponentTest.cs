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
    /// Tests for the texture 2D render component.
    /// </summary>
    [TestFixture]
    public class Texture2DRenderComponentTest
    {
        /// <summary>
        /// Tests the initialisation of the component.
        /// </summary>
        [TestCase(505, 45)]
        public void InitComponent(int entityID, int renderOrder)
        {
            // Arrange.
            Texture2DRenderComponent component;

            // Act.
            component = new Texture2DRenderComponent(entityID, renderOrder, null);

            // Assert.
            Assert.IsTrue(entityID == component.EntityID &&
                renderOrder == component.RenderOrder &&
                component.Texture == null);
        }

        /// <summary>
        /// Tests struct equality.
        /// Expected result is true.
        /// </summary>
        [TestCase(637, 5)]
        public void Equals_ShouldBeEqual(int entityID, int renderOrder)
        {
            // Arrange.
            Texture2DRenderComponent component1;
            Texture2DRenderComponent component2;

            // Act.
            component1 = new Texture2DRenderComponent(entityID, renderOrder, null);
            component2 = new Texture2DRenderComponent(entityID, renderOrder, null);

            // Assert.
            Assert.IsTrue(component1 == component2);
        }

        /// <summary>
        /// Tests struct equality.
        /// Expected result is false.
        /// </summary>
        [TestCase(1493, 56, 878, 9)]

        public void Equals_ShouldNotBeEqual(int id1, int renderOrder1, int id2, int renderOrder2)
        {
            // Arrange.
            Texture2DRenderComponent component1;
            Texture2DRenderComponent component2;

            // Act.
            component1 = new Texture2DRenderComponent(id1, renderOrder1, null);
            component2 = new Texture2DRenderComponent(id2, renderOrder2, null);

            // Assert.
            Assert.IsFalse(component1 == component2);
        }
    }
}
