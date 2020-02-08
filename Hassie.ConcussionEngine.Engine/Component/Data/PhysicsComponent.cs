using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Engine.Component.Data
{
    /// <summary>
    /// Component to store physics properties.
    /// </summary>
    public struct PhysicsComponent : IComponent, IEquatable<PhysicsComponent>
    {
        public int EntityID { get; }

        /// <summary>
        /// The acceleration along the x axis.
        /// </summary>
        public float AccelerationX { get; set; }

        /// <summary>
        /// The acceleration along the y axis.
        /// </summary>
        public float AccelerationY { get; set; }

        /// <summary>
        /// The gravity along the x axis.
        /// </summary>
        public float GravityX { get; set; }

        /// <summary>
        /// The gravity along the y axis.
        /// </summary>
        public float GravityY { get; set; }

        /// <summary>
        /// The mass of the entity.
        /// </summary>
        public float Mass { get; set; }

        /// <summary>
        /// The velocity along the x axis.
        /// </summary>
        public float VelocityX { get; set; }

        /// <summary>
        /// The velocity along the y axis.
        /// </summary>
        public float VelocityY { get; set; }

        /// <summary>
        /// Initialises a new instance of the component.
        /// </summary>
        /// <param name="entityID">The ID of the entity.</param>
        /// <param name="accelerationX">The acceleration along the x axis.</param>
        /// <param name="accelerationY">The acceleration along the y axis.</param>
        /// <param name="gravityX">The gravity along the x axis.</param>
        /// <param name="gravityY">The gravity along the y axis.</param>
        /// <param name="mass">The mass of the entity.</param>
        /// <param name="velocityX">The velocity along the x axis.</param>
        /// <param name="velocityY">The velocity along the y axis.</param>
        public PhysicsComponent(int entityID, float accelerationX, float accelerationY, float gravityX, float gravityY,
                                float mass, float velocityX, float velocityY)
        {
            EntityID = entityID;
            AccelerationX = accelerationX;
            AccelerationY = accelerationY;
            GravityX = gravityX;
            GravityY = gravityY;
            Mass = mass;
            VelocityX = velocityX;
            VelocityY = velocityY;
        }

        public bool Equals(PhysicsComponent other) =>
            (EntityID, AccelerationX, AccelerationY, GravityX, GravityY, Mass, VelocityX, VelocityX) ==
                (other.EntityID, other.AccelerationX, other.AccelerationY, other.GravityX, other.GravityY,
                    other.Mass, other.VelocityX, other.VelocityY);

        public override bool Equals(object obj) => obj is PhysicsComponent component ? Equals(component) : false;

        public override int GetHashCode() => 
            (EntityID, AccelerationX, AccelerationY, GravityX, GravityY, Mass, VelocityX, VelocityX).GetHashCode();

        public static bool operator ==(PhysicsComponent left, PhysicsComponent right) => left.Equals(right);

        public static bool operator !=(PhysicsComponent left, PhysicsComponent right) => !(left == right);
    }
}