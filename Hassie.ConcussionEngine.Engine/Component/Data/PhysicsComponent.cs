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
    public struct PhysicsComponent
    {
        /// <summary>
        /// The ID of the entity.
        /// </summary>
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
        public PhysicsComponent(int entityID, float accelerationX = 0, float accelerationY = 0, float gravityX = 0,
            float gravityY = 0, float mass = 0, float velocityX = 0, float velocityY = 0)
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
    }
}
