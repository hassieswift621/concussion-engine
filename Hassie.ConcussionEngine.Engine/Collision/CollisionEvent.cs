using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Engine.Collision
{
    /// <summary>
    /// Collisio event args.
    /// </summary>
    public class CollisionEvent : EventArgs
    {
        /// <summary>
        /// The ID of the colliding entity.
        /// </summary>
        public int Collider { get; }

        /// <summary>
        /// The ID of the collidable entity.
        /// </summary>
        public int Collidable { get; }

        /// <summary>
        /// The ID of the world in which this collision event occurred.
        /// </summary>
        public int WorldID { get; }

        /// <summary>
        /// Constructor for the collision event.
        /// </summary>
        /// <param name="collider">The ID of the colliding entity.</param>
        /// <param name="collidable">The ID of the collidable entity.</param>
        /// <param name="worldID">The ID of the world in which this collision event occurred.</param>
        public CollisionEvent(int collider, int collidable, int worldID)
        {
            // Store data.
            Collider = collider;
            Collidable = collidable;
            WorldID = worldID;
        }
    }
}
