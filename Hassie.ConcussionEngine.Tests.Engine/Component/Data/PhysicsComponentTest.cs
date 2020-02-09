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
    /// Tests for the physics component.
    /// </summary>
    [TestFixture]
    public class PhysicsComponentTest
    {
        /// <summary>
        /// Tests the initialisation of the component.
        /// </summary>
        [TestCase(1, 1f, 0f, 0f, 0f, 1f, 2.5f, 0f)]
        [TestCase(5, 0f, -1.965f, 0f, 0.125f, 0.799f, 3f, 1.255f)]
        [TestCase(10, 0f, 0f, -0.0233f, 0f, 100.999f, 1f, 0f)]
        public void InitComponent(int entityID, float accelerationX, float accelerationY, float gravityX, float gravityY,
                                  float mass, float velocityX, float velocityY)
        {
            // Arrange.
            PhysicsComponent component;

            // Act.
            component = new PhysicsComponent(entityID, accelerationX, accelerationY, gravityX, gravityY, mass, velocityX, velocityY);

            // Assert.
            Assert.IsTrue(entityID == component.EntityID &&
                Math.Abs(accelerationX - component.AccelerationX) < float.Epsilon &&
                Math.Abs(accelerationY - component.AccelerationY) < float.Epsilon &&
                Math.Abs(gravityX - component.GravityX) < float.Epsilon &&
                Math.Abs(gravityY - component.GravityY) < float.Epsilon &&
                Math.Abs(mass - component.Mass) < float.Epsilon &&
                Math.Abs(velocityX - component.VelocityX) < float.Epsilon &&
                Math.Abs(velocityY - component.VelocityY) < float.Epsilon);
        }

        /// <summary>
        /// Tests struct equality.
        /// Expected result is true.
        /// </summary>
        [TestCase(1, 1f, 0f, 0f, 0f, 1f, 2.5f, 0f)]
        [TestCase(5, 0f, -1.965f, 0f, 0.125f, 0.799f, 3f, 1.255f)]
        [TestCase(10, 0f, 0f, -0.0233f, 0f, 100.999f, 1f, 0f)]
        public void Equals_ShouldBeEqual(int entityID, float accelerationX, float accelerationY, float gravityX,
                                         float gravityY, float mass, float velocityX, float velocityY)
        {
            // Arrange.
            PhysicsComponent component1;
            PhysicsComponent component2;

            // Act.
            component1 = new PhysicsComponent(entityID, accelerationX, accelerationY, gravityX, gravityY, mass, velocityX, velocityY);
            component2 = new PhysicsComponent(entityID, accelerationX, accelerationY, gravityX, gravityY, mass, velocityX, velocityY);

            // Assert.
            Assert.IsTrue(component1 == component2);
        }

        /// <summary>
        /// Tests struct equality.
        /// Expected result is false.
        /// </summary>
        [TestCase(1, 1f, 0f, 0f, 0f, 1f, 2.5f, 0f, 18, -1f, 0f, 0f, 0f, 1f, 2.5f, 0f)]
        [TestCase(5, 0f, -1.965f, 0f, 0.125f, 0.799f, 3f, 1.255f, 1900, 0f, 1.965f, 0f, 0.125f, 0.799f, 3f, 1.255f)]
        [TestCase(10, 0f, 0f, -0.0233f, 0f, 100.999f, 1f, 0f, 10491, 0f, 0f, -0.0233f, 0f, -100.999f, 1f, 0f)]

        public void Equals_ShouldNotBeEqual(int id1, float accelerationX1, float accelerationY1, float gravityX1,
                                            float gravityY1, float mass1, float velocityX1, float velocityY1, int id2,
                                            float accelerationX2, float accelerationY2, float gravityX2, float gravityY2,
                                            float mass2, float velocityX2, float velocityY2)
        {
            // Arrange.
            PhysicsComponent component1;
            PhysicsComponent component2;

            // Act.
            component1 = new PhysicsComponent(id1, accelerationX1, accelerationY1, gravityX1, gravityY1, mass1, velocityX1, velocityY1);
            component2 = new PhysicsComponent(id2, accelerationX2, accelerationY2, gravityX2, gravityY2, mass2, velocityX2, velocityY2);

            // Assert.
            Assert.IsFalse(component1 == component2);
        }
    }
}
