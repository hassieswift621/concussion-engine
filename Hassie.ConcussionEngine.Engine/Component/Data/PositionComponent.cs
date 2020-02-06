using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hassie.ConcussionEngine.Engine.Component.Data
{
    /// <summary>
    /// Component to store a 2D position of an entity.
    /// </summary>
    public struct PositionComponent : IComponent, IEquatable<PositionComponent>
    {
        public int EntityID { get; }

        /// <summary>
        /// The x coordinate of the entity.
        /// </summary>
        public float X { get; set; }

        // The y coordinate of the entity.
        public float Y { get; set; }

        /// <summary>
        /// Initialises a new instance of the component.
        /// </summary>
        /// <param name="entityID">The ID of the entity.</param>
        /// <param name="x">The x coordinate of the entity.</param>
        /// <param name="y">The y coordinate of the entity.</param>
        public PositionComponent(int entityID, float x, float y)
        {
            EntityID = entityID;
            X = x;
            Y = y;
        }

        public bool Equals(PositionComponent other)
        {
            if (EntityID == other.EntityID &&
                X == other.X &&
                Y == other.Y)
            {
                return true;
            }

            return false;
        }
    }
}
