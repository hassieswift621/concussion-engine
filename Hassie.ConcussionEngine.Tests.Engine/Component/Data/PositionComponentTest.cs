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
    /// Tests for the position component.
    /// </summary>
    [TestFixture]
    public class PositionComponentTest
    {
        /// <summary>
        /// Tests the initialisation of the component.
        /// </summary>
        [TestCase(10, -3.423f, 248.647f)]
        public void InitComponent(int entityID, float x, float y)
        {
            // Arrange.
            PositionComponent component;

            // Act.
            component = new PositionComponent(entityID, x, y);

            // Assert.
            Assert.IsTrue(entityID == component.EntityID && 
                Math.Abs(x - component.X) < float.Epsilon && 
                Math.Abs(y - component.Y) < float.Epsilon);
        }

        /// <summary>
        /// Tests struct equality.
        /// Expected result is true.
        /// </summary>
        [TestCase(5, 64.3f, 0.33f)]
        public void Equals_ShouldBeEqual(int entityID, float x, float y)
        {
            // Arrange.
            PositionComponent component1;
            PositionComponent component2;

            // Act.
            component1 = new PositionComponent(entityID, x, y);
            component2 = new PositionComponent(entityID, x, y);

            // Assert.
            Assert.IsTrue(component1 == component2);
        }

        /// <summary>
        /// Tests struct equality.
        /// Expected result is false.
        /// </summary>
        [TestCase(10, -3.423f, 248.647f, 121, 2.423f, -248f)]

        public void Equals_ShouldNotBeEqual(int id1, float x1, float y1, int id2, float x2, float y2)
        {
            // Arrange.
            PositionComponent component1;
            PositionComponent component2;

            // Act.
            component1 = new PositionComponent(id1, x1, y1);
            component2 = new PositionComponent(id2, x2, y2);

            // Assert.
            Assert.IsFalse(component1 == component2);
        }
    }
}
